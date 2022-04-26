using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    public class LinearFiltering : IFilteringStrategy
    {
        public Bitmap Operation(Bitmap inputImage,double [,] matrix)
        {
            var copyImage = new Bitmap(inputImage.Width, inputImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(copyImage))
            {
                graphics.DrawImage(inputImage, new Point(0, 0));
            }

            var inputImg_byte = StaticMethods.BitmapToByteArray(copyImage);

            byte[] img_outByte = new byte[inputImg_byte.Length];
            byte[,] img_Brightness = new byte[copyImage.Height,copyImage.Width];

            using (var img_out = new Bitmap(copyImage.Width, copyImage.Height, PixelFormat.Format24bppRgb)) //создаем пустое изображение размером с исходное для сохранения результата
            {
                var index = 0;
                var index2 = 0;
                var sum = 0;
                var dim1= img_Brightness.GetLength(0);
                var dim2= img_Brightness.GetLength(1);
                for (int i = 0; i < inputImg_byte.Length - 2; i += 3)
                {

                    int r1 = inputImg_byte[i];
                    int g1 = inputImg_byte[i + 1];
                    int b1 = inputImg_byte[i + 2];

                    img_Brightness[index,index2] = (byte)StaticMethods.Clamp(0.2125 * r1 + 0.7154 * g1 + 0.0721 * b1, 0, 255);

                    sum += img_Brightness[index,index2];
                    index2++;
                    if(index2>=dim2)
                    {
                        index2 = 0;
                        index++;
                    }
                    if(index>=dim1)
                    {
                        break;
                    }    
                }
                
                index = 0;
                for (int i = 0; i < dim1; i++)
                {
                    for(int j=0;j< dim2; j++)
                    {
                        double pixel;
                        if(i==0&&j==0)
                        {
                            pixel=matrix[0,0]*img_Brightness[1,1]+matrix[0, 1] * img_Brightness[1, 0]+ matrix[0, 2] * img_Brightness[1, 1] + matrix[1, 0] * img_Brightness[0, 1] + matrix[1, 1] * img_Brightness[0, 0] + matrix[1, 2] * img_Brightness[0, 1] + matrix[2, 0] * img_Brightness[1, 1] + matrix[2, 1] * img_Brightness[1, 0] + matrix[2, 2] * img_Brightness[1, 1];
                        }
                        else if(i==0&&j==dim2-1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[1, dim2 - 2] + matrix[0, 1] * img_Brightness[1, dim2 - 1] + matrix[0, 2] * img_Brightness[1, dim2 - 2] + matrix[1, 0] * img_Brightness[0, dim2 - 2] + matrix[1, 1] * img_Brightness[0, dim2 - 1] + matrix[1, 2] * img_Brightness[0, dim2 - 2] + matrix[2, 0] * img_Brightness[1, dim2 - 2] + matrix[2, 1] * img_Brightness[1, dim2 - 1] + matrix[2, 2] * img_Brightness[1, dim2 - 2];
                        }
                        else if(i==0&&j>0&&j<dim2-1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i + 1, j - 1] + matrix[0, 1] * img_Brightness[i + 1, j] + matrix[0, 2] * img_Brightness[i + 1, j + 1] + matrix[1, 0] * img_Brightness[i, j - 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j + 1] + matrix[2, 0] * img_Brightness[i + 1, j - 1] + matrix[2, 1] * img_Brightness[i + 1, j] + matrix[2, 2] * img_Brightness[i + 1, j + 1];
                        }
                        else if(i==dim1-1&&j==dim2-1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j - 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j - 1] + matrix[1, 0] * img_Brightness[i, j - 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j - 1] + matrix[2, 0] * img_Brightness[i - 1, j - 1] + matrix[2, 1] * img_Brightness[i - 1, j] + matrix[2, 2] * img_Brightness[i - 1, j - 1];
                        }
                        else if(j==dim2-1&&i>0&&i<dim1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j - 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j - 1] + matrix[1, 0] * img_Brightness[i, j - 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j - 1] + matrix[2, 0] * img_Brightness[i + 1, j - 1] + matrix[2, 1] * img_Brightness[i + 1, j] + matrix[2, 2] * img_Brightness[i + 1, j - 1];
                        }
                        else if(i==dim1-1&&j==0)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j + 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j + 1] + matrix[1, 0] * img_Brightness[i, j + 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j + 1] + matrix[2, 0] * img_Brightness[i - 1, j + 1] + matrix[2, 1] * img_Brightness[i - 1, j] + matrix[2, 2] * img_Brightness[i - 1, j + 1];
                        }
                        else if(i==dim1-1&&j>0&&j<dim2-1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j - 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j + 1] + matrix[1, 0] * img_Brightness[i, j - 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j + 1] + matrix[2, 0] * img_Brightness[i - 1, j - 1] + matrix[2, 1] * img_Brightness[i - 1, j] + matrix[2, 2] * img_Brightness[i - 1, j + 1];
                        }
                        else if(j==0&&i>0&&i<dim1-1)
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j + 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j + 1] + matrix[1, 0] * img_Brightness[i, j + 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j + 1] + matrix[2, 0] * img_Brightness[i + 1, j + 1] + matrix[2, 1] * img_Brightness[i + 1, j] + matrix[2, 2] * img_Brightness[i + 1, j + 1];
                        }
                        else
                        {
                            pixel = matrix[0, 0] * img_Brightness[i - 1, j - 1] + matrix[0, 1] * img_Brightness[i - 1, j] + matrix[0, 2] * img_Brightness[i - 1, j + 1] + matrix[1, 0] * img_Brightness[i, j - 1] + matrix[1, 1] * img_Brightness[i, j] + matrix[1, 2] * img_Brightness[i, j + 1] + matrix[2, 0] * img_Brightness[i + 1, j - 1] + matrix[2, 1] * img_Brightness[i + 1, j] + matrix[2, 2] * img_Brightness[i + 1, j + 1];
                        }
                        //img_outByte[index] = (byte)StaticMethods.Clamp(pixel * 4.7036,0,255);
                        //img_outByte[index+1] = (byte)StaticMethods.Clamp(pixel * 1.3982, 0, 255);
                        //img_outByte[index+2] = (byte)StaticMethods.Clamp(pixel * 13.8504, 0, 255);
                        img_outByte[index] = (byte)StaticMethods.Clamp(pixel , 0, 255);
                        img_outByte[index + 1] = (byte)StaticMethods.Clamp(pixel , 0, 255);
                        img_outByte[index + 2] = (byte)StaticMethods.Clamp(pixel, 0, 255);
                        index +=3;
                    }

                }
                var imgClone = img_out.Clone() as Bitmap;

                StaticMethods.writeImageBytes(imgClone, img_outByte);

                return imgClone;
            }
        }
    }
}
