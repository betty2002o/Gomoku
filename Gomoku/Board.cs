using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public abstract class Board
    {
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 20;
        private static readonly int NODE_DISTANCE = 75;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        //private static Piece[,] pieces = new Piece[9, 9];
        private static Point lastPlaceNode;
        internal static Point LastPlaceNode { get { return lastPlaceNode; } }


        internal static readonly int NODE_COUNT_ONESIDE = 9;
        //二維陣列，記錄棋盤上的棋子及其位置
        private static Piece[,] pieces = new Piece[NODE_COUNT_ONESIDE, NODE_COUNT_ONESIDE];



        // place the pieces on closet node on click
        internal static Piece PlacePieceOnClosetNode(int x, int y, PieceType type)
        {
            if (CanBePlaced(x, y))
            {
                lastPlaceNode = findTheClosestNodes(x, y);
                if (type == PieceType.BLACK)
                {
                    pieces[lastPlaceNode.X, lastPlaceNode.Y] = new BlackPiece(convertNodeToFormPosition(lastPlaceNode));
                }
                else if (type == PieceType.WHITE)
                {
                    pieces[lastPlaceNode.X, lastPlaceNode.Y] = new WhitePiece(convertNodeToFormPosition(lastPlaceNode));

                }
                return pieces[lastPlaceNode.X, lastPlaceNode.Y];

            }
            return null;


        }

        internal static PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            Piece piece = pieces[nodeIdX, nodeIdY];
            if (piece == null)
                return PieceType.NONE;
            else
                return piece.GetPieceTyep();
        }
        private static Point convertNodeToFormPosition(Point node)
        {

            int coordinateX = node.X * NODE_DISTANCE + OFFSET;
            int coordinateY = node.Y * NODE_DISTANCE + OFFSET;

            return new Point(coordinateX, coordinateY);
        }


        //check if the coordinate is within the board for cursor
        public static bool CanBePlaced(int x, int y)
        {

            Point coordinate = findTheClosestNodes(x, y);

            return coordinate == NO_MATCH_NODE ? false : true;
        }

        private static Point findTheClosestNodes(int x, int y)
        {
            int coordinateX = findTheClosestNode(x);
            int coordinateY = findTheClosestNode(y);

            return coordinateX == -1 || coordinateY == -1 || coordinateX > 8 || coordinateY  > 8 ? NO_MATCH_NODE : new Point(coordinateX, coordinateY);
        }

        // check if the coordinate is within the board, and find the closet node on single axis
        private static  int findTheClosestNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;

            int node = pos/ NODE_DISTANCE;
            int remainder = pos  % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
            {
                return node;
            }
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
            {
                return node + 1;
            }
            else return -1;


        }
    }
}
