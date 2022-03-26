using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace SCOILaba1.Handeling
{
    public static class GradTransform
    {
        public static Bitmap GradTransformImage(Bitmap image,CubicSpline spline)
        {
            
            var inputImage= StaticMethods.BitmapToByteArray(image);
            byte[] imgOutByte=new byte[inputImage.Length];
            using (var img_out = new Bitmap(image.Width, image.Height))   //создаем пустое изображение размером с исходное для сохранения результата
            {
                //var imageByte = StaticMethods.BitmapToByteRgbQ(image);
                //попиксельно обрабатываем картинку 
                for (int i = 0; i < inputImage.Length-2;i+=3)
                {

                    byte r1 = inputImage[i];
                    byte g1 = inputImage[i+1];
                    byte b1 = inputImage[i+2];

                    var r = (byte)StaticMethods.Clamp(255*Math.Pow(spline.Interpolate(r1)/255,2) , 0, 255);
                    var g = (byte)StaticMethods.Clamp(255 * Math.Pow(spline.Interpolate(g1) / 255, 2), 0, 255);
                    var b = (byte)StaticMethods.Clamp(255 * Math.Pow(spline.Interpolate(b1) / 255, 2), 0, 255);

                    imgOutByte[i] = r;
                    imgOutByte[i+1] = g;
                    imgOutByte[i+2] = b;
                    
                        
                }
                var imgClone = img_out.Clone() as Bitmap;
                //StaticMethods.BytesToBitmap(imgClone,imgOutByte);
                StaticMethods.writeImageBytes(imgClone, imgOutByte);
                
                
                
                return imgClone;
            }
        }
    }
}
