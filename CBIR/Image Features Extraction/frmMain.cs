using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Image_Processing_Library;

namespace Image_Features_Extraction
{
    public partial class frmMain : Form
    {
        Bitmap bmQuery;

        public frmMain()
        {
            InitializeComponent();
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
        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
