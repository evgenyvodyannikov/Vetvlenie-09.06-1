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

            double a = Math.Sqrt(Math.Pow(a1 - b1, 2) + Math.Pow(b2 - a2, 2));
            double b = Math.Sqrt(Math.Pow(b1 - c1, 2) + Math.Pow(c2 - b2, 2));
            double c = Math.Sqrt(Math.Pow(c2 - a2, 2) + Math.Pow(a1 - c1, 2));

            double alpha = 0;
            double betta = 0;
            double gamma = 0;

            alpha = (((Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180)) / Math.PI);
            betta = (((Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * 180)) / Math.PI);
            gamma = (((Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * 180)) / Math.PI);
            if ((a < b + c) & (b < c + a) & (c < b + a))
            {
                if ((alpha == 90) || (betta == 90) || (gamma == 90)) { label4.Text = "Треугольник прямоугольный"; label4.ForeColor = Color.BlueViolet; }
                else
                    if ((alpha > 90) || (betta > 90) || (gamma > 90)) { label4.Text = "Треугольник тупоугольный"; label4.ForeColor = Color.LimeGreen; }
                else
                { label4.Text = "Треугольник остроугольный"; label4.ForeColor = Color.Orange; }
            }
            else
            { label4.Text = "Теугольника не существует"; label4.ForeColor = Color.Red; }
            a1 *= 3;
            a2 *= 3;
            b1 *= 3;
            b2 *= 3;
            c1 *= 3;
            c2 *= 3;
            g.FillEllipse(Brushes.Red, (float)a1, (float)a2, 3, 3);
            g.FillEllipse(Brushes.Red, (float)b1, (float)b2, 3, 3);
            g.FillEllipse(Brushes.Red, (float)c1, (float)c2, 3, 3);
            g.DrawLine(Pens.Blue, (float)a1, (float)a2, (float)b1, (float)b2);
            g.DrawLine(Pens.Blue, (float)b1, (float)b2, (float)c1, (float)c2);
            g.DrawLine(Pens.Blue, (float)a1, (float)a2, (float)c1, (float)c2);
            pictureBox1.Image = bt;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Треугольник задан координатами своих вершин на плоскости: А(х1,у1), В(х2,у2), С(х3,у3).\nОпределить, является он прямо-, остро- или тупоугольным.\nЗамечание: Не следует отбрасывать экстремальные случаи, когда вершины треугольника совпадают или лежат на одной прямой. Например, треугольник с нулевой стороной обладает свойством прямоугольного и имеет два прямых угла!\nОднако в задании, как мне кажется, допущена ошибка, т.к. не существует треугольника с 2! прямыми углами. Треугольник с нулевой стороной уже не труегольник", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (tb.Text.Length == 2 && tb.Text.Length <= 2)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }
    }
}
