using SCOILaba1.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal static class StaticMethods
    {
        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        public unsafe static byte[,,] BitmapToByteRgbQ(Bitmap bmp)
        {
            int width = bmp.Width,
                height = bmp.Height;
            byte[,,] res = new byte[3, height, width];
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                fixed (byte* _res = res)
                {
                    byte* _r = _res, _g = _res + width * height, _b = _res + 2 * width * height;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                        for (int w = 0; w < width; w++)
                        {
                            *_b = *(curpos++); ++_b;
                            *_g = *(curpos++); ++_g;
                            *_r = *(curpos++); ++_r;
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
            return res;
        }

        public static void ResizePicture(ref Bitmap image1, ref Bitmap image2)
        {
            var w = image1.Width;
            var h = image1.Height;
            var w2 = image2.Width;
            var h2 = image2.Height;


            if (w > w2)
            {
                if (h > h2)
                {
                    image2 = new Bitmap(image2, w, h);
                    image2.SetResolution(w, h);
                }
                else if (h < h2)
                {
                    image2 = new Bitmap(image2, w, h2);
                    image1 = new Bitmap(image1, w, h2);
                    image2.SetResolution(w, h2);
                    image1.SetResolution(w, h2);
                }
            }
            else if (w < w2)
            {
                if (h2 > h)
                {
                    image1 = new Bitmap(image1, w2, h2);
                    image1.SetResolution(w2, h2);
                }
                else if (h2 < h)
                {
                    image1 = new Bitmap(image1, w2, h);
                    image2 = new Bitmap(image2, w2, h);
                    image1.SetResolution(w2, h);
                    image2.SetResolution(w2, h);
                }
            }
        }

       //public static void ChoosePixels(byte [,,] pix1, byte[,,]pix2,out int r1, out int b1, out int g1, out int r2, out int g2, out int b2, string colorType1,string colorType2, int transparency1, int transparency2, int i,int j)
       //{
       //    r1 = 0;
       //    r2 = 0;
       //    g1 = 0;
       //    g2 = 0;
       //    b1 = 0;
       //    b2 = 0;
       //    #region picture1
       //    if (colorType1 == "r")
       //    {
       //        r1 = pix1[0, i, j];
       //        g1 = 0;
       //        b1 = 0;
       //    }
       //    else if (colorType1 == "g")
       //    {
       //        r1 = 0;
       //        g1 = pix1[1, i, j];
       //        b1 = 0;
       //    }
       //    else if (colorType1 == "b")
       //    {
       //        r1 = 0;
       //        g1 = 0;
       //        b1 = pix1[2, i, j];
       //    }
       //    else if (colorType1 == "rg")
       //    {
       //        r1 = pix1[0, i, j];
       //        g1 = pix1[1, i, j];
       //        b1 = 0;
       //    }
       //    else if (colorType1 == "gb")
       //    {
       //        r1 = 0;
       //        g1 = pix1[1, i, j];
       //        b1 = pix1[2, i, j];
       //    }
       //    else if (colorType1 == "rb")
       //    {
       //        r1 = pix1[0, i, j];
       //        g1 = 0;
       //        b1 = pix1[2, i, j];
       //    }
       //    else if (colorType1 == "rgb")
       //    {
       //        r1 = pix1[0, i, j];
       //        g1 = pix1[1, i, j];
       //        b1 = pix1[2, i, j];
       //    }
       //    #endregion
       //    #region picture2
       //   if (colorType2 == "r")
       //   {
       //       r2 = pix2[0, i, j];
       //       g2 = 0;
       //       b2 = 0;
       //   }
       //   else if (colorType2 == "g")
       //   {
       //       r2 = 0;
       //       g2 = pix2[1, i, j];
       //       b2 = 0;
       //   }
       //   else if (colorType2 == "b")
       //   {
       //       r2 = 0;
       //       g2 = 0;
       //       b2 = pix2[2, i, j];
       //   }
       //   else if (colorType2 == "rg")
       //   {
       //       r2 = pix2[0, i, j];
       //       g2 = pix2[1, i, j];
       //       b2 = 0;
       //   }
       //   else if (colorType2 == "gb")
       //   {
       //       r2 = 0;
       //       g2 = pix2[1, i, j];
       //       b2 = pix2[2, i, j];
       //   }
       //   else if (colorType2 == "rb")
       //   {
       //       r2 = pix2[0, i, j];
       //       g2 = 0;
       //       b2 = pix2[2, i, j];
       //   }
       //   else if (colorType2 == "rgb")
       //   {
       //       r2 = pix2[0, i, j];
       //       g2 = pix2[1, i, j];
       //       b2 = pix2[2, i, j];
       //   }
       //   #endregion
       //    
       //    r1 = (int)Math.Round(r1 * transparency1*0.01);
       //    g1 = (int)Math.Round(g1 * transparency1*0.01);
       //    b1 = (int)Math.Round(b1 * transparency1*0.01);
       //    r2 = (int)Math.Round(r2 * transparency2 *0.01);
       //    g2 = (int)Math.Round(g2 * transparency2 *0.01);
       //    b2 = (int)Math.Round(b2 * transparency2 *0.01);
       //}

        static public void BytesToBitmap(Bitmap out_image,byte[,,] bytes)
        {
            byte[] imgByte=new byte[bytes.Length];
            var dim1Lenght=bytes.GetLength(0);
            var dim2Lenght = bytes.GetLength(1);
            var dim3Lenght=bytes.GetLength(2);
            int index = 0;
            for(int j=0; j<dim2Lenght; j++)
            {
                for(int k=0; k<dim3Lenght; k++)
                {
                    for(int i=0; i<dim1Lenght; i++)
                    {
                        imgByte[index]=bytes[i,j,k];
                        index++;
                    }
                }
            }

            writeImageBytes(out_image,imgByte);

        }

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {

            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }

        public static byte[] getImgBytes(Bitmap img)
        {
            byte[] bytes = new byte[img.Width * img.Height * 3];  //выделяем память под массив байтов
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.ReadOnly,
                img.PixelFormat);
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);  //копируем байты изображения в массив
            img.UnlockBits(data);   //разблокируем изображение
            return bytes; //возвращаем байты
        }

        public static void writeImageBytes(Bitmap img, byte[] bytes)
        {
            var data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),  //блокируем участок памати, занимаемый изображением
                ImageLockMode.WriteOnly,
                img.PixelFormat);
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length); //копируем байты массива в изображение

            img.UnlockBits(data);  //разблокируем изображение
        }

        public static Point ConvertCoordToPoint(int x,int y)
        {
            return new Point(x*2,Math.Abs(y-255)*2);
        }

        public static Point ConvertPointToNormalPoint(Point point)
        {
            return new Point(point.X / 2, Math.Abs(point.Y - 255) / 2);
        }
        public static List<Point> ConvertListOfPointsToNormalPoints(List<Point> points)
        {
            List<Point> outPoints=new List<Point>();
            foreach(var p in points)
            {
                outPoints.Add( new Point(p.X / 2, Math.Abs(p.Y - 255*2)) ); 
            }
            return outPoints;
            
        }

        public static void DrawCircle(this Graphics g, Circle circle)
        {
            g.DrawEllipse(circle.pen, circle.x - circle.radius, circle.y - circle.radius,
                          circle.radius + circle.radius, circle.radius + circle.radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static bool IsPointInCirle(int x,int y,Circle circle)
        {
            if(((x - circle.x) * (x - circle.x) + (y - circle.y) * (y - circle.y)) < Math.Pow(circle.radius,2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
        {

            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return b;


        }

        public static void ChoosePixels(byte[] image1, byte[] image2, out int r1, out int g1, out int b1, out int r2, out int g2, out int b2, string colorType1, string colorType2, int transparency1, int transparency2, int index)
        {
            r1 = 0;
            r2 = 0;
            g1 = 0;
            g2 = 0;
            b1 = 0;
            b2 = 0;
            #region picture1
            if (colorType1 == "r")
            {
                r1 = Clamp((int)(image1[index]+128*100/100),0,255);
                g1 = Clamp((int)(image1[index+1] - 128 * 100 / 100), 0, 255);
                b1 = Clamp((int)(image1[index+2] - 128 * 100 / 100), 0, 255);
            }
            else if (colorType1 == "g")
            {
                r1 = 0;
                g1 = image1[index + 1];
                b1 = 0;
            }
            else if (colorType1 == "b")
            {
                r1 = 0;
                g1 = 0;
                b1 = image1[index + 2];
            }
            else if (colorType1 == "rg")
            {
                r1 = image1[index];
                g1 = image1[index + 1];
                b1 = 0;
            }
            else if (colorType1 == "gb")
            {
                r1 = 0;
                g1 = image1[index + 1];
                b1 = image1[index + 2];
            }
            else if (colorType1 == "rb")
            {
                r1 = image1[index];
                g1 = 0;
                b1 = image1[index + 2];
            }
            else if (colorType1 == "rgb")
            {
                r1 = image1[index];
                g1 = image1[index + 1];
                b1 = image1[index + 2];
            }
            #endregion
            #region picture2
            if (colorType2 == "r")
            {
                r2 = image2[index];
                g2 = 0;
                b2 = 0;
            }
            else if (colorType2 == "g")
            {
                r2 = 0;
                g2 = image2[index + 1];
                b2 = 0;
            }
            else if (colorType2 == "b")
            {
                r2 = 0;
                g2 = 0;
                b2 = image2[index + 2];
            }
            else if (colorType2 == "rg")
            {
                r2 = image2[index];
                g2 = image2[index + 1];
                b2 = 0;
            }
            else if (colorType2 == "gb")
            {
                r2 = 0;
                g2 = image2[index + 1];
                b2 = image2[index + 2];
            }
            else if (colorType2 == "rb")
            {
                r2 = image2[index];
                g2 = 0;
                b2 = image2[index + 2];
            }
            else if (colorType2 == "rgb")
            {
                r2 = image2[index];
                g2 = image2[index + 1];
                b2 = image2[index + 2];
            }
            #endregion

            r1 = (int)Math.Round(r1 * transparency1 * 0.01);
            g1 = (int)Math.Round(g1 * transparency1 * 0.01);
            b1 = (int)Math.Round(b1 * transparency1 * 0.01);
            r2 = (int)Math.Round(r2 * transparency2 * 0.01);
            g2 = (int)Math.Round(g2 * transparency2 * 0.01);
            b2 = (int)Math.Round(b2 * transparency2 * 0.01);
        }

        public static Complex[] TwoDiscreteTransformation(Complex[] X)
        {
            int N = X.Length;
            Complex[] G = new Complex[N];


            for (int u = 0; u < N; u++)
                for (int k = 0; k < N; k++)
                {
                    double fi = (-2 * Math.PI * u * k) / N;
                    G[u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * X[k]) / N;
                }
            return G;
        }

        public static Complex[] TwoDiscreteTransformationReverse(Complex[] X)
        {
            int N = X.Length;
            Complex[] G = new Complex[N];
            for (int u = 0; u < N; u++)
                for (int k = 0; k < N; k++)
                {
                    double fi = (2 * Math.PI * u * k) / N;
                    G[u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * X[k]);
                }
            return G;
        }
    }
}
