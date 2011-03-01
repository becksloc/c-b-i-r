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
                //Hien thi anh len pbImageTarget
                Bitmap bmTarget = (Bitmap)Bitmap.FromFile(ofdBrowseImage.FileName);

                //Test 1 so Function trong Lib
                //ZinImageLib.ToBinaryImage(bmTarget, 100);
                //ZinImageLib.ToGrayScale(bmTarget);
                //bmTarget = ZinImageLib.ToGrayScale2(bmTarget);
                //bmTarget = ZinImageLib.RotateImage(bmTarget, 45f);
             
                pbImageTarget.Image = bmTarget;

                //MessageBox.Show(bmTarget.VerticalResolution.ToString() + "--" + bmTarget.HorizontalResolution.ToString());

                //Vẽ lưới 10 * 10 lên ảnh xem nào
                int iCellWidth = bmTarget.Width / 10;
                int iCellHeight = bmTarget.Height / 10;
                for (int i = 0; i < bmTarget.Width; i++)
                    if (i % iCellWidth == 0)
                    {
                        for (int j = 0; j < bmTarget.Height; j++)
                        {
                            bmTarget.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                        }
                    }

                for (int j = 0; j < bmTarget.Height; j++)
                    if (j % iCellHeight == 0)
                        for (int i = 0; i < bmTarget.Width; i++)
                            bmTarget.SetPixel(i, j, Color.Red);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
