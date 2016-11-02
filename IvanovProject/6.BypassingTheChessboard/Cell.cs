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

        Graphics Gr { get; }

        Rectangle PositionRect { get; set; } 
        int Type { get; }

        bool IsPossible { get; set; } = true;


        #endregion

        #region Constructor

        public Cell(Graphics gr, int cellType, Rectangle position)
        {
            this.Gr = gr;
            this.Type = cellType;
            this.PositionRect = position;

            Gr.DrawRectangle(Pens.Black, PositionRect);

            if (cellType == (int)CellType.WHITE)
                Gr.FillRectangle(Brushes.White, PositionRect);
            else
                Gr.FillRectangle(Brushes.Black, PositionRect);
        }

        #endregion

        #region Methods

        void MarkAsUsed()
        {
            IsPossible = false;
            Gr.FillRectangle(Brushes.Red, PositionRect);
        }

        #endregion
    }
}
