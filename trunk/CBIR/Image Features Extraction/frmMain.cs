using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Image_Processing_Library;

namespace Image_Features_Extraction
{
    public partial class frmMain : Form
    {
        string mPath; //duong dan toi thu muc chua XML
        //List<FeatureInfo> mListFeatureDB;

        ArrayList FileArray;
        ArrayList FileTypes;
        string sImgDbPath;  //duong dan toi thu muc chua ImageDB
        int iCurrentImg;

        public frmMain()
        {
            InitializeComponent();
        }

        private void DrawImageProcessed()
        {
            Graphics gr = CreateGraphics();// Khởi tạo đồ hoạ trên form chính
            gr.Clear(this.BackColor);

            Bitmap bmpOrigin = (Bitmap)Bitmap.FromFile(pbImageInDB.ImageLocation);

            //Tách đối tượng ra khỏi ảnh --> tạo ảnh mới chỉ chứa khít đối tượng (shape)
            Bitmap bmpExtracted = ZinImageLib.ExtractShape(bmpOrigin);
            pbExtractedObject.Image = bmpExtracted;

            //A. Hòa: tìm x1, y1, x2, y2 của trục chính (dài nhất)
            int x1, y1, x2, y2;
            ImageFuncLib.getPoint(out x1, out y1, out x2, out y2, bmpExtracted);
            //Vẽ ảnh (để vẽ đường, ko dùng đc PicBox)
            gr.DrawImage(bmpExtracted, 253, 414);
            //Ve duong truc chinh                
            Pen myPen = new Pen(Color.Red, 2);
            gr.DrawLine(myPen, x1 + 253, y1 + 414, x2 + 253, y2 + 414);

            //Tìm góc --> xoay. Sau khi xoay sẽ xuất hiện nền thừa --> tìm HCN cơ sở
            double angle = ZinImageLib.AngleMajorAndX(x1, y1, x2, y2); //!!! Important
            Bitmap bmpRotated = ZinImageLib.RotateImage(bmpExtracted, (float)angle); //Hàm Rotate2: ko làm thay đổi size --> Ko ổn
            //pbImageRotated.Image = bmpRotated;
            ZinImageLib.TransparentToWhite(bmpRotated);
            bmpRotated = ZinImageLib.ExtractShape(bmpRotated);
            gr.DrawImage(bmpRotated, 491, 414);

            //Sau khi xoay xong thì mới Resize về kích thước cố định
            Bitmap bmpResized = ZinImageLib.Resize(bmpRotated, ZinImageLib.WidthStandard, ZinImageLib.WidthStandard * bmpRotated.Height / bmpRotated.Width, true);
            gr.DrawImage(bmpResized, 491, 196);

            //Phủ lưới lên
            for (int i = 0; i < bmpResized.Width; i++)
                if (i % ZinImageLib.CellWidth == 0)
                {
                    gr.DrawLine(Pens.Red, i + 491, 0 + 196, i + 491, bmpResized.Height + 196);
                }

            for (int j = 0; j < bmpResized.Height; j++)
                if (j % ZinImageLib.CellHeight == 0)
                    gr.DrawLine(Pens.Red, 0 + 491, j + 196, bmpResized.Width + 491, j + 196);


            //Tô hình dạng thành đen đặc trước khi đếm
            Bitmap bmpBlackFill = (Bitmap)bmpResized.Clone();
            ZinImageLib.FillSolidBlack(bmpBlackFill);

            //A. Hòa: trích chuỗi, trục
            string BitSeq = ZinImageLib.GetBitString(bmpBlackFill);
            lblBitString.Text = BitSeq;
            //Gán vào mFeatureQuery
            //mFeatureQuery.BitSequence = 
            //mFeatureQuery.MinorAxis = 

            //gr.Dispose();

        }

        private void frmMain_Load(object sender, EventArgs e)

