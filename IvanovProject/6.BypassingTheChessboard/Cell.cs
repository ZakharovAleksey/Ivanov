using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _6.BypassingTheChessboard
{
    enum CellType
    {
        BLACK = 0,
        WHITE = 1
    }

    class Cell
    {
        #region Properties

        #region Drawing Properties

        Graphics Gr { get; }

        Rectangle CellRectangle { get; set; }

        #endregion

        #region Modeling Properties

        int characteristicSize;

        int Width
        {
            get { return characteristicSize; }
        }

        int Height
        {
            get { return characteristicSize; }
        }

        int Type { get; }
        
        bool IsPossible { get; set; } = true;

        #endregion

        #endregion

        #region Constructor

        public Cell(Graphics gr, int cellType, int cellSize, Rectangle cellRectangle)
        {
            this.Gr = gr;
            this.Type = cellType;
            characteristicSize = cellSize;
            this.CellRectangle = cellRectangle;

            Gr.DrawRectangle(Pens.Black, CellRectangle);

            if (cellType == (int)CellType.WHITE)
                Gr.FillRectangle(Brushes.White, CellRectangle);
            else
                Gr.FillRectangle(Brushes.Black, CellRectangle);
        }

        #endregion

        #region Methods

        void MarkAsUsed()
        {
            IsPossible = false;
            Gr.FillRectangle(Brushes.Red, CellRectangle);
        }

        #endregion
    }
}
