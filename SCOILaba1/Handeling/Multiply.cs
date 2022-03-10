using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal class Multiply : IOperationStrategy
    {
        public Bitmap Operation(int w, int h, int w2, int h2, Bitmap image1, Bitmap image2, string colorType1, string colorType2, int transparency1, int transparency2)
        {
            StaticMethods.ResizePicture(ref image1, ref image2);
            var height = image1.Height;
            var width = image1.Width;
            using (var img_out = new Bitmap(width, height))   //создаем пустое изображение размером с исходное для сохранения результата
            {
                var image1Byte = StaticMethods.BitmapToByteRgbQ(image1);
                var image2Byte = StaticMethods.BitmapToByteRgbQ(image2);
                //попиксельно обрабатываем картинку 
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {

                        int r1 = 0;
                        int g1 = 0;
                        int b1 = 0;
                        int r2 = 0;
                        int g2 = 0;
                        int b2 = 0;


                        //считывыем пиксель картинки и получаем его цвет
                        var pix1 = image1Byte;//.GetPixel(j, i);
                        var pix2 = image2Byte;//.GetPixel(j, i);

                       StaticMethods.ChoosePixels(pix1, pix2, out r1, out g1, out b1, out r2, out g2, out b2, colorType1, colorType2, transparency1, transparency2, i, j);

                        //Увеличим квет каждого пикселя на 1.4
                        //При вычислении пикселей используем функию Clamp (см. ниже Main) чтобы цвет не вылезал за границы [0 255]
                        var r = (int)StaticMethods.Clamp(r1 * r2/255, 0, 255);
                        var g = (int)StaticMethods.Clamp(g1 * g2/255, 0, 255);
                        var b = (int)StaticMethods.Clamp(b1 * b2/255, 0, 255);


                        //записываем пиксель в изображение
                        var pixResult = Color.FromArgb(r, g, b);
                        img_out.SetPixel(j, i, pixResult);

                        //ц-ции GetPixel и SetPixel работают достаточно медленно, надо стримится к минимизации их использования
                    }
                }
                var imgClone = img_out.Clone() as Bitmap;
                return imgClone;
            }
        }
    }
}
