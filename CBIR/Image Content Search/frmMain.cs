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
        List<FeatureInfo> mFeatureQuery = new List<FeatureInfo>();
        
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
                pbQueryImage.Image = bmpQuery;

                //Buoc 1: Tách đối tượng ra khỏi ảnh --> tạo ảnh mới chỉ chứa khít đối tượng (shape)
                Bitmap bmpExtracted = ZinImageGrid.ExtractShape(bmpQuery);
                gr.DrawImage(bmpExtracted, 28, 380);
                
                //Buoc 2: tìm x1, y1, x2, y2 của trục chính (dài nhất)
                int x1, y1, x2, y2;
                ImageFuncLib.getPoint(out x1, out y1, out x2, out y2, bmpExtracted);
                //Vẽ ảnh (để vẽ đường, ko dùng đc PicBox)
                gr.DrawImage(bmpExtracted, 242, 380);
                //Ve duong truc chinh                
                Pen myPen = new Pen(Color.Red, 2);
                gr.DrawLine(myPen, x1 + 242, y1 + 380, x2 + 242, y2 + 380);

                //Buoc 3: Tìm góc --> xoay. Sau khi xoay sẽ xuất hiện nền thừa --> tìm HCN cơ sở để cắt bớt
                double angle = ZinImageGrid.AngleMajorAndX(x1, y1, x2, y2); //!!! Important
                Bitmap bmpRotated = ZinImageLib.RotateImage(bmpExtracted, (float)angle); //Hàm Rotate2: ko làm thay đổi size --> bị cắt xén ảnh --> Ko ổn
                ///////////////(chu y: ham Xoay co van de --> Fill black bi loi)////////////////
                ZinImageGrid.TransparentToWhite(bmpRotated);
                bmpRotated = ZinImageGrid.ExtractShape(bmpRotated); //cắt bớt nền thừa
                gr.DrawImage(bmpRotated, 458, 380);

                //Buoc 4: Sau khi xoay xong thì mới Resize về kích thước cố định
                Bitmap bmpResized = ZinImageLib.Resize(bmpRotated, ZinImageGrid.WidthStandard, ZinImageGrid.WidthStandard * bmpRotated.Height / bmpRotated.Width, true);
                //Bitmap bmpResized = ZinImageLib.ResizeImage(bmpRotated, ZinImageGrid.WidthStandard, ZinImageGrid.WidthStandard * bmpRotated.Height / bmpRotated.Width); //Bị thay đổi -> nguy hiểm

                //Buoc 5: Lưu 4 trường hợp: lật trái, phải, ngược của ảnh
                Bitmap[] bmpAllCases = new Bitmap[4];
                for (int i = 0; i < 4; i++)
                    bmpAllCases[i] = (Bitmap)bmpResized.Clone(); //Copy thanh 4 anh

                //---- Lật 3 ảnh, giữ lại ảnh gốc -----
                ZinImageLib.Flip(bmpAllCases[1], false, true);
                ZinImageLib.Flip(bmpAllCases[2], true, false);
                ZinImageLib.Flip(bmpAllCases[3], true, true);

                //Buoc 6: Phu luoi len
                for (int i = 0; i < 4; i++)
                {
                    gr.DrawImage(bmpAllCases[i], 28 + i * 220, 517);

                    //Minh hoa: Phủ lưới lên
                    for (int c = 0; c <= bmpAllCases[i].Width; c++)
                        if (c % ZinImageGrid.CellWidth == 0)
                            gr.DrawLine(Pens.Red, 28 + i * 220 + c, 517, 28 + i * 220 + c, bmpAllCases[i].Height + 517);

                    for (int r = 0; r <= bmpAllCases[i].Height; r++)
                        if (r % ZinImageGrid.CellHeight == 0)
                            gr.DrawLine(Pens.Red, 28 + i * 220, r + 517, 28 + i * 220 + bmpAllCases[i].Width, r + 517);
                }

                //Buoc 7: dem so o >= 15% --> bit 1
                mFeatureQuery.Clear();
                lblBitString.Text = "";
                for (int i = 0; i < 4; i++)
                {
                    //Tô hình dạng thành đen đặc trước khi đếm
                    Bitmap bmpBlackFill = (Bitmap)bmpAllCases[i].Clone();
                    ZinImageGrid.FillSolidBlack(bmpBlackFill);
                    //show ra xem the nao
                    //gr.DrawImage(bmpBlackFill, 300 + i * 200, 150);

                    string BitSeq = ZinImageGrid.GetBitString(bmpBlackFill);
                    lblBitString.Text += ZinImageGrid.DisplayBitString(BitSeq) + Environment.NewLine;

                    //Gán vào mFeatureQuery
                    FeatureInfo temp = new FeatureInfo();
                    temp.BitSequence = BitSeq;
                    temp.MinorAxis = ZinImageGrid.GetMinorAxisLen(bmpBlackFill);
                    
                    //Dua ca 4 truong hop anh vao truy van
                    mFeatureQuery.Add(temp);                   
                }

                //gr.Dispose();
                btnSearch.Enabled = true;
                lblResultCount.Text = "";
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

            //So sánh, neu do do OK --> luu vao mang
            List<FeatureInfo> listResult = new List<FeatureInfo>();
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < mListFeatureDB.Count; i++)
                {
                    //Neu do sai khac thoa man muc cho phep && chua co trong Result --> Add vao result
                    if (SimilitaryMeasure(mFeatureQuery[k], mListFeatureDB[i]) <= ZinImageGrid.Threshold && !listResult.Contains(mListFeatureDB[i]))
                    {
                        listResult.Add(mListFeatureDB[i]);
                    }
                }

            }
            //Sap xep listResult de uu tien SM nho len tren

            //Hien thi Ket qua
            lblResultCount.Text = listResult.Count + " (ảnh)";

            Graphics gr = CreateGraphics();// Khởi tạo đồ hoạ trên form chính
            //gr.Clear(this.BackColor);

            Bitmap bmpTemp;
            int x = 308;
            int y = 100;
            for (int i = 0; i < listResult.Count; i++)
            {
                //Lay tung anh ra
                bmpTemp = (Bitmap)Bitmap.FromFile(listResult[i].ImagePath);

                gr.DrawImage(bmpTemp, x + 220 * i, y);
            }

        }

        //Tinh do tuong tu
        private int SimilitaryMeasure(FeatureInfo f1, FeatureInfo f2)
        {
            int res;
            //Kiểm tra trục phụ. Neu khac nhau qua lon --> loai bo
            if (Math.Abs(f1.MinorAxis - f2.MinorAxis) > 2)
                res = ZinImageGrid.Threshold + 1; //Cho qua nguong
            else
                //Kiem tra xau bit
                res = BitsDifferent(f1.BitSequence, f2.BitSequence);

            return res;
        }

        //Tim so bit tuong ung khac nhau
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
            lblBitString.Text = "";
            lblResultCount.Text = "";
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
