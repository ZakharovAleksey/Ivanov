using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4.Sierpinski
{
    public partial class Form1 : Form
    {
        Bitmap drawingSurface;
        Graphics gr;

        int depth = 0;

        public Form1()
        {

            InitializeComponent();

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            gr = Graphics.FromImage(drawingSurface);


            depth = int.Parse(textBox2.Text);

            float dx = (float)(drawingArea.Width / Math.Pow(2, depth - 1) / 8); //drawingArea.Width / (8 * depth);
            float dy = (float)(drawingArea.Height / Math.Pow(2, depth - 1) / 8);

            Sierpinski(gr, depth, dx, dy);


            drawingArea.Image = drawingSurface;

        }

        static private void Sierpinski(Graphics gr, int depth, float dx, float dy)
        {
            float x = dx;
            float y = dy;

            drawA(gr, depth, ref x, ref y, dx, dy);
            drawLine(gr, ref x, ref y, dx, dy);
            drawB(gr, depth, ref x, ref y, dx, dy);
            drawLine(gr, ref x, ref y, -dx, dy);
            drawC(gr, depth, ref x, ref y, dx, dy);
            drawLine(gr, ref x, ref y, -dx, -dy);
            drawD(gr, depth, ref x, ref y, dx, dy);
            drawLine(gr, ref x, ref y, dx, -dy);
        }

        static private void drawA(Graphics gr, int depth, ref float x, ref float y, float dx, float dy)
        {
            if (depth > 0)
            {
                --depth;

                drawA(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, dx, dy);
                drawB(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, 2 * dx, 0);
                drawD(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, dx, -dy);
                drawA(gr, depth, ref x, ref y, dx, dy);

            }

        }

        static private void drawB(Graphics gr, int depth, ref float x, ref float y, float dx, float dy)
        {
            if (depth > 0)
            {
                --depth;

                drawB(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, -dx, dy);
                drawC(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, 0, 2 * dy);
                drawA(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, dx, dy);
                drawB(gr, depth, ref x, ref y, dx, dy);
            }
        }

        static private void drawC(Graphics gr, int depth, ref float x, ref float y, float dx, float dy)
        {
            if (depth > 0)
            {

                --depth;
                drawC(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, -dx, -dy);
                drawD(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, -2 * dx, 0);
                drawB(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, -dx, dy);
                drawC(gr, depth, ref x, ref y, dx, dy);
            }
        }

        static private void drawD(Graphics gr, int depth, ref float x, ref float y, float dx, float dy)
        {
            if (depth > 0)
            {
                --depth;
                drawD(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, dx, -dy);
                drawA(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, 0, -2 * dy);
                drawC(gr, depth, ref x, ref y, dx, dy);
                drawLine(gr, ref x, ref y, -dx, -dy);
                drawD(gr, depth, ref x, ref y, dx, dy);
            }
        }

        static private void drawLine(Graphics gr, ref float x, ref float y, float dx, float dy)
        {
            gr.DrawLine(Pens.Black, x, y, x + dx, y + dy);
            x += dx;
            y += dy;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            depth = 0;
            textBox2.Text = "";

        }
    }
}
