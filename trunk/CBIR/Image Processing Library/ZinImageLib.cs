using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


namespace Image_Processing_Library
{
    public class ZinImageLib
    {
        #region Chuyển sang ảnh nhị phân ( đen trắng )
        public static bool ToBinary(Bitmap b, int n)
        {
            BitmapData data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;
            unsafe
            {
                byte* p = (byte*)data.Scan0;
                int nwidth = b.Width * 3;
                int nOffset = stride - b.Width * 3;
                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        if (p[0] > n || p[1] > n || p[2] > n)
                        {
                            p[0] = p[1] = p[2] = 255;
                        }
                        else
                        {
                            p[0] = p[1] = p[2] = 0;
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }
            b.UnlockBits(data);
            return true;
        }
        #endregion

        #region Hàm tạo ảnh xám (GrayScale)

        public static bool ToGrayScale(Bitmap b)
        {
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //Phương thức LockBits sẽ chuyển từ 1 ảnh, sang 1 vùng nhớ (bmData)
            int stride = bmData.Stride;
            //bmData.Stride: số byte thực sự mà máy tính lưu trũ mỗi hàng của ảnh.
            IntPtr scan0 = bmData.Scan0;
            //bmData.Scan0: Cái này chỉ ra địa chỉ pixel đầu tiên của ảnh mà bmData quản lý.
            unsafe
            {
                byte* p = (byte*)bmData.Scan0;
                // con trỏ p về vị trí đầu tiên trên ảnh
                int nOffset = stride - b.Width * 3;
                //nOffset chính là cái rìa của bức ảnh, khi con trỏ xử lý đến pixel cuối cùng của hàng, thì muốn xuống 
                //hàng kế tiếp, ta phải bỏ qua cái rìa này bằng cách cộng thêm địa chỉ con trỏ với nOffset

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);

                        p += 3;// 2 pixel ảnh cách nhau 3 byte
                    }//xong 1 hàng
                    p += nOffset;
                    //chuyển con trỏ sang hàng mới
                }
            }

            b.UnlockBits(bmData);//giải phóng biến BitmapData 

