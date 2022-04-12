using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    public static class Histogram
    {
        public static  Bitmap CreateHistogramm (Bitmap image)
        {
            var inputImg=new Bitmap(image);
            var inputImage = StaticMethods.BitmapToByteArray(inputImg);
            byte[] imgOutByte = new byte[inputImage.Length];
            int[] N=new int[256];
            using (var img_out = new Bitmap(256, 162))   //создаем пустое изображение размером с исходное для сохранения результата
            {
                //var imageByte = StaticMethods.BitmapToByteRgbQ(image);
                //попиксельно обрабатываем картинку 
                for (int i = 0; i < inputImage.Length - 2; i += 3)
                {

                    byte r1 = inputImage[i];
                    byte g1 = inputImage[i + 1];
                    byte b1 = inputImage[i + 2];

                    int c = (int)((r1 + g1 + b1) / 3);
                    N[c]++;
                    //var r = (byte)StaticMethods.Clamp(255 * Math.Pow(spline.Interpolate(r1) / 255, 2), 0, 255);
                    //var g = (byte)StaticMethods.Clamp(255 * Math.Pow(spline.Interpolate(g1) / 255, 2), 0, 255);
                    //var b = (byte)StaticMethods.Clamp(255 * Math.Pow(spline.Interpolate(b1) / 255, 2), 0, 255);

                    //imgOutByte[i] = r;
                    //imgOutByte[i + 1] = g;
                    //imgOutByte[i + 2] = b;
                    //

                }
                var max = N.Max();
                float k = img_out.Height /(float)max;
                Graphics g = Graphics.FromImage(img_out);
                g.FillRectangle(Brushes.White, 0, 0, 256, 162);
                var balckPen = new Pen(Color.Black,1);
                for(int i=0;i<255;i++)
                {
                    PointF A = new PointF(i,img_out.Height-1);
                    PointF B = new PointF(i,(float)(img_out.Height - 1-N[i]*k));
                    g.DrawLine(balckPen, A, B);
                }
                var imgClone = img_out.Clone() as Bitmap;
                return imgClone;
            }
        }
    }
}
