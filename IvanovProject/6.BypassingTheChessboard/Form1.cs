using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6.BypassingTheChessboard
{
    public partial class Form1 : Form
    {

        Bitmap drawingSurface;
        Graphics gr;

        public Form1()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            gr = Graphics.FromImage(drawingSurface);



            gr.DrawRectangle(Pens.Black, 10, 10, 10, 10);
            



            drawingArea.Image = drawingSurface;
        }

        #region ChessBoard

        private static void DrawChessBoard(int size)
        {
            int cellSize = 10;
        }

        #endregion

    }
}
