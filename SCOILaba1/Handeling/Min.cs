using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal class Min : IOperationStrategy
    {
        public Bitmap Operation(int w, int h, int w2, int h2, Bitmap image1, Bitmap image2, string colorType1, string colorType2, int transparency1, int transparency2)
        {
            Bitmap inputBitmapImage1 = new Bitmap(image1);
            Bitmap inputBitmapImage2 = new Bitmap(image2);

            inputBitmapImage1 = StaticMethods.ResizeImage(inputBitmapImage1, new Size(Math.Max(image1.Width, image2.Width), Math.Max(image1.Height, image2.Height)));
            inputBitmapImage2 = StaticMethods.ResizeImage(inputBitmapImage2, new Size(Math.Max(image1.Width, image2.Width), Math.Max(image1.Height, image2.Height)));

            var inputImg1_byte = StaticMethods.BitmapToByteArray(inputBitmapImage1);
            var inputImg2_byte = StaticMethods.BitmapToByteArray(inputBitmapImage2);

            byte[] img_outByte = new byte[inputImg1_byte.Length];

            using (var img_out = new Bitmap(Math.Max(image1.Width, image2.Width), Math.Max(image1.Height, image2.Height)))   //создаем пустое изображение размером с исходное для сохранения результата
            {

                for (int i = 0; i < inputImg1_byte.Length - 2; i += 3)
                {

                    int r1 = 0;
                    int g1 = 0;
                    int b1 = 0;
                    int r2 = 0;
                    int g2 = 0;
                    int b2 = 0;
                    StaticMethods.ChoosePixels(inputImg1_byte, inputImg2_byte, out r1, out g1, out b1, out r2, out g2, out b2, colorType1, colorType2, transparency1, transparency2, i);

                    var r = (byte)Math.Min(r1 , r2);
                    var g = (byte)Math.Min(g1 , g2);
                    var b = (byte)Math.Min(b1 , b2);

                    img_outByte[i] = r;
                    img_outByte[i + 1] = g;
                    img_outByte[i + 2] = b;

                }
                var imgClone = img_out.Clone() as Bitmap;
                StaticMethods.writeImageBytes(imgClone, img_outByte);
                return imgClone;
            }
        }
        
    }
}
