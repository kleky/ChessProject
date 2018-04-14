using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        public BoardPosition[,] Pieces;

        protected ChessBoard()
        {
            Pieces = new BoardPosition[MaxBoardWidth + 1, MaxBoardHeight + 1];

            for (int x = 0; x <= MaxBoardWidth; x++)
                for (int y = 0; y <= MaxBoardHeight; y++)
                    Pieces[x, y] = new BoardPosition();
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
            foreach (BoardPosition position in Pieces)
            {
                if (!position.IsEmpty() &&
                    position.Occupier.GetType() == piece.GetType()) //todo  refer to enum
                {
                    count++;
                }
            }
            return count;
        }

        public MethodOutcome Add(Piece piece, int xCoordinate, int yCoordinate)
        {
            if (Pieces[xCoordinate,yCoordinate].IsEmpty() &&
                IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                CountOfPieces(piece) < piece.MaxPieceCount)
            {
                Pieces[xCoordinate, yCoordinate].Occupier = piece;
                piece.SetCoordinates(xCoordinate, yCoordinate);
                return MethodOutcome.Success;
            }
            return MethodOutcome.Fail;
        }

        /// <summary>
        /// Do the provided co-ordinates exist
        /// </summary>
        /// <param name="xCoordinate">x column</param>
        /// <param name="yCoordinate">y row</param>
        /// <returns></returns>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || xCoordinate > MaxBoardWidth) return false;
            if (yCoordinate < 0 || yCoordinate > MaxBoardHeight) return false;

            return true;
        }



    }
}
