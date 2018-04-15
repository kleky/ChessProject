using System;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        public BoardPosition[,] Pieces { get; } = ChessFactory.CreateBoardPositions(MaxBoardWidth, MaxBoardHeight);

        protected ChessBoard()
        {
        }

        public static ChessBoard Create() => new ChessBoard();

        public MethodOutcome Add(IPiece piece, int xCoordinate, int yCoordinate)
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
