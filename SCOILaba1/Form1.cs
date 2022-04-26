using SCOILaba1.Handeling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCOILaba1
{
    public partial class Form1 : Form
    {
        private Bitmap image1 = null;
        private Bitmap image2 = null;
        private Bitmap resultImage = null;
        private Bitmap imageForFiltering = null;
        List<string> Operations = new List<string>()
        {
            "Сумма",
            "Умножение",
            "Среднее арефметическое",
            "Минимум",
            "Максимум",
            "Наложение"
        };
        List<string> ColorTypes = new List<string>()
        {
            "rgb",
            "r",
            "g",
            "b",
            "rg",
            "rb",
            "gb"
        };
        public Form1()
        {
            InitializeComponent();
            image1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            image2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            resultImage = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            pictureBox1.Image = image1;
            pictureBox2.Image = image2;
            pictureBox3.Image = resultImage;

            comboBox1.DataSource = Operations;
            colorType1Box.DataSource = ColorTypes.ToArray();
            colorType2Box.DataSource = ColorTypes.ToArray();

        }

        public Form1(Bitmap image1,Bitmap image2,Bitmap image3)
        {
            InitializeComponent();
            image1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            image2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            resultImage = new Bitmap(pictureBox3.Width, pictureBox3.Height);

            this.button3.Enabled = true;
            comboBox1.DataSource = Operations;
            colorType1Box.DataSource = ColorTypes.ToArray();
            colorType2Box.DataSource = ColorTypes.ToArray();
            this.pictureBox1.Image = image1;
            this.pictureBox2.Image = image2;
            this.pictureBox3.Image = image3;

            this.pictureBox1.Refresh();
            this.pictureBox2.Refresh();
            this.pictureBox3.Refresh();
        }
        public Form1(Bitmap image)
        {
            InitializeComponent();
            image1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            image2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            resultImage = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            this.button3.Enabled = true;

            comboBox1.DataSource = Operations;
            colorType1Box.DataSource = ColorTypes.ToArray();
            colorType2Box.DataSource = ColorTypes.ToArray();
            this.pictureBox1.Image = image1;
            this.pictureBox2.Image = image2;
            this.pictureBox3.Image = image;

            this.pictureBox1.Refresh();
            this.pictureBox2.Refresh();
            this.pictureBox3.Refresh();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (image1 != null)
                    {
                        pictureBox1.Image = null;
                        image1.Dispose();
                    }

                    image1 = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = image1;
                    imageForFiltering = image1.Clone() as Bitmap;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (image2 != null)
                    {
                        pictureBox2.Image = null;
                        image2.Dispose();
                    }

                    image2 = new Bitmap(openFileDialog.FileName);
                    pictureBox2.Image = image2;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (image1 != null && image2 != null)
            {

                var w = image1.Width;
                var h = image1.Height;

                var w2 = image2.Width;
                var h2 = image2.Height;

                IOperationStrategy strategy = null;

                if (string.Equals(comboBox1.SelectedItem, "Сумма"))
                    strategy = new Sum();
                else if (string.Equals(comboBox1.SelectedItem, "Умножение"))
                    strategy = new Multiply();
                else if (string.Equals(comboBox1.SelectedItem, "Среднее арефметическое"))
                    strategy = new Average();
                else if (string.Equals(comboBox1.SelectedItem, "Минимум"))
                    strategy = new Min();
                else if (string.Equals(comboBox1.SelectedItem, "Максимум"))
                    strategy = new Max();
                else if (string.Equals(comboBox1.SelectedItem, "Наложение"))
                    strategy = new Mask();



                if (strategy != null)
                {
                    pictureBox3.Image = strategy.Operation(w, h, w2, h2, image1, image2, colorType1Box.Text, colorType2Box.Text, trackBar1.Value, trackBar2.Value);
                    pictureBox3.Refresh();
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Некорректная операция");
                }
            }
            else
            {
                MessageBox.Show("Одно из изображений отсутствует");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                using (SaveFileDialog saveFileFialog = new SaveFileDialog())
                {
                    saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
                    saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
                    saveFileFialog.RestoreDirectory = true;

                    if (saveFileFialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox3.Image.Save(saveFileFialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Изображение отсутсвует");
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GradPr gradPr = new GradPr(this,pictureBox1.Image.Clone() as Bitmap,pictureBox2.Image.Clone() as Bitmap,pictureBox3.Image.Clone() as Bitmap);
            gradPr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Binazrize = new Binarization(this.pictureBox3.Image.Clone() as Bitmap);
            Binazrize.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var Filtering = new Filtering(this.pictureBox3.Image.Clone() as Bitmap);
            Filtering.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var frequencyFiltering = new FreqFiltering(imageForFiltering.Clone()as Bitmap);
            frequencyFiltering.Show();
            //this.Hide();
        }
    }
}
