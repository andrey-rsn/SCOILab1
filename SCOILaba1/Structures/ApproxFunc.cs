using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Structures
{
    public class ApproxFunc
    {
        public double a { get; set; }

        public double b  { get; set; }
        

        public ApproxFunc()
        {
            a = 0;
            b = 0;
            
        }

        public void LinearApprox(double[] xs,double[] ys,int n)
        {
            
            
                double sumx = 0;
                double sumy = 0;
                double sumx2 = 0;
                double sumxy = 0;
                for (int i = 0; i < n; i++)
                {
                    sumx += xs[i];
                    sumy += ys[i];
                    sumx2 += Math.Pow(xs[i], 2);
                    sumxy += xs[i] * ys[i];
                }
                a = (n * sumxy - (sumx * sumy)) / (n * sumx2 - sumx * sumx);
                b = (sumy - a * sumx) / n;
            
        }

        public double ApplyFunc(double x)
        {
            return a * x + b;
        }
    }
}
