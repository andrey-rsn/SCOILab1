using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Handeling
{
    internal interface IBinarizationStrategy
    {
        Bitmap Opeartion(Bitmap inputImage);
    }
}
