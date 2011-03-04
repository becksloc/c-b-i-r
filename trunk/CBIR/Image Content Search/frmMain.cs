using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Image_Processing_Library;
using System.IO;

namespace Image_Content_Search
{
    public partial class frmMain : Form
    {
        string mPath;
        List<FeatureInfo> mListFeatureDB;
        FeatureInfo mFeatureQuery;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdBrowseImage.ShowDialog(this) == DialogResult.OK)
            {
                Graphics gr = CreateGraphics();// Khởi tạo đồ hoạ trên form chính
                gr.Clear(this.BackColor);

                //Hien thi anh len pbQueryImage
                Bitmap bmpQuery = (Bitmap)Bitmap.FromFile(ofdBrowseImage.FileName);

                //Test 1 so Function trong Lib
                //ZinImageLib.ToBinaryImage(bmQuery, 100);
                //ZinImageLib.ToGrayScale(bmQuery);
                //bmQuery = ZinImageLib.ToGrayScale2(bmQuery);
                //bmQuery = ZinImageLib.RotateImage(bmQuery, 45f);
             
                pbQueryImage.Image = bmpQuery;

                //Tách đối tượng ra khỏi ảnh --> tạo ảnh mới chỉ chứa khít đối tượng (shape)
                Bitmap bmpExtracted = ZinImageLib.ExtractShape(bmpQuery);
                pbExtractedObject.Image = bmpExtracted;
                
                //A. Hòa: tìm x1, y1, x2, y2 của trục chính (dài nhất)
                int x1, y1, x2, y2;
                ImageFuncLib.getPoint(out x1, out y1, out x2, out y2, bmpExtracted);
                //Vẽ ảnh (để vẽ đường, ko dùng đc PicBox)
                gr.DrawImage(bmpExtracted, 242, 380);
                //Ve duong truc chinh                
                Pen myPen = new Pen(Color.Red, 2);
                gr.DrawLine(myPen, x1 + 242, y1 + 380, x2 + 242, y2 + 380);

                //Tìm góc --> xoay. Sau khi xoay sẽ xuất hiện nền thừa --> tìm HCN cơ sở
                double angle = ZinImageLib.AngleMajorAndX(x1, y1, x2, y2); //!!! Important
                Bitmap bmpRotated = ZinImageLib.RotateImage(bmpExtracted, (float)angle); //Hàm Rotate2: ko làm thay đổi size --> Ko ổn
                //pbImageRotated.Image = bmpRotated;
                ZinImageLib.TransparentToWhite(bmpRotated);
                bmpRotated = ZinImageLib.ExtractShape(bmpRotated);
                gr.DrawImage(bmpRotated, 458, 380);

                //Sau khi xoay xong thì mới Resize về kích thước cố định
                int iHeightResize = (bmpRotated.Height / ZinImageLib.CellHeight) * ZinImageLib.CellHeight;
                if (bmpRotated.Height % ZinImageLib.CellHeight != 0)
                    iHeightResize += ZinImageLib.CellHeight;

                Bitmap bmpResized = ZinImageLib.Resize(bmpRotated, ZinImageLib.WidthStandard, iHeightResize, true);
                //Bitmap bmpResized = ZinImageLib.ResizeImage(bmpRotated, ZinImageLib.WidthStandard, ZinImageLib.WidthStandard * bmpRotated.Height / bmpRotated.Width); //Bị thay đổi -> nguy hiểm
                gr.DrawImage(bmpResized, 674, 380);
                
                //Phủ lưới lên
                for (int i = 0; i < bmpResized.Width; i++)
                    if (i % ZinImageLib.CellWidth == 0)
                    {
                        gr.DrawLine(Pens.Red, i + 674, 0 + 380, i + 674, bmpResized.Height + 380);
                    }

                for (int j = 0; j < bmpResized.Height; j++)
                    if (j % ZinImageLib.CellHeight == 0)
                        gr.DrawLine(Pens.Red, 0 + 674, j + 380, bmpResized.Width + 674, j + 380);

                //Tô hình dạng thành đen đặc trước khi đếm
                Bitmap bmpBlackFill = (Bitmap)bmpResized.Clone();
                ZinImageLib.FillSolidBlack(bmpBlackFill);

                gr.DrawImage(bmpBlackFill, this.Width/2, this.Height/2 - 100);

                //A. Hòa: trích chuỗi, trục
                //lblBitString.Text = ImageFuncLib.getImgString(ZinImageLib.CellWidth, ZinImageLib.CellHeight, ZinImageLib.PercentCovered, bmpBlackFill);
                lblBitString.Text = ZinImageLib.GetBitString(bmpBlackFill);
                //Gán vào mFeatureQuery
                //mFeatureQuery.BitSequence = 
                //mFeatureQuery.MinorAxis = 

                //gr.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Tách các Rectangle chứa đối tượng (hình dạng) ra khỏi ảnh -> lưu vào 1 mảng (rectangle)        
            //Duyệt qua mảng -> xử lý với từng đối tượng cụ thể
            // - Với mỗi đối tượng cần tìm -> tìm 4 lần ứng với 4 trường hợp (xoay)
            // - Tìm trục chính, trục phụ, tâm sai
            // - Chuẩn hóa xoay
            // - Resize ảnh về kích thước sao cho trục chính luôn cố định = 192px
            // - Phủ lưới lên đối tượng này -> trích chọn -> dãy nhị phân

            //Đọc file đặc trưng (XML) --> lưu vào List
            FeatureController objCtrl = new FeatureController(mPath);
            mListFeatureDB = objCtrl.GetAll();

            //So sánh, nếu BitSeq khác nhau bao nhiêu thì OK
            //for (int i = 0; i < mListFeatureDB.Count; i++)
            string s1 = "1101", s2 = "111111";
            int bitsDiff = BitsDifferent(s1, s2);
        }

        private int SimilitaryMeasure(FeatureInfo f1, FeatureInfo f2)
        {
            //Kiểm tra trục phụ

            return 0;
        }

        private int BitsDifferent(string s1, string s2)
        {
            //Làm cho 2 xâu bằng nhau (thêm 0 vào cuối)
            int MaxLen = s1.Length > s2.Length ? s1.Length : s2.Length;
            for (int i = s1.Length; i < MaxLen; i++) s1 += "0";
            for (int i = s2.Length; i < MaxLen; i++) s2 += "0";

            //Tìm số Bit khác nhau
            int count = 0;
            for (int i = 0; i < MaxLen; i++)
                if (s1[i] != s2[i])
                    count++;

            return count;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Set path
            mPath = Directory.GetCurrentDirectory() + "\\FeatureDB.xml";
            //mPath = Application.StartupPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Override??? Cái này phải để đây để Draw ngoài sự kiện Paint???
        }

    }
}
