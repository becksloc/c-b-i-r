using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Image_Processing_Library;

namespace Image_Content_Search
{
    public partial class frmMain : Form
    {
        Bitmap bmQuery;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdBrowseImage.ShowDialog(this) == DialogResult.OK)
            {
                Graphics gr = CreateGraphics();// Khởi tạo đồ hoạ trên form chính
                
                //Hien thi anh len pbQueryImage
                bmQuery = (Bitmap)Bitmap.FromFile(ofdBrowseImage.FileName);

                //Test 1 so Function trong Lib
                //ZinImageLib.ToBinaryImage(bmQuery, 100);
                //ZinImageLib.ToGrayScale(bmQuery);
                //bmQuery = ZinImageLib.ToGrayScale2(bmQuery);
                //bmQuery = ZinImageLib.RotateImage(bmQuery, 45f);
             
                pbQueryImage.Image = bmQuery;

                //Tách đối tượng ra khỏi ảnh --> tạo ảnh mới chỉ chứa khít đối tượng (shape)
                Rectangle recObject = ZinImageLib.FindRectangleBound(bmQuery);                
                Bitmap bmpExtracted = bmQuery.Clone(recObject, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                pbExtractedObject.Image = bmpExtracted;
                
                //A. Hòa: tìm x1, y1, x2, y2 của trục chính (dài nhất)
                int x1, y1, x2, y2;
                ImageFuncLib.getPoint(out x1, out y1, out x2, out y2, bmQuery);
                //Vẽ ảnh (để vẽ đường, ko dùng đc PicBox)
                gr.DrawImage(bmQuery, 242, 380);
                //Ve duong truc chinh                
                Pen myPen = new Pen(Color.Red, 3);
                gr.DrawLine(myPen, x1 + 242, y1 + 380, x2 + 242, y2 + 380);


                //--> tìm góc --> xoay
                double angle = ZinImageLib.AngleMajorAndX(x1, y1, x2, y2); //!!! Important
                Bitmap bmpRotated = ZinImageLib.RotateImage(bmpExtracted, (float)angle);
                //pbImageRotated.Image = bmpRotated;
                gr.DrawImage(bmpRotated, 458, 380);

                gr.Dispose();
                                //Resize về kích thước cố định
                //bmpExtracted = ZinImageLib.Resize(bmpExtracted, ZinImageLib.MajorAxisLen, ZinImageLib.MajorAxisLen * bmpExtracted.Height / bmpExtracted.Width, false);
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

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Test thử hàm
            //MessageBox.Show(ZinImageLib.AngleMajorAndX(6, 1, 6, 6) + " ");
        }

        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
