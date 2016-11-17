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
        Graphics graphic;


        public Form1()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            graphic = Graphics.FromImage(drawingSurface);

            int boardSize = int.Parse(textBoxChessBoardSize.Text);
            int cellSize = drawingArea.Width / boardSize;

            ChessBoard board = new ChessBoard(boardSize, cellSize);
            board.CalcInitalPossibleSteps();
            DrawChessboard(graphic, board);

            drawingArea.Image = drawingSurface;
        }

        #region Drawing Functions

        private static void DrawCell(Graphics graphic, Cell cell)
        {
            switch (cell.Type)
            {
                case (int)CellType.BLACK:
                    graphic.FillRectangle(Brushes.Black, new RectangleF(cell.X, cell.Y, cell.Width, cell.Height));
                    break;
                case (int)CellType.WHITE:
                    graphic.FillRectangle(Brushes.White, new RectangleF(cell.X, cell.Y, cell.Width, cell.Height));
                    break;
                case (int)CellType.USED:
                    graphic.FillRectangle(Brushes.Red, new RectangleF(cell.X, cell.Y, cell.Width, cell.Height));
                    break;
                default:
                    return;
            }
        }

        private static void DrawChessboard(Graphics graphic, ChessBoard board)
        {
            for (int row = 0; row < board.ChessBoardSize; ++row)
                for (int col = 0; col < board.ChessBoardSize; ++col)
                    DrawCell(graphic, board.at(row, col));
        }

        #endregion

    }
}
