using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    public static class GradTransform
    {
        public static Bitmap GradTransformImage(Bitmap image,CubicSpline spline)
        {
            byte[] imgOutByte=new byte[3*image.Height*image.Width];
            var inputImage= StaticMethods.getImgBytes(image);
            using (var img_out = new Bitmap(image.Width, image.Height))   //создаем пустое изображение размером с исходное для сохранения результата
            {
                //var imageByte = StaticMethods.BitmapToByteRgbQ(image);
                //попиксельно обрабатываем картинку 
                for (int i = 0; i < inputImage.Length; ++i)
                {

                    byte r1 = inputImage[i];
                    byte g1 = inputImage[i+1];
                    byte b1 = inputImage[i+2];

                    var r = (byte)StaticMethods.Clamp(spline.Interpolate(r1) , 0, 255);
                    var g = (byte)StaticMethods.Clamp(spline.Interpolate(g1) , 0, 255);
                    var b = (byte)StaticMethods.Clamp(spline.Interpolate(b1), 0, 255);

                    imgOutByte[i] = r;
                    imgOutByte[i+1] = g;
                    imgOutByte[i+2] = b;
                    i += 3;
                        
                }
                var imgClone = img_out.Clone() as Bitmap;
                //StaticMethods.BytesToBitmap(imgClone,imgOutByte);
                StaticMethods.writeImageBytes(imgClone, imgOutByte);
                return imgClone;
            }
        }
    }
}