        {
            // initialize the image types array
            FileTypes = new ArrayList();
            FileTypes.Add("*.JPG");
            FileTypes.Add("*.JPEG");
            FileTypes.Add("*.GIF");
            FileTypes.Add("*.BMP");
            FileTypes.Add("*.PNG");
            FileTypes.Add("*.TIF");
            FileTypes.Add("*.TIFF");

            mPath = Directory.GetCurrentDirectory() + "\\FeatureDB.xml";
            sImgDbPath = Directory.GetCurrentDirectory() + "\\ImagesDB";

            //Load duong dan anh vao list
            string[] szFiles;
            FileArray = new ArrayList();

            // find image files
            foreach (string szType in FileTypes)
            {
                szFiles = Directory.GetFiles(sImgDbPath, szType);
                if (szFiles.Length > 0)
                    FileArray.AddRange(szFiles);
            }

            //Neu co anh thi moi load
            if (FileArray.Count > 0)
            {
                iCurrentImg = 0;
                pbImageInDB.ImageLocation = FileArray[iCurrentImg].ToString();

                lblPage.Text = "(Ảnh thứ " + (iCurrentImg + 1).ToString() + " / " + FileArray.Count + ")";

                //ve anh
                DrawImageProcessed();
            }
            else
            {
                MessageBox.Show("Chưa có ảnh trong thư mục cơ sở dữ liệu ảnh!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ofdBrowseImage.ShowDialog() == DialogResult.OK)
            {

            }

        }

        private void btnNextObject_Click(object sender, EventArgs e)
        {
            //Neu chua het anh
            if (iCurrentImg < FileArray.Count)
            {
                iCurrentImg++;
                pbImageInDB.ImageLocation = FileArray[iCurrentImg].ToString();

                btnPrevObject.Enabled = true;

                //Disable nut neu la anh cuoi cung
                if (iCurrentImg == FileArray.Count - 1)
                {
                    btnNextObject.Enabled = false;
                }

                lblPage.Text = "(Ảnh thứ " + (iCurrentImg + 1).ToString() + " / " + FileArray.Count + ")";

                DrawImageProcessed();
            }
        }

        private void btnPrevObject_Click(object sender, EventArgs e)
        {
            if (iCurrentImg > 0)
            {
                iCurrentImg--;
                pbImageInDB.ImageLocation = FileArray[iCurrentImg].ToString();

                btnNextObject.Enabled = true;

                //Disable nut neu la anh dau tien
                if (iCurrentImg == 0)
                {
                    btnPrevObject.Enabled = false;
                }

                lblPage.Text = "(Ảnh thứ " + (iCurrentImg + 1).ToString() + " / " + FileArray.Count + ")";

                DrawImageProcessed();
            }
        }

        //phải có để vẽ ngoài sự kiện Paint
        protected override void OnPaint(PaintEventArgs e)
        {
            //Hic, chả hiểu
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            FeatureController objCtrl = new FeatureController(mPath);
            Bitmap bmpTemp;

            //duyệt mảng file --> tạo Object
            for (int i = 0; i < FileArray.Count; i++)
            {
                //Lay lan luot tung anh
                bmpTemp = (Bitmap)Bitmap.FromFile(FileArray[i].ToString());

                //Tách đối tượng ra khỏi ảnh --> tạo ảnh mới chỉ chứa khít đối tượng (shape)
                Bitmap bmpExtracted = ZinImageLib.ExtractShape(bmpTemp);

                //A. Hòa: tìm x1, y1, x2, y2 của trục chính (dài nhất)
                int x1, y1, x2, y2;
                ImageFuncLib.getPoint(out x1, out y1, out x2, out y2, bmpExtracted);
 
                //Tìm góc --> xoay. Sau khi xoay sẽ xuất hiện nền thừa --> tìm HCN cơ sở
                double angle = ZinImageLib.AngleMajorAndX(x1, y1, x2, y2); //!!! Important
                Bitmap bmpRotated = ZinImageLib.RotateImage(bmpExtracted, (float)angle); //Hàm Rotate2: ko làm thay đổi size --> Ko ổn
                ZinImageLib.TransparentToWhite(bmpRotated);
                bmpRotated = ZinImageLib.ExtractShape(bmpRotated);

                //Sau khi xoay xong thì mới Resize về kích thước cố định
                Bitmap bmpResized = ZinImageLib.Resize(bmpRotated, ZinImageLib.WidthStandard, ZinImageLib.WidthStandard * bmpRotated.Height / bmpRotated.Width, true);

                //Tô hình dạng thành đen đặc trước khi đếm
                Bitmap bmpBlackFill = (Bitmap)bmpResized.Clone();
                ZinImageLib.FillSolidBlack(bmpBlackFill);


                //Luu XML ============================
                FeatureInfo objInfo = new FeatureInfo();
                objInfo.BitSequence = ZinImageLib.GetBitString(bmpBlackFill);
                objInfo.MinorAxis = ZinImageLib.GetMinorAxisLen(bmpBlackFill);
                objInfo.ImagePath = FileArray[i].ToString();

                //đưa vào list & XML
                //mListFeatureDB.Add(objInfo);

                objCtrl.Add(objInfo);
            }

            objCtrl.WriteXML(); //ghi XML ra mPath

            MessageBox.Show("Đã trích chọn xong đặc trưng của ảnh & ghi vào file XML");
        }

    }
}
