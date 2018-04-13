using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Piece[,] pieces;

        protected ChessBoard()
        {
            pieces = new Piece[MaxBoardWidth + 1, MaxBoardHeight + 1];
        }

        public static ChessBoard Create() => new ChessBoard();

        /// <summary>
        /// Counts all the chessboard pieces of the given type 
        /// todo - simpify this logic
        /// </summary>
        /// <param name="piece">Piece type to count</param>
        /// <returns></returns>
        public int CountOfPieces(Piece piece)
        {
            int count = 0;
            for (int x = 0; x <= MaxBoardWidth; x++)
            {
                for (int y = 0; y < MaxBoardHeight; y++)
                {
                    if (pieces[x, y] != null &&
                        pieces[x, y].GetType() == piece.GetType())
                        count++;
                }
            }
            return count;
        }

        public MethodOutcome Add(Piece piece, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                CountOfPieces(piece) < piece.MaxPieceCount)
            {
                pieces[xCoordinate, yCoordinate] = piece;
                piece.SetCoordinates(xCoordinate, yCoordinate);
                return MethodOutcome.Success;
            }
            return MethodOutcome.Fail;
        }

        /// <summary>
        /// Do the provided co-ordinates exist and is the position vacant
        /// </summary>
        /// <param name="xCoordinate">x column</param>
        /// <param name="yCoordinate">y row</param>
        /// <returns></returns>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || xCoordinate > MaxBoardWidth) return false;
            if (yCoordinate < 0 || yCoordinate > MaxBoardHeight) return false;

            if (pieces[xCoordinate, yCoordinate] != null) return false;

            return true;
        }

        

    }
}
