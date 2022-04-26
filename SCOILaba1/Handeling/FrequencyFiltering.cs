using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    public class FrequencyFiltering
    {
        public (Bitmap image1,Bitmap image2) CreateFurieurImage(Bitmap inputImage,int mnoj=4,int x=2,int y=3, int R=4,bool flag1=false,bool flag2=true)
        {
            var copyImage = new Bitmap(inputImage.Width, inputImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(copyImage))
            {
                graphics.DrawImage(inputImage, new Point(0, 0));
            }
            
            var w = copyImage.Width;
            var h=copyImage.Height;
            var fur = new byte[h * w * 3];
            var img_outByte=new byte[w * h*3];
            var index = 0;
            var inputImg_byte = StaticMethods.BitmapToByteArray(copyImage);
            var inputImg_byteColors = new byte[h,w,3];
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    inputImg_byteColors[i,j,0]=inputImg_byte[index];
                    inputImg_byteColors[i, j, 1] = inputImg_byte[index+1];
                    inputImg_byteColors[i, j, 2] = inputImg_byte[index+2];
                    index+=3;
                }
            }
            

            Complex[,] red = new Complex[h, w];
            Complex[,] green = new Complex[h, w];
            Complex[,] blue = new Complex[h, w];
            var ind= 0;
            for (int i = 0; i < h; ++i)
            {
                Complex[] r = new Complex[w];
                Complex[] g = new Complex[w];
                Complex[] b = new Complex[w];
                for (int j = 0; j < w; ++j)
                {
                    var r1 = inputImg_byte[ind];
                    var g1= inputImg_byte[ind+1];
                    var b1= inputImg_byte[ind+2];
                    r[j] = new Complex(r1, 0) * Math.Pow(-1, i + j);
                    g[j] = new Complex(g1, 0) * Math.Pow(-1, i + j);
                    b[j] = new Complex(b1, 0) * Math.Pow(-1, i + j);
                    ind += 3;
                }
                r = StaticMethods.TwoDiscreteTransformation(r);
                g = StaticMethods.TwoDiscreteTransformation(g);
                b = StaticMethods.TwoDiscreteTransformation(b);
                for (int j = 0; j < w; ++j)
                {
                    red[i, j] = r[j];
                    green[i, j] = g[j];
                    blue[i, j] = b[j];
                }
            }
            for (int i = 0; i < w; ++i)
            {
                Complex[] r = new Complex[h];
                Complex[] g = new Complex[h];
                Complex[] b = new Complex[h];
                for (int j = 0; j < h; ++j)
                {
                    r[j] = red[j, i];
                    g[j] = green[j, i];
                    b[j] = blue[j, i];
                }
                r = StaticMethods.TwoDiscreteTransformation(r);
                g = StaticMethods.TwoDiscreteTransformation(g);
                b = StaticMethods.TwoDiscreteTransformation(b);
                for (int j = 0; j < h; ++j)
                {
                    red[j, i] = r[j];
                    green[j, i] = g[j];
                    blue[j, i] = b[j];
                }
            }
            double maxR = 0;
            double maxG = 0;
            double maxB = 0;
            for (int i = 0; i < h; ++i)
                for (int j = 0; j < w; ++j)
                {
                    if (Math.Log(Math.Abs(red[i, j].Magnitude) + 1) > maxR)
                        maxR = Math.Log(Math.Abs(red[i, j].Magnitude) + 1);
                    if (Math.Log(Math.Abs(green[i, j].Magnitude) + 1) > maxG)
                        maxG = Math.Log(Math.Abs(red[i, j].Magnitude) + 1);
                    if (Math.Log(Math.Abs(blue[i, j].Magnitude) + 1) > maxB)
                        maxB = Math.Log(Math.Abs(red[i, j].Magnitude) + 1);
                }

            index = 0;
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    byte r, g, b;
                    r = (byte)StaticMethods.Clamp((int)(Math.Log(Math.Abs(red[i, j].Magnitude) + 1) * maxR / 255 * mnoj * 1000), 0, 255);
                    g = (byte)StaticMethods.Clamp((int)(Math.Log(Math.Abs(green[i, j].Magnitude) + 1) * maxG / 255 * mnoj * 1000), 0, 255);
                    b = (byte)StaticMethods.Clamp((int)(Math.Log(Math.Abs(blue[i, j].Magnitude) + 1) * maxB / 255 * mnoj * 1000), 0, 255);
                    fur[index] = r;
                    fur[index+1] = g;
                    fur[index+2] = b;
                    index += 3;
                }
            }

            
            
            for (int i = 0; i < h; ++i)
                for (int j = 0; j < w; ++j)
                {
                    if (flag1)
                        if (Math.Sqrt(Math.Pow((i - y), 2) + Math.Pow((j - x), 2)) > R)
                        {
                            red[i, j] = red[i, j] * 0;
                            green[i, j] = green[i, j] * 0;
                            blue[i, j] = blue[i, j] * 0;
                        }
                    if (flag2)
                        if (Math.Sqrt(Math.Pow((i - y), 2) + Math.Pow((j - x), 2)) < R)
                        {
                            red[i, j] = red[i, j] * 0;
                            green[i, j] = green[i, j] * 0;
                            blue[i, j] = blue[i, j] * 0;
                        }

                }
            for (int i = 0; i < h; ++i)
            {
                Complex[] r = new Complex[w];
                Complex[] g = new Complex[w];
                Complex[] b = new Complex[w];
                for (int j = 0; j < w; ++j)
                {
                    r[j] = red[i, j];
                    g[j] = green[i, j];
                    b[j] = blue[i, j];
                }
                r = StaticMethods.TwoDiscreteTransformationReverse(r);
                g = StaticMethods.TwoDiscreteTransformationReverse(g);
                b = StaticMethods.TwoDiscreteTransformationReverse(b);
                for (int j = 0; j < w; ++j)
                {
                    red[i, j] = r[j];
                    green[i, j] = g[j];
                    blue[i, j] = b[j];
                }
            }
            for (int i = 0; i < w; ++i)
            {
                Complex[] r = new Complex[h];
                Complex[] g = new Complex[h];
                Complex[] b = new Complex[h];
                for (int j = 0; j < h; ++j)
                {
                    r[j] = red[j, i];
                    g[j] = green[j, i];
                    b[j] = blue[j, i];
                }
                r = StaticMethods.TwoDiscreteTransformationReverse(r);
                g = StaticMethods.TwoDiscreteTransformationReverse(g);
                b = StaticMethods.TwoDiscreteTransformationReverse(b);
                for (int j = 0; j < h; ++j)
                {
                    red[j, i] = r[j] * Math.Pow(-1, i + j);
                    green[j, i] = g[j] * Math.Pow(-1, i + j);
                    blue[j, i] = b[j] * Math.Pow(-1, i + j);
                }
            }
            index = 0;
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    int r, g, b;
                    r = StaticMethods.Clamp((int)Math.Abs(red[i, j].Magnitude), 0, 255);
                    g = StaticMethods.Clamp((int)Math.Abs(green[i, j].Magnitude), 0, 255);
                    b = StaticMethods.Clamp((int)Math.Abs(blue[i, j].Magnitude), 0, 255);
                    img_outByte[index] = (byte)r;
                    img_outByte[index+1] = (byte)g;
                    img_outByte[index+2] = (byte)b;
                    index += 3;
                }
            }
            
            var furImage= new Bitmap(w,h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var outImage = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            StaticMethods.writeImageBytes(furImage, fur);
            StaticMethods.writeImageBytes(outImage, img_outByte);
            return(furImage, outImage);

            // var ImgByte2dim = new double[copyImage.Height,copyImage.Width*3];
            // var dim1Length = ImgByte2dim.GetLength(0);
            // var dim2Length = ImgByte2dim.GetLength(1);
            // var index = 0;
            // for (int i=0;i<dim1Length;i++)
            // {
            //     for(int j=0;j<dim2Length-2;j+=3)
            //     {
            //         ImgByte2dim[i,j]=(inputImg_byte[index]*Math.Pow(-1,i+j));
            //         ImgByte2dim[i, j+1] = inputImg_byte[index+1] * Math.Pow(-1, i + j+1);
            //         ImgByte2dim[i, j+2] = inputImg_byte[index+2] * Math.Pow(-1, i + j+2);
            //         index += 3;
            //     }
            // }
            //
            // byte[] img_outByte = new byte[inputImg_byte.Length];
            // Complex[,] X1 = new Complex[dim1Length,dim2Length];
            // int N = X1.Length;
            // for (int n=0;n<dim1Length;++n)
            // {
            //     for (int u = 0; u < dim2Length; ++u)
            //     {
            //         double _fi = -2.0 * Math.PI * u / dim2Length;
            //         for (int k = 0; k < dim2Length; ++k)
            //         {
            //             double fi = _fi * k;
            //             X1[n,u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * ImgByte2dim[n,k]);
            //         }
            //         X1[n,u] = X1[n,u]; //для умножения на 1/N для прямого преобразования I
            //     }
            // }
            // 
            // N = X1.Length;
            // Complex[,] G = new Complex[dim1Length,dim2Length]; // 
            // for (int n = 0; n < dim1Length; ++n)
            // {
            //     for (int u = 0; u < dim2Length; ++u)
            //     {
            //         double _fi = -2.0 * Math.PI * u / N;
            //         for (int k = 0; k < dim2Length; ++k)
            //         {
            //             double fi = _fi * k;
            //             G[n,u] += (new Complex(Math.Cos(fi), Math.Sin(fi)) * X1[n,k]);
            //         }
            //         G[n,u] = G[n,u]; //для умножения на 1/N для прямого преобразования I
            //     }
            // }
            //
            // var imgOutByte = G.Cast<Complex>().ToArray().Select(x=>(byte)StaticMethods.Clamp(x.Magnitude,0,255)).ToArray();
            //
            // using(var outImage=new Bitmap(copyImage.Width,copyImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            // {
            //     var imgClone = outImage.Clone() as Bitmap;
            //     StaticMethods.writeImageBytes(imgClone, imgOutByte);
            //     return imgClone;
            // }

        }
    }
}
