using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test5._7._1_tree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        const double PI = Math.PI;
        double th1 = 40 * Math.PI/180;
        double th2 = 30 * Math.PI/180;
        double per1 = 0.6;
        double per2 = 0.7;
        Random random = new Random();
        double rand()
        {
            return random.NextDouble();
        }
        public Form1()
        {
            InitializeComponent();
            //this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.Click += new EventHandler(this.Redraw);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            drawTree(10, 300, 400, 100, -PI / 2);
        }
        private void Redraw(object sender,EventArgs e)
        {
            this.Invalidate();
        }
        void drawTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, n / 2);

            drawTree(n - 1, x1, y1, per1 * leng * (0.5 + rand()), th + th1 * (0.5 + rand()));
            drawTree(n - 1, x1, y1, per2 * leng * (0.5 + rand()), th - th2 * (0.5 + rand()));
        }
        void drawLine(double x0,double y0,double x1,double y1,int width)
        {
            graphics.DrawLine(new Pen(Color.Black, width), (float)x0, (float)y0, (float)x1, (float)y1);
        }

    }
}
