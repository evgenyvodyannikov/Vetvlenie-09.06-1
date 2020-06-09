using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Bitmap bt;
        Pen pen = new Pen(Color.Red);
        Graphics g;
        private void button1_Click(object sender, EventArgs e)
        {
            bt = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bt);
            double a1 = double.Parse(textBox1.Text);
            double a2 = double.Parse(textBox2.Text);

           
            double b1 = double.Parse(textBox3.Text);
            double b2 = double.Parse(textBox4.Text);

            double c1 = double.Parse(textBox5.Text);
            double c2 = double.Parse(textBox6.Text);

            double a = Math.Sqrt(Math.Pow(a2 - a1, 2) + Math.Pow(b1 - b2, 2));
            double b = Math.Sqrt(Math.Pow(b2 - b1, 2) + Math.Pow(c1 - c2, 2));
            double c = Math.Sqrt(Math.Pow(c2 - c1, 2) + Math.Pow(a1 - a2, 2));

            double alpha = 0;
            double betta = 0;
            double gamma = 0;

            alpha = (((Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180)) / Math.PI);
            betta = (((Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * 180)) / Math.PI);
            gamma = (((Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * 180)) / Math.PI);
            if ((a < b + c) & (b < c + a) & (c < b + a))
            {
                if ((alpha == 90) || (betta == 90) || (gamma == 90)) MessageBox.Show(" Треугольник прямоугольный");
                else
                    if ((alpha > 90) || (betta > 90) || (gamma > 90)) MessageBox.Show("Треугольник тупоугольный");
                else
                    MessageBox.Show("Треугольник остроугольный");
            }
            else
                MessageBox.Show("Теугольник не существует");
            a1 *= 2;
            a1 *= 2;
            b1 *= 2;
            b1 *= 2;
            c1 *= 2;
            c1 *= 2;
            g.FillEllipse(Brushes.Red, (float)a1, (float)a2, 2, 2);
            g.FillEllipse(Brushes.Red, (float)b1, (float)b2, 2, 2);
            g.FillEllipse(Brushes.Red, (float)c1, (float)c2, 2, 2);
            g.DrawLine(Pens.Blue, (float)a1, (float)a2, (float)b1, (float)b2);
            g.DrawLine(Pens.Blue, (float)b1, (float)b2, (float)c1, (float)c2);
            g.DrawLine(Pens.Blue, (float)a1, (float)a2, (float)c1, (float)c2);
            pictureBox1.Image = bt;
            pictureBox1.Invalidate();
        }
    }
}
