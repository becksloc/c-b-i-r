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
        Bitmap bmQuery;
        ArrayList FileArray;
        ArrayList FileTypes;
        string sImgDbPath;
        int iCurrentImg;

        public frmMain()
        {
            InitializeComponent();
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

            sImgDbPath = Directory.GetCurrentDirectory()+ "\\ImagesDB";

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdBrowseImage.ShowDialog(this) == DialogResult.OK)
            {
                bmQuery = (Bitmap)Bitmap.FromFile(ofdBrowseImage.FileName);

                Graphics gr = CreateGraphics();// Khởi tạo đồ hoạ trên form chính
                gr.DrawImage(bmQuery, 50, 100);
                gr.Dispose();// Giải phóng biến graphics
             
                int x1 , y1, x2, y2;
                Image_Processing_Library.
                ImageFuncLib.getPoint(out x1, out y1, out x2, out y2,bmQuery );

                double max = 0;
                max = ImageFuncLib.Distance2Point(x1, y1, x2, y2);
                lblThongtin.Text = "Trục chính: " + "\n" + "a(" + x1.ToString() + "," + y1.ToString() + ")";
                lblThongtin.Text = lblThongtin.Text + "\n";
                lblThongtin.Text = lblThongtin.Text + "b(" + x2.ToString() + "," + y2.ToString() + ")";
                lblThongtin.Text = lblThongtin.Text + "\nKhoảng cách: " + max.ToString();
                
                //Ve duong truc chinh
                System.Drawing.Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                myPen.Width = 3;
                System.Drawing.Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawLine(myPen, x1+50 , y1+100, x2+50, y2+100);
                myPen.Dispose();
                formGraphics.Dispose();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }
        private void ofdBrowseImage_FileOk(object sender, CancelEventArgs e)
        {

        }
        
    }
}
