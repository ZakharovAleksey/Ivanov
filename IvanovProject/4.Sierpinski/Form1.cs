using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        #region Buttons Actions

        private void btnDraw_Click(object sender, EventArgs e)
        {
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            gr = Graphics.FromImage(drawingSurface);

            depth = int.Parse(textBox2.Text);

            if (depth > 0)
            {
                float dx = (float)(drawingArea.Width / Math.Pow(2, depth - 1) / 8);
                float dy = (float)(drawingArea.Height / Math.Pow(2, depth - 1) / 8);

                Sierpinski(depth, dx, dy, gr);
                drawingArea.Image = drawingSurface;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.Black);
            depth = 0;
            textBox2.Text = "0";
            tbMaxDepth.Text = "0";
            labelExecution.Text = "Execution is not started";


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int maxDepth = int.Parse(tbMaxDepth.Text);
            float dx = 0.1f;
            float dy = 0.01f;

            Stopwatch exTime = new Stopwatch();
            StreamWriter sw = new StreamWriter("executionTime.txt");

            for (int curDepth = 1; curDepth <= maxDepth; ++curDepth)
            {
                labelExecution.Text = "Execution process";
                exTime.Restart();
                Sierpinski(curDepth, dx, dy);
                exTime.Stop();
                sw.WriteLine("{0} {1}", curDepth, exTime.ElapsedMilliseconds);
            }

            labelExecution.Text = "Execution Complete";

            sw.Close();
        }

        #endregion

        #region Sierpincki non recursive algorithm

        static private void DrawSubCurve(int depth, int pc, int dx, int dy, Graphics gr = null)
        {
            float x = dx;
            float y = dy;

            bool aDone = false;
            bool bDone = false;
            bool cDone = false;
            bool dDone = false;

            while (true)
            {
                switch (pc)
                {
                    case 11:
                        if (depth <= 1)
                        {
                            drawLine(gr, ref x, ref y, dx, dy);
                            drawLine(gr, ref x, ref y, 2 * dx, 0);
                            drawLine(gr, ref x, ref y, dx, -dy);
                            pc = 0;
                            aDone = true;
                        }
                        else
                        {
                            --depth;
                            pc = 11;
                        }
                        break;
                    case 12:
                        drawLine(gr, ref x, ref y, dx, dy);
                        --depth;
                        pc = 21;
                        break;
                    case 13:
                        drawLine(gr, ref x, ref y, 2 * dx, 0);
                        --depth;
                        pc = 41;
                        break;
                    case 14:
                        drawLine(gr, ref x, ref y, dx, -dy);
                        --depth;
                        pc = 11;
                        break;
                    case 21:
                        if (depth <= 1)
                        {
                            drawLine(gr, ref x, ref y, -dx, dy);
                            drawLine(gr, ref x, ref y, 0, 2 * dy);
                            drawLine(gr, ref x, ref y, dx, dy);
                            pc = 0;
                            bDone = true;
                        }
                        else
                        {
                            --depth;
                            pc = 21;
                        }
                        break;
                    case 22:
                        drawLine(gr, ref x, ref y, -dx, dy);
                        --depth;
                        pc = 31;
                        break;
                    case 23:
                        drawLine(gr, ref x, ref y, 0, 2 * dy);
                        --depth;
                        pc = 11;
                        break;
                    case 24:
                        drawLine(gr, ref x, ref y, dx, dy);
                        --depth;
                        pc = 21;
                        break;
                    case 31:
                        if (depth <= 1)
                        {
                            drawLine(gr, ref x, ref y, -dx, -dy);
                            drawLine(gr, ref x, ref y, -2 * dx, 0);
                            drawLine(gr, ref x, ref y, -dx, dy);
                            pc = 0;
                            cDone = true;
                        }
                        else
                        {
                            --depth;
                            pc = 31;
                        }
                        break;
                    case 32:
                        drawLine(gr, ref x, ref y, -dx, -dy);
                        --depth;
                        pc = 41;
                        break;
                    case 33:
                        drawLine(gr, ref x, ref y, -2 * dx, 0);
                        --depth;
                        pc = 21;
                        break;
                    case 34:
                        drawLine(gr, ref x, ref y, -dx, dy);
                        --depth;
                        pc = 31;
                        break;
                    case 41:
                        if (depth <= 1)
                        {
                            drawLine(gr, ref x, ref y, dx, -dy);
                            drawLine(gr, ref x, ref y, 0, -2 * dy);
                            drawLine(gr, ref x, ref y, -dx, -dy);
                            pc = 0;
                            dDone = true;
                        }
                        else
                        {
                            --depth;
                            pc = 41;
                        }
                        break;
                    case 42:
                        drawLine(gr, ref x, ref y, dx, -dy);
                        --depth;
                        pc = 31;
                        break;
                    case 43:
                        drawLine(gr, ref x, ref y, 0, -2 * dy);
                        --depth;
                        pc = 11;
                        break;
                    case 44:
                        drawLine(gr, ref x, ref y, -dx, -dy);
                        --depth;
                        pc = 41;
                        break;
                    case 0:
                        if (aDone && bDone && cDone && dDone)
                            return;
                        break;




                }

            }
        }

        #endregion

        #region Sierpinski recursive algorithm


        static private void Sierpinski(int depth, float dx, float dy, Graphics gr = null)
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
            if (gr != null)
                gr.DrawLine(Pens.Black, x, y, x + dx, y + dy);
            x += dx;
            y += dy;
        }

        #endregion

    }
}
