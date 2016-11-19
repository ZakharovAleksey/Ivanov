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
using System.IO;
using System.Diagnostics;

namespace _6.BypassingTheChessboard
{
    public partial class Form1 : Form
    {

        Bitmap drawingSurface;
        Graphics graphic;

        ChessBoard board;
        int positionY;
        int positionX;
        int chessBoardSize;

        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
            timer1.Interval = 600;

            // Initilize the drawing area
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            graphic = Graphics.FromImage(drawingSurface);

            // Parse chesboard size and initilize board class
            chessBoardSize = int.Parse(textBoxChessBoardSize.Text);
            int cellSize = drawingArea.Width / chessBoardSize;

            board = new ChessBoard(chessBoardSize, cellSize);
            DrawChessboard(graphic, board);

            // Set start position
            positionY = board.ChessBoardSize - 1;
            positionX = 0;
            board.at(positionY, positionX).IsVisited = true;

            DrawCellAsUsed(graphic, board.at(positionY, positionX));

            drawingArea.Image = drawingSurface;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawingSurface = new Bitmap(drawingArea.Width, drawingArea.Height);
            graphic = Graphics.FromImage(drawingSurface);

            chessBoardSize = int.Parse(textBoxChessBoardSize.Text);
            int cellSize = drawingArea.Width / chessBoardSize;

            ChessBoard board = new ChessBoard(chessBoardSize, cellSize);
            DrawChessboard(graphic, board);

            drawingArea.Image = drawingSurface;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // Bypassing the chessboard algorithm
            if (board.NextMove(ref positionY, ref positionX))
            {
                DrawCellAsUsed(graphic, board.at(positionY, positionX));
                drawingArea.Image = drawingSurface;
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                
                // Check if all chessboard was bypassing
                if(count == chessBoardSize * chessBoardSize)
                    MessageBox.Show("Bypassing successfull.");
                else
                    MessageBox.Show("Bypassing is unsuccesfull.");
                count = 0;
            }
        }

        private void btnPrepareData_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("data.txt");
            chessBoardSize = int.Parse(textBoxChessBoardSize.Text);
            int cellSize = drawingArea.Width / chessBoardSize;

            if (chessBoardSize < 5)
            {
                MessageBox.Show("Input Chessboard size bigger then 5.");
                sw.Close();
                return;
            }
            else
            {
                for (int curBoardSize = 5; curBoardSize < chessBoardSize; ++curBoardSize)
                {
                    Stopwatch exTime = new Stopwatch();
                    exTime.Start();
                    ChessBoard curBoard = new ChessBoard(curBoardSize, cellSize);
                    Solver(curBoard);

                    exTime.Stop();
                    long time = exTime.ElapsedMilliseconds;
                    sw.WriteLine("{0} {1}", curBoardSize, time);
                }
            }

            sw.Close();
            MessageBox.Show("Calculation finished successfully.");
        }


        private void Solver(ChessBoard chessBoard)
        {
            positionY = chessBoard.ChessBoardSize - 1;
            positionX = 0;
            chessBoard.at(positionY, positionX).IsVisited = true;

            for (int curStep = 0; curStep < chessBoardSize * chessBoardSize; ++curStep)
                chessBoard.NextMove(ref positionY, ref positionX);
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
