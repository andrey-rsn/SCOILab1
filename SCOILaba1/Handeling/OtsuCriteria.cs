using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    public class OtsuCriteria : IBinarizationStrategy
    {
        public Bitmap Opeartion(Bitmap inputImage)
        {
            var copyImage = new Bitmap(inputImage.Width, inputImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(copyImage))
            {
                graphics.DrawImage(inputImage, new Point(0, 0));
            }

            var inputImg_byte = StaticMethods.BitmapToByteArray(copyImage);

            byte[] img_outByte = new byte[inputImg_byte.Length];
            byte[] img_Brightness = new byte[inputImg_byte.Length / 3];
            int[] N = new int[256];

            using (var img_out = new Bitmap(inputImage.Width, inputImage.Height,PixelFormat.Format24bppRgb)) //создаем пустое изображение размером с исходное для сохранения результата
            {
                
                var index = 0;
                var sum = 0;
                for (int i = 0; i < inputImg_byte.Length - 2; i += 3)
                {

                    int r1 = inputImg_byte[i];
                    int g1 = inputImg_byte[i + 1];
                    int b1 = inputImg_byte[i + 2];

                    img_Brightness[index] = (byte)(0.2125 * r1 + 0.7154 * g1 + 0.0721 * b1);

                    sum += img_Brightness[index];
                    index++;
                }
                
                for(int i=0;i<img_Brightness.Length;i++)
                {
                    N[img_Brightness[i]]++;
                }

                var maxInput = img_Brightness.Max();
                var psiB = 0;
                var t = 0;
                var sumN=new int[N.Length-1];
                var sumNmulI = new int[N.Length - 1];
                for (int i=0;i<N.Length-1;i++)
                {
                    sumN[i] = i==0? N[0] : N[i] + sumN[i - 1];
                }
                for (int i = 0; i < N.Length - 1; i++)
                {
                    sumNmulI[i] = i == 0 ? 0 :i* N[i] + sumN[i - 1];
                }
                for (int k=0;k<maxInput;k++)
                {
                    var w1 = sumN[k];
                    var w2 = 1 - w1;
                    var u1 = w1 == 0 ?0 : sumNmulI[k] / w1;
                    var ut = sumNmulI[sumNmulI.Length - 1];
                    var u2 = w2==0? 0 :(ut - u1 * w1) / w2;
                    var tempPsiB = w1 * w2 * (u1 - u2) * (u1 - u2);
                    if (tempPsiB > psiB)
                    {
                        psiB = tempPsiB;
                        t = k;
                    }

                }
                //var t = (double)(sum / (double)(inputImage.Width * inputImage.Height * 2));
                index = 0;
                for (int i = 0; i < img_Brightness.Length; i++)
                {
                    byte bright = 0;
                    if (img_Brightness[i] <= t)
                    {
                        bright = 0;
                    }
                    else
                    {
                        bright = 255;
                    }
                    img_outByte[index] = bright;
                    img_outByte[index + 1] = bright;
                    img_outByte[index + 2] = bright;
                    index += 3;
                }
                var imgClone = img_out.Clone() as Bitmap;
                //Bitmap img_ret = new Bitmap(inputImage.Width, inputImage.Height, PixelFormat.Format24bppRgb);
                //img_ret.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);
                StaticMethods.writeImageBytes(imgClone, img_outByte);
                return imgClone;
            }
        }
    }
}
