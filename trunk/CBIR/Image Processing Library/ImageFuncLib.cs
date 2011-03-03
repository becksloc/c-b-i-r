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
 
        }
        
        
        public static String getImgString(int cW, int cH, int per,Bitmap bm)
        {
            string s;
            int i, j, n,tong,k;
            s="";
            k = 0;
            byte[] arrImage=new byte[140000];
            
            //Luu cac diem anh vao mang
            for(i=0; i<cH*16; i++)
                for(j=0; j<cW*16; j++)
                {
                    if (bm.GetPixel(i, j).R == 0 && bm.GetPixel(i, j).B == 0 && bm.GetPixel(i, j).G == 0)
                        arrImage[k] = 1;
                    else
                        arrImage[k] = 0;
                    k++;
                }

            n=k;
          
            k=0;
            while(k<n/(cW*cH))
            {
                tong = 0;
                for (i = k*cH*cW ; i < (k + 1) * cH*cW; i++)
                    if (arrImage[i] == 1)
                        tong = tong + 1;
                if ((float)tong / (cH * cW) > (float)per/100)
                    s = s + "1";
                else
                    s = s + 0;
                
                k++;
            }
            return s;
           
        }
    }
}
