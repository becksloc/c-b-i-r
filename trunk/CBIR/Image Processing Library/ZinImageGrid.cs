using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Image_Processing_Library
{
    public class ZinImageGrid
    {
        //Các hằng số
        public static int WidthStandard = 192; //độ rộng ảnh === Độ dài trục chính (vì song song với X)
        public static int CellWidth = 24; //độ rộng của Cell grid
        public static int CellHeight = 24; //độ cao của Cell grid
        public static int PercentCovered = 15; //ô lưới bị phủ >= 15%
        public static int Threshold = 5; //số bít cho phép khác nhau



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

            int GridCols = bmp.Width / CellWidth; //Truc chinh
            int GridRows = bmp.Height / CellHeight; //Truc phu
            if (bmp.Height % CellHeight != 0)
                GridRows += 1; //Lam tron len

            for (int j = 0; j < GridRows; j++)
            {
                for (int i = 0; i < GridCols; i++)
                {
                    int cellX1 = i * CellWidth;
                    int cellY1 = j * CellHeight;
                    int cellX2 = i * CellWidth + CellWidth;
                    int cellY2 = j * CellHeight + CellHeight;

                    //Dong cuoi cung
                    if (j == GridRows - 1)
                    {
                        cellY2 = bmp.Height;
                    }

                    //Kiem tra xem phu bao nhieu % grid cell
                    int TotalDot = (cellX2 - cellX1) * (cellY2 - cellY1); //Tong so diem
                    int TotalBlack = CountBlackDot(bmp, cellX1, cellY1, cellX2, cellY2);
                    float TotalPerOverlap = (float)TotalBlack / TotalDot * 100;
                    //Kiem tra %
                    if (TotalPerOverlap >= (float)PercentCovered)
                        BitString += "1";
                    else
                        BitString += "0";
                }
            }

            return BitString;
        }

        //Hàm hiển thị xâu bit theo từng nhóm (mỗi nhóm cách nhau vài dấu cách)
        public static string DisplayBitString(string bitStr)
        {
            //chèn thêm các dấu cách vào giữa các nhóm bít (nhóm bít = 1 dòng)
            string strRes = "";
            int GridCols = WidthStandard / CellWidth;
            for (int i = 0; i < bitStr.Length - 1; i++)
            {

                strRes += bitStr[i];
                if ((i + 1) % GridCols == 0)
                    strRes += "   ";
            }

            return strRes;
        }

        //Tính độ cao trục phụ (so dong cua Grid)
        public static int GetMinorAxisLen(Bitmap bmp)
        {
            int GridRows = bmp.Height / CellHeight; //Truc phu
            if (bmp.Height % CellHeight != 0)
                GridRows += 1;
            return GridRows;
        }
    }
}
