using MathNet.Numerics.Interpolation;
using SCOILaba1.Structures;
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
            var copyImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(copyImage))
            {
                graphics.DrawImage(image, new Point(0, 0));
            }
            var inputImage= StaticMethods.BitmapToByteArray(copyImage);
            byte[] imgOutByte=new byte[inputImage.Length];
            using (var img_out = new Bitmap(copyImage.Width, copyImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))   //создаем пустое изображение размером с исходное для сохранения результата
            {
                //var imageByte = StaticMethods.BitmapToByteRgbQ(image);
                //попиксельно обрабатываем картинку 
                for (int i = 0; i < inputImage.Length-2;i+=3)
                {

                    byte r1 = inputImage[i];
                    byte g1 = inputImage[i+1];
                    byte b1 = inputImage[i+2];
                    var a = spline.Interpolate(r1)/2;
                    var r = (byte)StaticMethods.Clamp(spline.Interpolate(r1)/2 , 0, 255);
                    var g = (byte)StaticMethods.Clamp(spline.Interpolate(g1) /2 , 0, 255);
                    var b = (byte)StaticMethods.Clamp(spline.Interpolate(b1) /2, 0, 255);

                    //var r = (byte)StaticMethods.Clamp(255.0*  Math.Pow(spline.ApplyFunc(r1)/255.0,1) , 0, 255);
                    //var g = (byte)StaticMethods.Clamp(255.0 * Math.Pow(spline.ApplyFunc(g1) / 255.0, 1), 0, 255);
                    //var b = (byte)StaticMethods.Clamp(255.0 * Math.Pow(spline.ApplyFunc(b1) / 255.0, 1), 0, 255);

                    //var r = (byte)StaticMethods.Clamp(255.0 * Math.Pow(r1 / 255.0, 2), 0, 255);
                    //var g = (byte)StaticMethods.Clamp(255.0 * Math.Pow(g1 / 255.0, 2), 0, 255);
                    //var b = (byte)StaticMethods.Clamp(255.0 * Math.Pow(b1 / 255.0, 2), 0, 255);


                    //var r = (byte)StaticMethods.Clamp(spline.ApplyFunc(r1), 0, 255);
                    //var g = (byte)StaticMethods.Clamp(spline.ApplyFunc(g1), 0, 255);
                    //var b = (byte)StaticMethods.Clamp(spline.ApplyFunc(b1), 0, 255);

                    //var r = (byte)StaticMethods.Clamp(r1+100, 0, 255);
                    //var g = (byte)StaticMethods.Clamp(g1+10, 0, 255);
                    //var b = (byte)StaticMethods.Clamp(b1+160, 0, 255);

                    //if(string.Equals(function,"y=x"))
                    //{
                    //    imgOutByte[i] =     r1;
                    //    imgOutByte[i + 1] = g1;
                    //    imgOutByte[i + 2] = b1;
                    //}
                    //else if(string.Equals(function, "y=x^2"))
                    //{
                    //    imgOutByte[i] = (byte)StaticMethods.Clamp(255.0 * Math.Pow(r1 / 255.0, 2), 0, 255);
                    //    imgOutByte[i + 1] = (byte)StaticMethods.Clamp(255.0 * Math.Pow(g1 / 255.0, 2), 0, 255);
                    //    imgOutByte[i + 2] = (byte)StaticMethods.Clamp(255.0 * Math.Pow(b1 / 255.0, 2), 0, 255);
                    //}
                    //else if (string.Equals(function, "y=sqrt((200x^2/4)-200)"))
                    //{
                    //    imgOutByte[i] = (byte)StaticMethods.Clamp(Math.Sqrt((((200.0*r1*r1/4.0)-200.0)/255.0)*255.0), 0, 255);
                    //    imgOutByte[i + 1] = (byte)StaticMethods.Clamp(Math.Sqrt((((200.0 * g1 * g1 / 4.0) - 200.0) / 255.0) * 255.0), 0, 255);
                    //    imgOutByte[i + 2] = (byte)StaticMethods.Clamp(Math.Sqrt((((200.0 * b1 * b1 / 4.0) - 200.0) / 255.0) * 255.0), 0, 255);
                    //}
                    //else if (string.Equals(function, "50x^3-x^2+x"))
                    //{
                    //    imgOutByte[i] = (byte)StaticMethods.Clamp((50.0*Math.Pow(r1/255.0,3)-Math.Pow(r1/255.0,2)+r1/255.0)*255.0, 0, 255);
                    //    imgOutByte[i + 1] = (byte)StaticMethods.Clamp((50.0 * Math.Pow(g1 / 255.0, 3) - Math.Pow(g1 / 255.0, 2) + g1 / 255.0)*255.0, 0, 255);
                    //    imgOutByte[i + 2] = (byte)StaticMethods.Clamp((50.0 * Math.Pow(b1 / 255.0, 3) - Math.Pow(b1 / 255.0, 2) + b1 / 255.0)*255.0, 0, 255);
                    //}
                    //else if (string.Equals(function, "y=(x-55)^2+55"))
                    //{
                    //    imgOutByte[i] = (byte)StaticMethods.Clamp((-0.0025*Math.Pow(r1/255.0,2)+0.5433*r1/255.0+14.4352/255.0)*255.0, 0, 255);
                    //    imgOutByte[i + 1] = (byte)StaticMethods.Clamp((-0.0025 * Math.Pow(g1 / 255.0, 2) + 0.5433 * g1 / 255.0 + 14.4352 / 255.0) * 255.0, 0, 255);
                    //    imgOutByte[i + 2] = (byte)StaticMethods.Clamp((-0.0025*Math.Pow(b1/255.0,2)+0.5433*b1/255.0+14.4352/255.0)*255.0, 0, 255);
                    //}
                    //else{
                    //
                    //    imgOutByte[i] = r1;
                    //    imgOutByte[i+1] = g1;
                    //    imgOutByte[i + 2] = b1;
                    //
                    //}
                    imgOutByte[i] = r;
                    imgOutByte[i+1] = g;
                    imgOutByte[i + 2] = b;




                }
                var imgClone = img_out.Clone() as Bitmap;
                StaticMethods.writeImageBytes(imgClone, imgOutByte);


                
                return imgClone;
            }
        }
    }
}
