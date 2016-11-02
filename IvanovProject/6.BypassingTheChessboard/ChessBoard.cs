using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _6.BypassingTheChessboard
{
    class ChessBoard
    {
        #region Fields

        #region Modeling Fields

        // Number of cells in width
        int Size { get; } = 5;
        // Array of cells
        Cell[,] Board;

        #endregion

        #region Drawing Fields

        Graphics Gr { get; }
        // Width of paint area
        int Width { get; }

        #endregion

        #endregion

        ChessBoard(Graphics gr, int Size)
        {
            this.Gr = gr;
            this.Size = Size;
            Board = new Cell[this.Size, this.Size];

            for (int column = 0; column < this.Size; ++column)
            {
                for (int row = 0; row < this.Size; ++row)
                {
                    
                }
            }
        }

    }
}
