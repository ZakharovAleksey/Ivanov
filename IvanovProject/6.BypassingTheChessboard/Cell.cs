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

        public Cell(int x, int y, int size, int type)
        {
            this.width = size;
            this.height = size;

            positionX = x;
            positionY = y;

            this.type = type;
        }

        #region Fields

        int possibleSteps = 0;

        int height = 0;
        int width = 0;

        int positionX = 0;
        int positionY = 0;
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
            get { return positionX; }
        }

        public int Y
        {
            get { return positionY; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion

    }
}

