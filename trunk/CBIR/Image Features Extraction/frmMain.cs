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
        List<FeatureInfo> mListFeatureDB;

        Bitmap bmQuery;
        ArrayList FileArray;
        ArrayList FileTypes;
        string sImgDbPath;  //duong dan toi thu muc chua ImageDB
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

            //duyệt mảng file --> tạo Object
            for (int i = 0; i < FileArray.Count; i++)
            {
                FeatureInfo objInfo = new FeatureInfo();
                //objInfo.BitSequence  =  A. Hoa (lay tu anh Final co grid)

                //đưa vào list & XML
                mListFeatureDB.Add(objInfo);

                objCtrl.Add(objInfo);
            }

            objCtrl.WriteXML(); //ghi XML ra mPath
        }

    }
}
