using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCOILaba1
{
    public partial class Filtering : Form
    {
        Bitmap _inputImage=null;
        public Filtering(Bitmap inputImage)
        {
            InitializeComponent();
            _inputImage = inputImage;
            this.mainImagePictureBox.Image = _inputImage.Clone() as Bitmap;
            this.mainImagePictureBox.Refresh();

        }

        private void applyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
