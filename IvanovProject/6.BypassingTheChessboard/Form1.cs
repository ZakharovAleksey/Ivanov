using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

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
            DrawChessboard(graphic, board);

            Solver(graphic, ref board);

            drawingArea.Image = drawingSurface;
        }

        private static void Solver(Graphics graphic, ref ChessBoard board)
        {
            int positionY = board.ChessBoardSize - 1;
            int positionX = 0;

            board.at(positionY, positionX).IsVisited = true;
            DrawCellAsUsed(graphic, board.at(positionY, positionX));
            Thread.Sleep(100);

            for (int i = 0; i < board.ChessBoardSize * board.ChessBoardSize - 5; ++i)
            {
                board.NextMove(ref positionY, ref positionX);
                DrawCellAsUsed(graphic, board.at(positionY, positionX));
                
                Thread.Sleep(100);
            }

            //DrawCellAsUsed(graphic, board);
        }


        #region Drawing Functions

        private static void DrawCell(Graphics graphic, Cell cell)
        {
            switch (cell.Type)
            {
                case (int)CellType.BLACK:
                    graphic.FillRectangle(Brushes.Black, new RectangleF(cell.X * cell.Height, cell.Y * cell.Width, cell.Width, cell.Height));
                    break;
                case (int)CellType.WHITE:
                    graphic.FillRectangle(Brushes.White, new RectangleF(cell.Y * cell.Height, cell.X * cell.Width, cell.Width, cell.Height));
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

        private static void DrawCellAsUsed(Graphics graphic, Cell cell)
        {
            graphic.FillRectangle(Brushes.Red, new RectangleF(cell.X * cell.Height, cell.Y * cell.Width, cell.Width, cell.Height));
            //graphic.FillRectangle(Brushes.Red, new RectangleF(cell.Y * cell.Height, cell.X * cell.Width, cell.Width, cell.Height));
        }

        private static void DrawCellAsUsed(Graphics graphic, ChessBoard board)
        {
            for (int row = 0; row < board.ChessBoardSize; ++row)
            {
                for (int col = 0; col < board.ChessBoardSize; ++col)
                {
                    if (board.at(row, col).IsVisited == true)
                    {
                        Cell cell = board.at(row, col);
                        graphic.FillRectangle(Brushes.Red, new RectangleF(cell.X * cell.Height, cell.Y * cell.Width, cell.Width, cell.Height));
                    }
                }
            }
        }

        #endregion

    }
}
