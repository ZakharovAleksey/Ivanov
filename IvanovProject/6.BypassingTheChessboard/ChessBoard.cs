using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

            for (int curRow = 0; curRow < this.ChessBoardSize; ++curRow)
            {
                curCellType = (curRow % 2 == 0) ? (int)CellType.WHITE : (int)CellType.BLACK;

                for (int curCol = 0; curCol < this.ChessBoardSize; ++curCol)
                {
                    body[curRow, curCol] = new Cell(curRow, curCol, CellSize, curCellType);

                    curCellType = (curCellType == (int)CellType.WHITE) ? (int)CellType.BLACK : (int)CellType.WHITE;
                }
            }

            #endregion
        }

        #region Solving Methods

        int moveCount = 8;

        int[] yMove = { -1, -2, -2, -1, 1, 2,  2,  1}; //{ 1,  2,  2, 1, -1, -2, -2, -1 };
        int[] xMove = { -2, -1,  1,  2, 2, 1, -1, -2}; //{ -2, -1, 1, 2,  2,  1, -1, -2 };
        


        public void NextMove(ref int row, ref int col)
        {

            ArrayList posNextCellList = new ArrayList();

            for (int curMove = 0; curMove < moveCount; ++curMove)
            {
                int possibleY = row + yMove[curMove];
                int possibleX = col + xMove[curMove];

                if (possibleX >= 0 && possibleY >= 0 && possibleX < chessBoardSize && possibleY < chessBoardSize && body[possibleY, possibleX].IsVisited == false)
                {
                    posNextCellList.Add(body[possibleY, possibleX]);
                    CalcPosiibleSteps(possibleY, possibleX);
                }
            }

            if (posNextCellList.Count == 0)
                return;
            Cell nextCell = (Cell)posNextCellList[0];
            foreach (Cell curPosCell in posNextCellList)
            {
                if (curPosCell.PossibleSteps < nextCell.PossibleSteps)
                {
                    nextCell = curPosCell;
                }
            }

            row = nextCell.Y;
            col = nextCell.X;

            body[row, col].IsVisited = true;
        }

        void CalcPosiibleSteps(int row, int col)
        {
            body[row, col].PossibleSteps = 0;
            for (int curMove = 0; curMove < moveCount; ++curMove)
            {
                int possibleY = row + yMove[curMove];
                int possibleX = col + xMove[curMove];

                if (possibleX >= 0 && possibleY >= 0 && possibleX < chessBoardSize && possibleY < chessBoardSize && body[possibleY, possibleX].IsVisited == false)
                    ++body[row, col].PossibleSteps;

            }
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
