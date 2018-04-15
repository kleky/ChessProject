using System;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        public BoardPosition[,] Pieces;

        protected ChessBoard()
        {
            Pieces = new BoardPosition[MaxBoardWidth, MaxBoardHeight];

            for (int x = 0; x <= MaxBoardWidth - 1; x++)
                for (int y = 0; y <= MaxBoardHeight -1; y++)
                    Pieces[x, y] = new BoardPosition();
        }

        public static ChessBoard Create() => new ChessBoard();

        public MethodOutcome Add(Piece piece, int xCoordinate, int yCoordinate)
        {
            if (Pieces[xCoordinate,yCoordinate].IsEmpty() &&
                IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                !piece.BoardCountLimitReached)
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
            if (xCoordinate < 0 || xCoordinate >= MaxBoardWidth) return false;
            if (yCoordinate < 0 || yCoordinate >= MaxBoardHeight) return false;

            return true;
        }

    }
}
