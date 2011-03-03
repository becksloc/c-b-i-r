using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Image_Processing_Library
{
    public class ImageFuncLib
    {
        public static double Distance2Point(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public static  void getPoint(out int x1, out int y1, out int x2, out int y2, Bitmap bmQuery)
        {
            x1 = 0; y1 = 0; x2 = 0; y2 = 0;

            //Chuyen diem anh vao mang arrImage (gia tri 1->diem anh den, 0->diem anh trang)
            byte[,] arrImage = new byte[40000, 40000];
            int i, j;
            for (i = 0; i < bmQuery.Width; i++)
                for (j = 0; j < bmQuery.Height; j++)
                    if (bmQuery.GetPixel(i, j).R == 0 && bmQuery.GetPixel(i, j).B == 0 && bmQuery.GetPixel(i, j).G == 0)
                        arrImage[i, j] = 1;
                    else
                        arrImage[i, j] = 0;

            //////Tim 2 diem xa nhat
            //Luu lai toa do cac diem anh den (gia tri 1)
            int k = 0, n;
            int[,] arrTg = new int[1000000, 2];
            for (i = 0; i < bmQuery.Width; i++)
                for (j = 0; j < bmQuery.Height; j++)
                    if (arrImage[i, j] == 1)
                    {
                        arrTg[k, 0] = i; arrTg[k, 1] = j;
                        k++;
                    }

            n = k;
            double[] arrKC = new double[10000000];
            int[,] arrToado = new int[10000000, 4]; //Mang luu toa do x,y cua 2 diem khi tinh khoang cach

            k = 0;
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    arrKC[k] = Distance2Point(arrTg[i, 0], arrTg[i, 1], arrTg[j, 0], arrTg[j, 1]);
                    arrToado[k, 0] = arrTg[i, 0]; arrToado[k, 1] = arrTg[i, 1];
                    arrToado[k, 2] = arrTg[j, 0]; arrToado[k, 3] = arrTg[j, 1];
                    k++;
                }
            double max = 0;
            n = k;
            for (i = 0; i < n; i++)
                if (max < arrKC[i])
                {
                    max = arrKC[i];
                    x1 = arrToado[i, 0]; y1 = arrToado[i, 1];
                    x2 = arrToado[i, 2]; y2 = arrToado[i, 3];
                }
        }
    }
}
