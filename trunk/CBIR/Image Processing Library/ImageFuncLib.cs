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

            //Chuyen diem anh vao mang arrImage: cot 0-> (gia tri 1->diem anh den, 0->diem anh trang)
            //cot 1-> x; cot 2->y
            int [,] arrImage = new int [20000,3];
            int i, j ,k,n;
            k=0;
            for (i = 0; i < bmQuery.Width; i++)
                for (j = 0; j < bmQuery.Height; j++)
                    if (bmQuery.GetPixel(i, j).R == 0 && bmQuery.GetPixel(i, j).B == 0 && bmQuery.GetPixel(i, j).G == 0)
                    {   arrImage[k, 0] = 1;
                        arrImage[k, 1] = i;
                        arrImage[k, 2] = j;
                        k++;
                    }
            n=k;    //Tong so diem anh

            //////Tim 2 diem xa nhat
            double[] arrMax = new double[20000]; //Mang luu cac gia tri max
           // int xt1, yt1, xt2, yt2; //Toa do 2 diem xa nhat
            double max=0;

            for (i = 0; i < n; i++)
            {   
                for (j = 0; j < n; j++)
                {
                    arrMax[j] = Distance2Point(arrImage[i, 1], arrImage[i, 2], arrImage[j, 1], arrImage[j, 2]);
                    if (max<arrMax[j]) 
                    {   max=arrMax[j];
                        x1 = arrImage[i, 1];
                        y1 = arrImage[i, 2];
                        x2 = arrImage[j, 1];
                        y2 = arrImage[j, 2];
                    }
                }
            }
  /*          
            
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
    */
        }

    }
}
