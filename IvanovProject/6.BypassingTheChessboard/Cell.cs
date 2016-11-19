using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.BypassingTheChessboard
{
    enum CellType
    {
        WHITE = 0,
        BLACK = 1,
        USED = 2
    }

    class Cell
    {
        public Cell(int row, int col, int size, int type)
        {
            this.width = size;
            this.height = size;

            posRow = row;
            posCol = col;

            this.type = type;
        }

        #region Fields

        int possibleSteps = 0;

        int height = 0;
        int width = 0;

        int posRow = 0;
        int posCol = 0;
        int type;

        #endregion

        #region Properties

        public bool IsVisited { get; set; } = false;

        public int PossibleSteps
        {
            get { return possibleSteps; }
            set { possibleSteps = value; }
        }

        public int Height
        {
            get { return height; }   
        }

        public int Width
        {
            get { return width; }
        }

        public int X
        {
            get { return posCol; }
        }

        public int Y
        {
            get { return posRow; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion
    }
}

