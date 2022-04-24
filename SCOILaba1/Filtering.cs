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
    public partial class Filtering : Form
    {
        Bitmap _inputImage=null;
        List<string> filterTypes = new List<string>()
        {
            "Без фильтра",
            "Линейная фильтрация",
            "Медианная фильтрация"
        };
        public Filtering(Bitmap inputImage)
        {
            InitializeComponent();
            _inputImage = inputImage;
            this.mainImagePictureBox.Image = _inputImage.Clone() as Bitmap;
            this.mainImagePictureBox.Refresh();
            this.filterType.DataSource = filterTypes;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(string.Equals(this.filterType.SelectedItem.ToString(), "Без фильтра"))
            {
                this.mainImagePictureBox.Image = null;
                this.mainImagePictureBox.Image=_inputImage.Clone() as Bitmap;
                this.mainImagePictureBox.Refresh();
            }
            else if (string.Equals(this.filterType.SelectedItem.ToString(), "Линейная фильтрация"))
            {
                double[,] matrix = new double[3, 3];
                matrix[0, 0] = Double.Parse(this.M00.Text);
                matrix[0, 1] = Double.Parse(this.M01.Text);
                matrix[0, 2] = Double.Parse(this.M02.Text);
                matrix[1, 0] = Double.Parse(this.M10.Text);
                matrix[1, 1] = Double.Parse(this.M11.Text);
                matrix[1, 2] = Double.Parse(this.M12.Text);
                matrix[2, 0] = Double.Parse(this.M20.Text);
                matrix[2, 1] = Double.Parse(this.M21.Text);
                matrix[2, 2] = Double.Parse(this.M22.Text);
                var filtering = new LinearFiltering();
                this.mainImagePictureBox.Image = filtering.Operation(_inputImage, matrix);
                this.mainImagePictureBox.Refresh();
            }
            else if (string.Equals(this.filterType.SelectedItem.ToString(), "Медианная фильтрация"))
            {
                var filtering = new MedianFiltering();
                this.mainImagePictureBox.Image = filtering.Operation(_inputImage);
                this.mainImagePictureBox.Refresh();
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this.mainImagePictureBox.Image.Clone() as Bitmap);
            form1.Show();
            this.Hide();

        }
    }
}
