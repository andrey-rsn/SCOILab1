using MathNet.Numerics.Interpolation;
using SCOILaba1.Handeling;
using SCOILaba1.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCOILaba1
{
    public partial class GradPr : Form
    {
        private Bitmap inputImage=null;
        private Form previousForm;
        private Bitmap HistImage = null;
        public GradPr(Form prevForm,Bitmap image)
        {
            InitializeComponent();
            previousForm = prevForm;
            inputImage = image.Clone() as Bitmap;
            
            picture1.Image = inputImage;
            picture1.Refresh();
            HistImage=Histogram.CreateHistogramm(inputImage);
            HistPictureBox.Image = HistImage;
            HistPictureBox.Refresh();
            

            var canvas = new pan(this.picture1,this.HistPictureBox,inputImage.Clone() as Bitmap);
            canvas.Size = new Size(510,510);
            canvas.Location = new Point(0, 0);

            //Сохдаем нашу канву.
            //var canvas1 = new MyCanvas();

            //Клапдем ее в панель на окне (чтобы было удобно управлять ее размерами)
            this.gradPicture.Controls.Add(canvas);

            
            //Даем есть установку - всегда заполнять всю возможную область
            // canvas1.Dock = DockStyle.Fill;
        }

        public partial class pan : System.Windows.Forms.Panel
        {
            Pen redPen ;
            Pen greenPen ;
            Pen orangePen;

            // Create points that define curve.
            Point point1;
            Point point2;
            Point point3;
            Point point4;
            Point point5;
            Circle circle1;
            Circle circle2;
            Circle circle3;
            Circle circle4;
            Circle circle5;
            CubicSpline interpolateFunc=null;
            Bitmap inputImage = null;
            PictureBox MainPictureBox = null;
            PictureBox HistPictureBox = null;
            Bitmap Hist = null;


            public pan(PictureBox pictureBox, PictureBox HistogramPictureBox, Bitmap Image)
            {
                redPen = new Pen(Color.Red, 1);
                greenPen = new Pen(Color.Green, 10);
                orangePen = new Pen(Color.Orange, 10);

                // Create points that define curve.
                point1 = StaticMethods.ConvertCoordToPoint(0, 0);
                point2 = StaticMethods.ConvertCoordToPoint(51, 51);
                point3 = StaticMethods.ConvertCoordToPoint(102, 102);
                point4 = StaticMethods.ConvertCoordToPoint(153, 153);
                point5 = StaticMethods.ConvertCoordToPoint(255, 255);
                circle1=new Circle(point1.X,point1.Y,greenPen,5);
                circle2 = new Circle(point2.X, point2.Y, greenPen, 5);
                circle3 = new Circle(point3.X, point3.Y, greenPen, 5);
                circle4 = new Circle(point4.X, point4.Y, greenPen, 5);
                circle5 = new Circle(point5.X, point5.Y, greenPen, 5);
                inputImage = Image;
                MainPictureBox = pictureBox;
               // Hist = HistogramPictureBox.Image;
                HistPictureBox = HistogramPictureBox;
                //настраиваем стель для плавного рисования
                this.SetStyle(
                    System.Windows.Forms.ControlStyles.UserPaint |
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                    System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                    true);

                //прикрепляем методы к событиям
                //событие отрисовки
                Paint += p_event;

                //события мыши
                //перехватываем клики, смотрим координаты, 
                //создаем массивы с точками, рисуем, 
                //интерполируем, итд.
                MouseDown += Pan_MouseDown;
                MouseUp += Pan_MouseUp;
                MouseMove += Pan_MouseMove;

                //включаем постоянную перерисовку по таймеру
                //не совсем оптимальный вариант, все время рисовать на виджите
                //но для сделанного на коленке пойдет

                Timer y = new Timer();
                y.Interval = 30;
                y.Tick += (s, a) => { this.Refresh(); };

                VisibleChanged += (s, a) => { y.Start(); };

            }

            private void Pan_MouseMove(object sender, MouseEventArgs e)
            {
                if(circle1.IsSelected)
                {
                    point1.X = e.Location.X;
                    point1.Y = e.Location.Y;
                    circle1.x= e.Location.X;
                    circle1.y= e.Location.Y;
                }
                else if(circle2.IsSelected)
                {
                    point2.X = e.Location.X;
                    point2.Y = e.Location.Y;
                    circle2.x = e.Location.X;
                    circle2.y = e.Location.Y;
                }
                else if (circle3.IsSelected)
                {
                    point3.X = e.Location.X;
                    point3.Y = e.Location.Y;
                    circle3.x = e.Location.X;
                    circle3.y = e.Location.Y;
                }
                else if (circle4.IsSelected)
                {
                    point4.X = e.Location.X;
                    point4.Y = e.Location.Y;
                    circle4.x = e.Location.X;
                    circle4.y = e.Location.Y;
                }
                else if (circle5.IsSelected)
                {
                    point5.X = e.Location.X;
                    point5.Y = e.Location.Y;
                    circle5.x = e.Location.X;
                    circle5.y = e.Location.Y;
                }
            }

            private void Pan_MouseUp(object sender, MouseEventArgs e)
            {
                var ChangedPoints=new List<Point>() {point1,point2,point3,point4,point5};
                var points=StaticMethods.ConvertListOfPointsToNormalPoints(ChangedPoints);
                if (circle1.IsSelected)
                {
                    circle1.pen = greenPen;
                    circle1.IsSelected = false;
                    interpolateFunc=CubicSpline.InterpolateAkimaSorted(points.Select(x=>(double)x.X).ToArray(), points.Select(x => (double)x.Y).ToArray());
                }
                else if (circle2.IsSelected)
                {
                    circle2.pen = greenPen;
                    circle2.IsSelected = false;
                    interpolateFunc = CubicSpline.InterpolateAkimaSorted(points.Select(x => (double)x.X).ToArray(), points.Select(x => (double)x.Y).ToArray());
                }
                else if (circle3.IsSelected)
                {
                    circle3.pen = greenPen;
                    circle3.IsSelected = false;
                    interpolateFunc = CubicSpline.InterpolateAkimaSorted(points.Select(x => (double)x.X).ToArray(), points.Select(x => (double)x.Y).ToArray());
                }
                else if (circle4.IsSelected)
                {
                    circle4.pen = greenPen;
                    circle4.IsSelected = false;
                    interpolateFunc = CubicSpline.InterpolateAkimaSorted(points.Select(x => (double)x.X).ToArray(), points.Select(x => (double)x.Y).ToArray());
                }
                else if (circle5.IsSelected)
                {
                    circle5.pen = greenPen;
                    circle5.IsSelected = false;
                    interpolateFunc = CubicSpline.InterpolateAkimaSorted(points.Select(x => (double)x.X).ToArray(), points.Select(x => (double)x.Y).ToArray());
                }
                if(interpolateFunc!=null)
                {
                    this.Enabled = false;
                    MainPictureBox.Image = null;
                    MainPictureBox.Image = GradTransform.GradTransformImage(inputImage, interpolateFunc);
                    MainPictureBox.Refresh();
                    var imageToHist = (Bitmap)MainPictureBox.Image;
                    HistPictureBox.Image = null;
                    HistPictureBox.Image=Histogram.CreateHistogramm(imageToHist);
                    HistPictureBox.Refresh();
                    this.Enabled = true;
                }
            }

            private void Pan_MouseDown(object sender, MouseEventArgs e)
            {
                if (this.Enabled)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (StaticMethods.IsPointInCirle(e.Location.X, e.Location.Y, circle1))
                        {
                            circle1.pen = orangePen;
                            circle1.IsSelected = true;
                        }
                        else if (StaticMethods.IsPointInCirle(e.Location.X, e.Location.Y, circle2))
                        {
                            circle2.pen = orangePen;
                            circle2.IsSelected = true;
                        }
                        else if (StaticMethods.IsPointInCirle(e.Location.X, e.Location.Y, circle3))
                        {
                            circle3.pen = orangePen;
                            circle3.IsSelected = true;
                        }
                        else if (StaticMethods.IsPointInCirle(e.Location.X, e.Location.Y, circle4))
                        {
                            circle4.pen = orangePen;
                            circle4.IsSelected = true;
                        }
                        else if (StaticMethods.IsPointInCirle(e.Location.X, e.Location.Y, circle5))
                        {
                            circle5.pen = orangePen;
                            circle5.IsSelected = true;
                        }

                    }
                }

            }

            public void p_event(object sender, System.Windows.Forms.PaintEventArgs e)
            {
                //событие отрисовки вызывается, когда ОС дает окну команду на перересовку.

                //Тут уже знакомый нам Graphics
                //все что на нем рисуется - отобразится на форме в процессе перерисовки
                //e.Graphics.FillRectangle(Brushes.Red, 0, 0, Size.Width, Size.Height);

                // Create points that define curve.
                if(inputImage!=null)
                { 
                    Point[] curvePoints = { point1,point2,point3, point4,point5 };
                    
                    e.Graphics.DrawCurve(redPen, curvePoints);
                    StaticMethods.DrawCircle(e.Graphics, circle1);
                    StaticMethods.DrawCircle(e.Graphics, circle2);
                    StaticMethods.DrawCircle(e.Graphics, circle3);
                    StaticMethods.DrawCircle(e.Graphics, circle4);
                    StaticMethods.DrawCircle(e.Graphics, circle5);

                }


            }
        }
    }
}
