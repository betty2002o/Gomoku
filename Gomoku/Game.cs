using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Game
    {
        private static PieceType currentPlayer = PieceType.BLACK;
        private static PieceType winner = PieceType.NONE;
        internal static PieceType Winner { get { return winner; } }

        internal static Piece PlaceAPiece(int x, int y)
        {
            Piece piece = Board.PlacePieceOnClosetNode(x, y, currentPlayer);
            if (piece != null)
            {
                CheckWinner(Board.LastPlaceNode);
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;
            }

            return piece;
        }
        private static void CheckWinner(Point lastPlaceNode)
        {
            int count = 1, countReverse = 0;
            int targetX = 0, targetY = 0;
        
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                        continue;
                    while (count < 5)
                    {

                        targetX = lastPlaceNode.X + xDir * count;
                        targetY = lastPlaceNode.Y + yDir * count;
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE ||
                            Board.GetPieceType(targetX, targetY) == PieceType.NONE ||
                            Board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            countReverse = 0;
                            while (countReverse + count < 5)
                            {
                                countReverse++;
                                targetX = lastPlaceNode.X + xDir * countReverse * -1;
                                targetY = lastPlaceNode.Y + yDir * countReverse * -1;
                                if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                                    targetY >= Board.NODE_COUNT_ONESIDE ||
                                    Board.GetPieceType(targetX, targetY) == PieceType.NONE ||
                                    Board.GetPieceType(targetX, targetY) != currentPlayer)
                                {
                                    goto nextdir;                          

                                }
                                if (countReverse + count == 5)
                                {
                                    winner = currentPlayer;
                                    return;
                                }
                            }
                        }
                        count++;
                    }
                nextdir:
                    if (count == 5)
                    {
                        winner = currentPlayer;
                        return;
                    }
                    else
                        count = 1;
                }
            }
        }
        internal static bool CanBePlaced(int x, int y)
        {
            return Board.CanBePlaced(x, y);
        }
    }
}
