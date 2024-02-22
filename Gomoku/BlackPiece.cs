using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class BlackPiece :Piece
    {
        public BlackPiece(int x, int y) : base(x, y)
        {
            this.Image = Resources.Resource1.black;

        }

        public BlackPiece(Point point) : base(point)
        {
            Image = Resources.Resource1.black; ;
        }

        internal override PieceType GetPieceTyep()
        {
            return PieceType.BLACK;
        }
    }
}
