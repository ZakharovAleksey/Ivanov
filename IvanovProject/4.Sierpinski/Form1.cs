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

                if (chBoxRecursive.Checked && chBoxIterative.Checked)
                {
                    MessageBox.Show("Error! Choose only one approach!");
                    return;
                }
                else if (chBoxRecursive.Checked && !chBoxIterative.Checked)
                {
                    Sierpinski(depth, dx, dy, gr);
                }
                else if (chBoxIterative.Checked && !chBoxRecursive.Checked)
                {
                    Sierpinski_NR(depth, dx, dy, gr);
                }
                else
                {
                    MessageBox.Show("Error! Choose one of two approach!");
                    return;
                }
                
                drawingArea.Image = drawingSurface;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear Surface
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            drawingArea.Image = drawingSurface;

            // Set zero values
            depth = 0;
            textBox2.Text = "0";
            tbMaxDepth.Text = "0";

            chBoxRecursive.Checked = false;
            chBoxIterative.Checked = false;

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

                if (chBoxRecursive.Checked && chBoxIterative.Checked)
                {
                    labelExecution.Text = "Execution is not started";
                    MessageBox.Show("Error! Choose only one approach!");
                    sw.Close();
                    return;
                }
                else if (chBoxRecursive.Checked && !chBoxIterative.Checked)
                {
                    Sierpinski(curDepth, dx, dy);
                }
                else if (chBoxIterative.Checked && !chBoxRecursive.Checked)
                {
                    Sierpinski_NR(curDepth, dx, dy);
                }
                else
                {
                    labelExecution.Text = "Execution is not started";
                    MessageBox.Show("Error! Choose one of two approach!");
                    sw.Close();
                    return;
                }

                exTime.Stop();
                long time = exTime.ElapsedMilliseconds;
                sw.WriteLine("{0} {1}", curDepth, time);
            }

            labelExecution.Text = "Execution Complete";

            sw.Close();
        }

        #endregion

        #region Sierpincki non recursive algorithm

        struct DrawTask
        {
            public DrawTask(char type, int depth, float dx = 0, float dy = 0)
            {
                Type = type;
                Depth = depth;
                Linedx = dx;
                Linedy = dy;
            }

            public char Type; // A, B, C, D или L
            public int Depth;
            public float Linedx;
            public float Linedy;
        }

        static void Sierpinski_NR(int depth, float dx, float dy, Graphics gr = null)
        {
            Stack<DrawTask> taskStack = new Stack<DrawTask>();
            float x = dx;
            float y = dy;

            // загружаем задания в стек в обратном порядке
            taskStack.Push(new DrawTask('L', depth, dx, -dy));
            taskStack.Push(new DrawTask('D', depth));
            taskStack.Push(new DrawTask('L', depth, -dx, -dy));
            taskStack.Push(new DrawTask('C', depth));
            taskStack.Push(new DrawTask('L', depth, -dx, dy));
            taskStack.Push(new DrawTask('B', depth));
            taskStack.Push(new DrawTask('L', depth, dx, dy));
            taskStack.Push(new DrawTask('A', depth));

            // пока есть задание, достаём его и выполняем
            // в результате выполнения в стеке могут оказаться подзадания
            while (taskStack.Count > 0)
            {
                var currentTask = taskStack.Pop();
                switch (currentTask.Type)
                {
                    case 'A':
                        drawA_NR(gr, currentTask.Depth, ref x, ref y, dx, dy, taskStack);
                        break;
                    case 'B':
                        drawB_NR(gr, currentTask.Depth, ref x, ref y, dx, dy, taskStack);
                        break;
                    case 'C':
                        drawC_NR(gr, currentTask.Depth, ref x, ref y, dx, dy, taskStack);
                        break;
                    case 'D':
                        drawD_NR(gr, currentTask.Depth, ref x, ref y, dx, dy, taskStack);
                        break;
                    case 'L':
                        drawLine(gr, ref x, ref y, currentTask.Linedx, currentTask.Linedy);
                        break;
                }
            }
        }

        static void drawA_NR(Graphics gr, int depth, ref float x, ref float y, float dx, float dy, Stack<DrawTask> taskStack)
        {
            if (depth > 0)
            {
                --depth;

                // помещаем в стек в обратном порядке
                taskStack.Push(new DrawTask('A', depth));
                taskStack.Push(new DrawTask('L', depth, dx, -dy));
                taskStack.Push(new DrawTask('D', depth));
                taskStack.Push(new DrawTask('L', depth, 2 * dx, 0));
                taskStack.Push(new DrawTask('B', depth));
                taskStack.Push(new DrawTask('L', depth, dx, dy));
                taskStack.Push(new DrawTask('A', depth));
            }
        }

        static void drawB_NR(Graphics gr, int depth, ref float x, ref float y, float dx, float dy, Stack<DrawTask> taskStack)
        {
            if (depth > 0)
            {
                --depth;

                // помещаем в стек в обратном порядке
                taskStack.Push(new DrawTask('B', depth));
                taskStack.Push(new DrawTask('L', depth, dx, dy));
                taskStack.Push(new DrawTask('A', depth));
                taskStack.Push(new DrawTask('L', depth, 0, 2 * dy));
                taskStack.Push(new DrawTask('C', depth));
                taskStack.Push(new DrawTask('L', depth, -dx, dy));
                taskStack.Push(new DrawTask('B', depth));
            }
        }

        static void drawC_NR(Graphics gr, int depth, ref float x, ref float y, float dx, float dy, Stack<DrawTask> taskStack)
        {
            if (depth > 0)
            {
                --depth;

                // помещаем в стек в обратном порядке
                taskStack.Push(new DrawTask('C', depth));
                taskStack.Push(new DrawTask('L', depth, -dx, dy));
                taskStack.Push(new DrawTask('B', depth));
                taskStack.Push(new DrawTask('L', depth, - 2 * dx, 0));
                taskStack.Push(new DrawTask('D', depth));
                taskStack.Push(new DrawTask('L', depth, -dx, -dy));
                taskStack.Push(new DrawTask('C', depth));
            }
        }

        static void drawD_NR(Graphics gr, int depth, ref float x, ref float y, float dx, float dy, Stack<DrawTask> taskStack)
        {
            if (depth > 0)
            {
                --depth;

                // помещаем в стек в обратном порядке
                taskStack.Push(new DrawTask('D', depth));
                taskStack.Push(new DrawTask('L', depth, -dx, -dy));
                taskStack.Push(new DrawTask('C', depth));
                taskStack.Push(new DrawTask('L', depth, 0, -2 * dy));
                taskStack.Push(new DrawTask('A', depth));
                taskStack.Push(new DrawTask('L', depth, dx, -dy));
                taskStack.Push(new DrawTask('D', depth));
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
