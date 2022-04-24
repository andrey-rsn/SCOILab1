using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal class GavrCriteria : IBinarizationStrategy
    {
        public Bitmap Opeartion(Bitmap inputImage)
        {
            var copyImage = new Bitmap(inputImage.Width, inputImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(copyImage))
            {
                graphics.DrawImage(inputImage, new Point(0, 0));
            }
            //Bitmap inputBitmapImage = new Bitmap(inputImage);

            var inputImg_byte = StaticMethods.BitmapToByteArray(copyImage);

            byte[] img_outByte = new byte[inputImg_byte.Length];
            byte[] img_Brightness= new byte[inputImg_byte.Length/3];

            using (var img_out = new Bitmap(copyImage.Width, copyImage.Height,PixelFormat.Format24bppRgb)) //создаем пустое изображение размером с исходное для сохранения результата
            {
                var index = 0;
                var sum = 0;
                for (int i = 0; i < inputImg_byte.Length - 2; i += 3)
                {

                    int r1 = inputImg_byte[i];
                    int g1 = inputImg_byte[i+1];
                    int b1 = inputImg_byte[i+2];

                    img_Brightness[index]= (byte)StaticMethods.Clamp(0.2125 * r1 + 0.7154 * g1 + 0.0721 * b1, 0, 255);
                    

                    //var r = (byte)Math.Max(r1, r2);
                    //var g = (byte)Math.Max(g1, g2);
                    //var b = (byte)Math.Max(b1, b2);
                    //
                    //img_outByte[i] = r;
                    //img_outByte[i + 1] = g;
                    //img_outByte[i + 2] = b;
                    sum += img_Brightness[index];
                    index++;
                }
                //var sum =img_Brightness.Sum(x => x);
                var t=(double)(sum/(double)(copyImage.Width* copyImage.Height*2));
                index = 0;
                
                for(int i=0;i<img_Brightness.Length;i++)
                {
                    if(img_Brightness[i]<=t)
                    {
                        img_Brightness[i] = 0;
                    }
                    else
                    {
                        img_Brightness[i] = 255;
                    }
                    img_outByte[index] =    img_Brightness[i];
                    img_outByte[index+1] =  img_Brightness[i];
                    img_outByte[index+2] =  img_Brightness[i];
                    index += 3;
                }
                var imgClone = img_out.Clone() as Bitmap;

                StaticMethods.writeImageBytes(imgClone, img_outByte);
                //imgClone.SetResolution(copyImage.HorizontalResolution, copyImage.VerticalResolution);
                
                return imgClone;
            }
             
        }
    }
}
