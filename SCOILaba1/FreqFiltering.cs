using SCOILaba1.Handeling;
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
    public partial class FreqFiltering : Form
    {
        Bitmap _inputImage = null;
        public FreqFiltering(Bitmap inputImage)
        {
            InitializeComponent();
            _inputImage = inputImage;
            this.mainImage.Image = inputImage;
            this.mainImage.Refresh();
            this.lowFilter.Checked = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            var filtering = new FrequencyFiltering();
            int mnojit = Int32.Parse(this.bright.Text);
            int x= Int32.Parse(this.X.Text);
            int y = Int32.Parse(this.Y.Text);
            int r = Int32.Parse(this.R.Text);
            bool lowFilter = this.lowFilter.Checked;
            bool highFilter = this.highFilter.Checked;
            var furieurImage=filtering.CreateFurieurImage(_inputImage.Clone() as Bitmap,mnojit,x,y,r,lowFilter,highFilter);
            this.FurierImage.Image = furieurImage.image1;
            this.FurierImage.Refresh();
            this.outImage.Image= furieurImage.image2;
            this.outImage.Refresh();
        }
    }
}
