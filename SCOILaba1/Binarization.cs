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
    public partial class Binarization : Form
    {
        private static List<string> BinarizationTypes = new List<string>()
        {
            "",
            "Критерий Гаврилова",
            "Критерий Отсу"
        };
        private Bitmap InputImage;
        public Binarization(Bitmap inpuImage)
        {
            InitializeComponent();
            InputImage= inpuImage;
            this.InputPictureBox.Image = inpuImage;
            this.comboBox1.DataSource = BinarizationTypes;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            IBinarizationStrategy strategy = null;
            if(string.Equals((Convert.ToString(this.comboBox1.SelectedValue)), "Критерий Гаврилова"))
            {
                strategy = new GavrCriteria();
            }
            else if(string.Equals((Convert.ToString(this.comboBox1.SelectedValue)), "Критерий Отсу"))
            {
                strategy = new OtsuCriteria();
            }

            var resultImage=strategy.Opeartion(InputImage.Clone()as Bitmap);

            this.InputPictureBox.Image = null;
            this.InputPictureBox.Image = resultImage;
            this.InputPictureBox.Refresh();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this.InputPictureBox.Image.Clone() as Bitmap);
            form1.Show();
            this.Hide();
        }
    }
}
