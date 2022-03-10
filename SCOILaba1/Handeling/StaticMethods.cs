using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

        public static void ChoosePixels(byte [,,] pix1, byte[,,]pix2,out int r1, out int b1, out int g1, out int r2, out int g2, out int b2, string colorType1,string colorType2, int transparency1, int transparency2, int i,int j)
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
                r1 = pix1[0, i, j];
                g1 = 0;
                b1 = 0;
            }
            else if (colorType1 == "g")
            {
                r1 = 0;
                g1 = pix1[1, i, j];
                b1 = 0;
            }
            else if (colorType1 == "b")
            {
                r1 = 0;
                g1 = 0;
                b1 = pix1[2, i, j];
            }
            else if (colorType1 == "rg")
            {
                r1 = pix1[0, i, j];
                g1 = pix1[1, i, j];
                b1 = 0;
            }
            else if (colorType1 == "gb")
            {
                r1 = 0;
                g1 = pix1[1, i, j];
                b1 = pix1[2, i, j];
            }
            else if (colorType1 == "rb")
            {
                r1 = pix1[0, i, j];
                g1 = 0;
                b1 = pix1[2, i, j];
            }
            else if (colorType1 == "rgb")
            {
                r1 = pix1[0, i, j];
                g1 = pix1[1, i, j];
                b1 = pix1[2, i, j];
            }
            #endregion
            #region picture2
            if (colorType2 == "r")
            {
                r2 = pix2[0, i, j];
                g2 = 0;
                b2 = 0;
            }
            else if (colorType2 == "g")
            {
                r2 = 0;
                g2 = pix2[1, i, j];
                b2 = 0;
            }
            else if (colorType2 == "b")
            {
                r2 = 0;
                g2 = 0;
                b2 = pix2[2, i, j];
            }
            else if (colorType2 == "rg")
            {
                r2 = pix2[0, i, j];
                g2 = pix2[1, i, j];
                b2 = 0;
            }
            else if (colorType2 == "gb")
            {
                r2 = 0;
                g2 = pix2[1, i, j];
                b2 = pix2[2, i, j];
            }
            else if (colorType2 == "rb")
            {
                r2 = pix2[0, i, j];
                g2 = 0;
                b2 = pix2[2, i, j];
            }
            else if (colorType2 == "rgb")
            {
                r2 = pix2[0, i, j];
                g2 = pix2[1, i, j];
                b2 = pix2[2, i, j];
            }
            #endregion
            
            r1 = (int)Math.Round(r1 * transparency1*0.01);
            g1 = (int)Math.Round(g1 * transparency1*0.01);
            b1 = (int)Math.Round(b1 * transparency1*0.01);
            r2 = (int)Math.Round(r2 * transparency2 *0.01);
            g2 = (int)Math.Round(g2 * transparency2 *0.01);
            b2 = (int)Math.Round(b2 * transparency2 *0.01);
        }

        static public Bitmap BytesToBitmap(byte[,,] bytes)
        {
            byte[] imgByte=new byte[bytes.Length];
            var dim1Lenght=bytes.GetLength(0);
            var dim2Lenght = bytes.GetLength(1);
            var dim3Lenght=bytes.GetLength(2);
            int index = 0;
            for(int k=0; k<dim3Lenght; k++)
            {
                for(int j=0; j<dim2Lenght; j++)
                {
                    for(int i=0; i<dim1Lenght; i++)
                    {
                        imgByte[index]=bytes[i,j,k];
                        index++;
                    }
                }
            }
            //Bitmap bmp;
            //using (var ms = new MemoryStream(imgByte))
            //{
            //    bmp = new Bitmap(ms);
            //}
            MemoryStream ms = new MemoryStream(imgByte);
            Bitmap bmp = (Bitmap)Image.FromStream(ms);
            return bmp;

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
    }
}