            return true;
        }
        #endregion

        #region Resize ảnh
        public static Bitmap Resize(Bitmap b, int nWidth, int nHeight, bool bBilinear)
        {
            Bitmap btemp = (Bitmap)b.Clone();
            b = new Bitmap(nWidth, nHeight, btemp.PixelFormat);
            double nXFactor = (double)btemp.Width / (double)nWidth;
            double nYFactor = (double)btemp.Height / (double)nHeight;
            if (bBilinear)
            {
                double fraction_x, fraction_y, one_minus_x, one_minus_y;
                int ceil_x, ceil_y, floor_x, floor_y;
                Color c1 = new Color();
                Color c2 = new Color();
                Color c3 = new Color();
                Color c4 = new Color();
                byte red, green, blue;
                byte b1, b2;
                for (int x = 0; x < b.Width; ++x)
                {
                    for (int y = 0; y < b.Height; ++y)
                    {
                        //Set up
                        floor_x = (int)Math.Floor(x * nXFactor);
                        //Làm tròn cho tọa độ x của điểm ảnh 
                        floor_y = (int)Math.Floor(y * nYFactor);
                        //làm tròn cho tọa độ y của điểm ảnh 
                        ceil_x = floor_x + 1;
                        if (ceil_x >= btemp.Width) ceil_x = floor_x;
                        ceil_y = floor_y + 1;
                        if (ceil_y >= btemp.Height) ceil_y = floor_y;
                        fraction_x = (x * nXFactor) - floor_x;
                        fraction_y = (y * nYFactor) - floor_y;
                        one_minus_x = 1.0 - fraction_x;
                        one_minus_y = 1.0 - fraction_y;

                        // Lấy giá trị màu của các pixel xung quanh pixel đang xét không có thực
                        c1 = btemp.GetPixel(floor_x, floor_y);

                        c2 = btemp.GetPixel(ceil_x, floor_y);

                        c3 = btemp.GetPixel(floor_x, ceil_y);

                        c4 = btemp.GetPixel(ceil_x, ceil_y);

                        // Cài đặt giá trị màu cho pixel đang xét
                        // Blue
                        b1 = (byte)(one_minus_x * c1.B + fraction_x * c2.B);

                        b2 = (byte)(one_minus_x * c3.B + fraction_x * c4.B);

                        blue = (byte)(one_minus_y * (double)(b1) + fraction_y * (double)(b2));

                        // Green
                        b1 = (byte)(one_minus_x * c1.G + fraction_x * c2.G);

                        b2 = (byte)(one_minus_x * c3.G + fraction_x * c4.G);

                        green = (byte)(one_minus_y * (double)(b1) + fraction_y * (double)(b2));

                        // Red
                        b1 = (byte)(one_minus_x * c1.R + fraction_x * c2.R);

                        b2 = (byte)(one_minus_x * c3.R + fraction_x * c4.R);

                        red = (byte)(one_minus_y * (double)(b1) + fraction_y * (double)(b2));

                        b.SetPixel(x, y, System.Drawing.Color.FromArgb(255, red, green, blue));
                    }
                }
            }
            else
            {
                for (int x = 0; x < btemp.Width; ++x)
                    for (int y = 0; y < btemp.Height; ++y)
                    {
                        b.SetPixel(x, y, btemp.GetPixel((int)(Math.Floor(x * nXFactor)), (int)(Math.Floor(y * nYFactor))));
                    }
            }
            return b;
        }
        #endregion

        /// <summary>
        /// Creates a new Image containing the same image only rotated
        /// </summary>
        /// <param name="image">The <see cref="System.Drawing.Image"/> to rotate</param>
        /// <param name="angle">The amount to rotate the image, clockwise, in degrees</param>
        /// <returns>A new <see cref="System.Drawing.Bitmap"/> that is just large enough
        /// to contain the rotated image without cutting any corners off.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <see cref="image"/> is null.</exception>
        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            const double pi2 = Math.PI / 2.0;

            // Why can't C# allow these to be const, or at least readonly
            // *sigh*  I'm starting to talk like Christian Graus :omg:
            double oldWidth = (double)image.Width;
            double oldHeight = (double)image.Height;

            // Convert degrees to radians
            double theta = ((double)angle) * Math.PI / 180.0;
            double locked_theta = theta;

            // Ensure theta is now [0, 2pi)
            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight; // The newWidth/newHeight expressed as ints

            #region Explaination of the calculations
            /*
			 * The trig involved in calculating the new width and height
			 * is fairly simple; the hard part was remembering that when 
			 * PI/2 <= theta <= PI and 3PI/2 <= theta < 2PI the width and 
			 * height are switched.
			 * 
			 * When you rotate a rectangle, r, the bounding box surrounding r
			 * contains for right-triangles of empty space.  Each of the 
			 * triangles hypotenuse's are a known length, either the width or
			 * the height of r.  Because we know the length of the hypotenuse
			 * and we have a known angle of rotation, we can use the trig
			 * function identities to find the length of the other two sides.
			 * 
			 * sine = opposite/hypotenuse
			 * cosine = adjacent/hypotenuse
			 * 
			 * solving for the unknown we get
			 * 
			 * opposite = sine * hypotenuse
			 * adjacent = cosine * hypotenuse
			 * 
			 * Another interesting point about these triangles is that there
			 * are only two different triangles. The proof for which is easy
			 * to see, but its been too long since I've written a proof that
			 * I can't explain it well enough to want to publish it.  
			 * 
			 * Just trust me when I say the triangles formed by the lengths 
			 * width are always the same (for a given theta) and the same 
			 * goes for the height of r.
			 * 
			 * Rather than associate the opposite/adjacent sides with the
			 * width and height of the original bitmap, I'll associate them
			 * based on their position.
			 * 
			 * adjacent/oppositeTop will refer to the triangles making up the 
			 * upper right and lower left corners
			 * 
			 * adjacent/oppositeBottom will refer to the triangles making up 
			 * the upper left and lower right corners
			 * 
			 * The names are based on the right side corners, because thats 
			 * where I did my work on paper (the right side).
			 * 
			 * Now if you draw this out, you will see that the width of the 
			 * bounding box is calculated by adding together adjacentTop and 
			 * oppositeBottom while the height is calculate by adding 
			 * together adjacentBottom and oppositeTop.
			 */
            #endregion

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            // We need to calculate the sides of the triangles based
            // on how much rotation is being done to the bitmap.
            //   Refer to the first paragraph in the explaination above for 
            //   reasons why.
            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int)Math.Ceiling(newWidth);
            nHeight = (int)Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // This array will be used to pass in the three points that 
                // make up the rotated image
                Point[] points;

                /*
                 * The values of opposite/adjacentTop/Bottom are referring to 
                 * fixed locations instead of in relation to the
                 * rotating image so I need to change which values are used
                 * based on the how much the image is rotating.
                 * 
                 * For each point, one of the coordinates will always be 0, 
                 * nWidth, or nHeight.  This because the Bitmap we are drawing on
                 * is the bounding box for the rotated bitmap.  If both of the 
                 * corrdinates for any of the given points wasn't in the set above
                 * then the bitmap we are drawing on WOULDN'T be the bounding box
                 * as required.
                 */
                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[] { 
											 new Point( (int) oppositeBottom, 0 ), 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( 0, (int) adjacentBottom )
										 };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[] { 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( (int) adjacentTop, nHeight ),
											 new Point( (int) oppositeBottom, 0 )						 
										 };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[] { 
											 new Point( (int) adjacentTop, nHeight ), 
											 new Point( 0, (int) adjacentBottom ),
											 new Point( nWidth, (int) oppositeTop )
										 };
                }
                else
                {
                    points = new Point[] { 
											 new Point( 0, (int) adjacentBottom ), 
											 new Point( (int) oppositeBottom, 0 ),
											 new Point( (int) adjacentTop, nHeight )		
										 };
                }

                g.DrawImage(image, points);
            }

            return rotatedBmp;
        }

    }
}
