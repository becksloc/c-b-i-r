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
                Bitmap bmpResized = ZinImageLib.Resize(bmpRotated, ZinImageLib.WidthStandard, ZinImageLib.WidthStandard * bmpRotated.Height / bmpRotated.Width, true);
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


                mFeatureQuery.Clear();
                lblBitString.Text = "";

                Bitmap[] bmpAllCases = new Bitmap[4];
                bmpAllCases[0] = (Bitmap)bmpResized.Clone();
                bmpAllCases[1] = ZinImageLib.RotateImage(bmpResized, 180); //Quay cac goc nay ko lam thay doi width
                //-------------VE THU XEM NAO-----------------------
                gr.DrawImage(bmpAllCases[1], 674, 380 + 150);

                //Phủ lưới lên
                for (int i = 0; i < bmpResized.Width; i++)
                    if (i % ZinImageLib.CellWidth == 0)
                    {
                        gr.DrawLine(Pens.Red, i + 674, 0 + 380 + 150, i + 674, bmpResized.Height + 380 + 150);
                    }

                for (int j = 0; j < bmpResized.Height; j++)
                    if (j % ZinImageLib.CellHeight == 0)
                        gr.DrawLine(Pens.Red, 0 + 674, j + 380 + 150, bmpResized.Width + 674, j + 380 + 150);

                //------------------------------------------------

                //bmpAllCases[2] = Flip bmpBlackFill
                //bmpAllCases[3] = Flip bmpAllCase[1]
                for (int i = 0; i < 2; i++)
                {
                    //Tô hình dạng thành đen đặc trước khi đếm
                    Bitmap bmpBlackFill = (Bitmap)bmpAllCases[i].Clone();
                    ZinImageLib.FillSolidBlack(bmpBlackFill);

                    gr.DrawImage(bmpBlackFill, 458 - i * 250, 380 + 150);

                    string BitSeq = ZinImageLib.GetBitString(bmpBlackFill);
                    lblBitString.Text += BitSeq + Environment.NewLine;

                    //Gán vào mFeatureQuery
                    FeatureInfo temp = new FeatureInfo();
                    temp.BitSequence = BitSeq;
                    temp.MinorAxis = ZinImageLib.GetMinorAxisLen(bmpBlackFill);
                    //Dua vao truy van (se co 4)
                    mFeatureQuery.Add(temp);                   
                }

                //gr.Dispose();
                btnSearch.Enabled = true;
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
                    //Neu do sai khac thoa man muc cho phep
                    if (SimilitaryMeasure(mFeatureQuery[k], mListFeatureDB[i]) <= ZinImageLib.Threshold)
                    {
                        //Neu anh da ton tai --> ko add vao result
                        int check = 0;
                        for (int j = 0; j < listResult.Count; j++)
                            if (listResult.Count > 0 && listResult[j].ImagePath == mListFeatureDB[i].ImagePath)
                                check++;

                        if (check == 0)
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
            int y = 83;
            int row = 0;
            int col = 0;
            for (int i = 0; i < listResult.Count; i++)
            {
                //Lay tung anh ra
                bmpTemp = (Bitmap)Bitmap.FromFile(listResult[i].ImagePath);

                gr.DrawImage(bmpTemp, x + 300 * col, y + 160 * row);

                col++;

                if ((i + 1) % 2 == 0)
                {
                    //xuong dong
                    row++;
                    col = 0;
                }
            }

        }

        //Tinh do tuong tu
        private int SimilitaryMeasure(FeatureInfo f1, FeatureInfo f2)
        {
            int res;
            //Kiểm tra trục phụ. Neu khac nhau qua lon --> loai bo
            if (Math.Abs(f1.MinorAxis - f2.MinorAxis) > 2)
                res = ZinImageLib.Threshold + 1; //Cho qua nguong
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
