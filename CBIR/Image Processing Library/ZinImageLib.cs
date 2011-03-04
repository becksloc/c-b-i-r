using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace Image_Processing_Library
{
    public class ZinImageLib
    {
        //Các hằng số
        public static int WidthStandard = 192; //độ rộng ảnh === Độ dài trục chính (vì song song với X)
        public static int CellWidth = 24; //độ rộng của Cell grid
        public static int CellHeight = 24; //độ cao của Cell grid
        public static int PercentCovered = 15; //ô lưới bị phủ >= 15%
        public static int Threshold = 5; //số bít cho phép khác nhau

        #region Chuyển sang ảnh nhị phân ( đen trắng )
        public static bool ToBinaryImage(Bitmap b, int n)
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

        public static Bitmap ToGrayScale2(Bitmap b)
        {
            Bitmap bmTemp = new Bitmap(b);
            int x, y;
            Color c;
            Byte bGray;
            for (y = 0; y < b.Height - 1; y++)
            {
                for (x = 0; x < b.Width - 1; x++)
                {
                    c = b.GetPixel(x, y);
                    bGray = Convert.ToByte(c.R * 0.287 + c.G * 0.599 + c.B * 0.114);
                    bmTemp.SetPixel(x, y, Color.FromArgb(bGray, bGray, bGray));
                }
            }
            return bmTemp;
        }

        #endregion

        #region Resize ảnh
        //??? phai dung bBilinear ???
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

        //Resize Image without Pixel collapse in c# - http://www.dotnetspider.com
        public static Bitmap ResizeImage(Bitmap mg, int width, int height)
        {
            Size newSize = new Size(width, height);

            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;

            int x = 0;
            int y = 0;

            bool TrimHeight = false;
            bool TrimWidth = false;

            Bitmap bp = new Bitmap(newSize.Width, newSize.Height);

            if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
            Convert.ToDouble(newSize.Height)))
            {
                ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
                TrimHeight = true;
            }
            else
            {
                ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
                TrimWidth = true;
            }
            myThumbHeight = Math.Ceiling(mg.Height / ratio);
            myThumbWidth = Math.Ceiling(mg.Width / ratio);

            Size thumbSize = new Size((int)myThumbWidth, (int)myThumbHeight);
            if (TrimHeight)
            {
                bp = new Bitmap(newSize.Width, thumbSize.Height);
                TrimHeight = false;
            }
            if (TrimWidth)
            {
                bp = new Bitmap(thumbSize.Width, newSize.Height);
                TrimWidth = false;
            }
            x = (newSize.Width - thumbSize.Width);
            y = (newSize.Height - thumbSize.Height);
            // Had to add System.Drawing class in front of Graphics ---
            System.Drawing.Graphics g = Graphics.FromImage(bp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle rect = new Rectangle(0, 0, thumbSize.Width, thumbSize.Height);
            g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);
            return bp;
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

        /// <summary>
        /// Creates a new Image containing the same image only rotated
        /// </summary>
        /// <param name="image">The <see cref="System.Drawing.Image"/> to rotate</param>
        /// <param name="angle">The amount to rotate the image, clockwise, in degrees</param>
        /// <returns>A new <see cref="System.Drawing.Bitmap"/> of the same size rotated.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <see cref="image"/> is null.</exception>
        public static Bitmap RotateImage2(Image image, float angle)
        {
            return RotateImage2(image, new PointF((float)image.Width / 2, (float)image.Height / 2), angle);
        }

        /// <summary>
        /// Creates a new Image containing the same image only rotated
        /// </summary>
        /// <param name="image">The <see cref="System.Drawing.Image"/> to rotate</param>
        /// <param name="offset">The position to rotate from.</param>
        /// <param name="angle">The amount to rotate the image, clockwise, in degrees</param>
        /// <returns>A new <see cref="System.Drawing.Bitmap"/> of the same size rotated.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <see cref="image"/> is null.</exception>
        public static Bitmap RotateImage2(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }


        /// <summary>
        /// Chiếu ảnh lên trục X (dồn cột)
        /// </summary>
        /// <param name="ArrPixel"></param>
        /// <param name="b"></param>
        private static void FindOnAxisX(out int MinX, out int MaxX, Bitmap b)
        {
            int[] ArrPixel = new int[b.Width];
            int temp;

            //Chiếu ảnh lên trục X
            for (int i = 0; i < b.Width; i++)
            {
                temp = 0;
                for (int j = 0; j < b.Height; j++)
                    if (b.GetPixel(i, j).R + b.GetPixel(i, j).G + b.GetPixel(i, j).B == 0) //điểm đen
                    {
                        temp++;
                        break; //chi can temp = 1 (khac 0) la duoc roi
                    }

                ArrPixel[i] = temp;
            }

            //Tìm vị trí MinX, MaxX có chứa điểm ảnh đối tượng
            MinX = 0;
            MaxX = ArrPixel.Length - 1; //phần tử cuối cùng của mảng
            while (ArrPixel[MinX] == 0) MinX++;
            while (ArrPixel[MaxX] == 0) MaxX--;
        }

        /// <summary>
        /// Chiếu ảnh lên trục Y (dồn hàng)
        /// </summary>
        /// <param name="ArrPixel"></param>
        /// <param name="b"></param>
        private static void FindOnAxisY(out int MinY, out int MaxY, Bitmap b)
        {
            int[] ArrPixel = new int[b.Height];
            int temp;

            //Chiếu ảnh lên trục Y
            for (int j = 0; j < b.Height; j++)
            {
                temp = 0;
                for (int i = 0; i < b.Width; i++)
                    if (b.GetPixel(i, j).R + b.GetPixel(i, j).G + b.GetPixel(i, j).B == 0) //điểm đen
                    {
                        temp++;
                        break; //chi can temp = 1 (khac 0) la duoc roi
                    }

                ArrPixel[j] = temp;
            }

            //Tìm vị trí MinY, MaxY có chứa điểm ảnh đối tượng
            MinY = 0;
            MaxY = ArrPixel.Length - 1; //phần tử cuối cùng của mảng
            while (ArrPixel[MinY] == 0) MinY++;
            while (ArrPixel[MaxY] == 0) MaxY--;
        }

        /// <summary>
        /// Tìm HCN cơ sở bao khít đối tượng (shape), có độ dài = trục chính của đối tượng
        /// (Tạm thời chỉ sử dụng ảnh Nhị phân nền trắng, hình đen)
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private static Rectangle FindRectangleBound(Bitmap b)
        {
            int MinX, MaxX, MinY, MaxY;

            //Chiếu ảnh lên trục X --> tim duoc hinh chieu tren truc X
            FindOnAxisX(out MinX, out MaxX, b);

            //Chiếu ảnh lên trục Y --> tim duoc hinh chieu tren truc Y
            FindOnAxisY(out MinY, out MaxY, b);

            Rectangle recResult = new Rectangle(MinX, MinY, MaxX - MinX, MaxY - MinY);

            return recResult;
        }

        /// <summary>
        /// Trích hình chữ nhật phủ đối tượng từ ảnh gốc
        /// </summary>
        /// <param name="img">ảnh gốc</param>
        /// <param name="width">độ rộng của HCN</param>
        /// <param name="height">độ cao của HCN</param>
        /// <param name="x">Tọa độ x bắt đầu HCN</param>
        /// <param name="y">Tọa độ y bắt đầu HCN</param>
        /// <returns>Bitmap hoặc Image</returns>
        public static Bitmap ExtractShape(Bitmap src)
        {
            Rectangle rec = FindRectangleBound(src);
            Bitmap dst = src.Clone(rec, src.PixelFormat);
            return dst;
        }

        //Tìm góc giữa trục chính và trục X (chú ý: hàm xoay chỉ xoay theo chiều kim đồng hồ)
        public static double AngleMajorAndX(int x1, int y1, int x2, int y2)
        {
            int a = Math.Abs(x1 - x2);
            int b = Math.Abs(y1 - y2);

            double angle;

            if (b == 0)
                angle = 0;
            else
                angle = 90 - Math.Atan((float)a / b) * 180 / Math.PI; //Chu y: phai ep kieu Float

            //Xét trường hợp xoay hướng nào cho phù hợp
            if (x1 < x2 && y1 < y2)
                angle = -angle;

            return angle;
        }

        //Tô đen vùng trong hình dạng
        public static void FillSolidBlack(Bitmap bmp)
        {
            //Duyệt từng cột (theo trục X)
            for (int i = 0; i < bmp.Width; i++)
            {
                //Duyệt từ trên
                int k = 0;
                while (k < bmp.Height && bmp.GetPixel(i, k).R == 255) k++; //gặp điểm đen (biên ảnh) thì dừng
                //Duyệt từ dưới
                int h = bmp.Height - 1;
                while (h >= 0 && bmp.GetPixel(i, h).R == 255) h--; //gặp điểm đen (biên ảnh) thì dừng
                //Tô đen vùng trong hình
                for (int j = k; j < h; j++)
                    bmp.SetPixel(i, j, Color.Black);
            }
        }

        //Đổi điểm trong suốt --> trắng
        public static void TransparentToWhite(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    if (bmp.GetPixel(i, j).A == 0)
                        bmp.SetPixel(i, j, Color.White);
        }


        //Đếm số điểm đen trong 1 cell
        private static int CountBlackDot(Bitmap bmpCell, int cellX1, int cellY1, int cellX2, int cellY2)
        {
            int count = 0;
            for (int i = cellX1; i < cellX2; i++)
                for (int j = cellY1; j < cellY2; j++)
                    if (bmpCell.GetPixel(i, j).R == 0)
                        count++;
            return count;
        }

        //Tìm xâu bít
        public static string GetBitString(Bitmap bmp)
        {
            string BitString = "";
            //duyet tung Cell

            int GridCols = bmp.Width / ZinImageLib.CellWidth; //Truc chinh
            int GridRows = bmp.Height / ZinImageLib.CellHeight; //Truc phu
            if (bmp.Height % ZinImageLib.CellHeight != 0)
                GridRows += 1;

            for (int j = 0; j < GridRows; j++)
            {
                for (int i = 0; i < GridCols; i++)
                {
                    int cellX1 = i * ZinImageLib.CellWidth;
                    int cellY1 = j * ZinImageLib.CellHeight;
                    int cellX2 = i * ZinImageLib.CellWidth + ZinImageLib.CellWidth;
                    int cellY2 = j * ZinImageLib.CellHeight + ZinImageLib.CellHeight;

                    //Dong cuoi cung
                    if (j == GridRows - 1)
                    {
                        cellY2 = bmp.Height;
                    }


                    if (CountBlackDot(bmp, cellX1, cellY1, cellX2, cellY2) > ZinImageLib.PercentCovered)
                        BitString += "1";
                    else
                        BitString += "0";
                }

                BitString += "   ";
            }

            return BitString;
        }

        //Tính độ cao trục phụ (so dong cua Grid)
        public static int GetMinorAxisLen(Bitmap bmp)
        {
            int GridRows = bmp.Height / ZinImageLib.CellHeight; //Truc phu
            if (bmp.Height % ZinImageLib.CellHeight != 0)
                GridRows += 1;
            return GridRows;
        }

    }

}
