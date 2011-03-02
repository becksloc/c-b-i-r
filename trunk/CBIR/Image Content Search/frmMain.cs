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
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdBrowseImage.ShowDialog(this) == DialogResult.OK)
            {
                //Hien thi anh len pbQueryImage
                Bitmap bmQuery = (Bitmap)Bitmap.FromFile(ofdBrowseImage.FileName);

                //Test 1 so Function trong Lib
                //ZinImageLib.ToBinaryImage(bmQuery, 100);
                //ZinImageLib.ToGrayScale(bmQuery);
                //bmQuery = ZinImageLib.ToGrayScale2(bmQuery);
                //bmQuery = ZinImageLib.RotateImage(bmQuery, 45f);
             
                pbQueryImage.Image = bmQuery;

                //MessageBox.Show(bmQuery.VerticalResolution.ToString() + "--" + bmQuery.HorizontalResolution.ToString());

                //Vẽ lưới 10 * 10 lên ảnh xem nào
                int iCellWidth = bmQuery.Width / ZinImageLib.GridCols;
                int iCellHeight = bmQuery.Height / ZinImageLib.GridRows;
                for (int i = 0; i < bmQuery.Width; i++)
                    if (i % iCellWidth == 0)
                    {
                        for (int j = 0; j < bmQuery.Height; j++)
                        {
                            bmQuery.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                        }
                    }

                for (int j = 0; j < bmQuery.Height; j++)
                    if (j % iCellHeight == 0)
                        for (int i = 0; i < bmQuery.Width; i++)
                            bmQuery.SetPixel(i, j, Color.Red);
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
    }
}
