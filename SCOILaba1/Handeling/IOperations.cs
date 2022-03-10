using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal interface IOperationStrategy
    {
        Bitmap Operation(int w, int h, int w2, int h2, Bitmap image1, Bitmap image2, string colorType1, string colorType2, int transparency1, int transparency2);
    }
}
