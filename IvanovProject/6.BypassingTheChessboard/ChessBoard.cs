using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.BypassingTheChessboard
{
    class ChessBoard
    {
        public ChessBoard(int chessBoardSize, int cellSize)
        {
            this.chessBoardSize = chessBoardSize;
            this.cellSize = cellSize;

            body = new Cell[this.ChessBoardSize, this.ChessBoardSize];

            #region Fill Chessboard

            int curCellType = (int)CellType.WHITE;

            for (int row = 0; row < this.ChessBoardSize; ++row)
            {
                if(row % 2 == 0)
                    curCellType = (int)CellType.WHITE;
                else
                    curCellType = (int)CellType.BLACK;

                for (int col = 0; col < this.ChessBoardSize; ++col)
                {
                    body[row, col] = new Cell(row * CellSize, col * CellSize, CellSize, curCellType);

                    if (curCellType == (int)CellType.WHITE)
                        curCellType = (int)CellType.BLACK;
                    else
                        curCellType = (int)CellType.WHITE;
                }
            }

            #endregion
        }

        #region Solving Methods

        int moveCount = 8;

        int[] xMove = { -2, -1, 1, 2, 2, 1, -1, -2 };
        int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public void CalcInitalPossibleSteps()
        {
            for (int row = 0; row < chessBoardSize; ++row)
                for (int col = 0; col < chessBoardSize; ++col)
                    CalcPossibleSteps(row, col);
        }

        void CalcPossibleSteps(int row, int col)
        {
            for (int curMove = 0; curMove < moveCount; ++curMove)
                if (row + xMove[curMove] >= 0 && row + xMove[curMove] < chessBoardSize && row + yMove[curMove] >= 0 && row + yMove[curMove] < chessBoardSize)
                    ++body[row, col].PossibleSteps;
        }

        #endregion

        #region Fields

        int chessBoardSize;
        int cellSize;

        Cell[,] body;

        #endregion

        #region Properties

        public int ChessBoardSize
        {
            get { return chessBoardSize; }
        }

        public int CellSize
        {
            get { return cellSize; }
        }

        public Cell at(int row, int col)
        {
            return body[row, col];
        }

        #endregion
    }
}
