using Gomoku.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class WhitePiece : Piece
    {
        public WhitePiece(int x, int y) : base(x, y)
        {
            this.Image = Resources.Resource1.white;

        }
        public WhitePiece(Point point) : base(point)
        {
            Image = Resources.Resource1.white;
        }
        internal override PieceType GetPieceTyep()
        {
            return PieceType.WHITE;
        }
    }
}
