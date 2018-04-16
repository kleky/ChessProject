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
        public BoardPosition[,] Pieces { get; }

        protected ChessBoard(BoardPosition[,] pieces)
        {
            Pieces = pieces;
        }

        public static ChessBoard Create(BoardPosition[,] pieces) => new ChessBoard(pieces);

        public MethodOutcome Add(IPiece piece, int xCoordinate, int yCoordinate)
        {
            if (Pieces[xCoordinate, yCoordinate].IsEmpty() &&
                IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                !piece.BoardCountLimitReached)
            {
                Pieces[xCoordinate, yCoordinate].Occupier = piece;
                piece.SetCoordinates(xCoordinate, yCoordinate);
                return MethodOutcome.Success;
            }
            return MethodOutcome.Fail;
        }

        public MoveOutcome Move(MovementType movementType, int xCoordFrom, int yCoordFrom, int xCoordTo, int yCoordTo)
        {
            if (!IsLegalBoardPosition(xCoordFrom, yCoordFrom) ||
                !IsLegalBoardPosition(xCoordTo, yCoordTo) ||
                Pieces[xCoordFrom, yCoordFrom].IsEmpty())
                return MoveOutcome.Illegal;

            var piece = Pieces[xCoordFrom, yCoordFrom].Occupier;

            switch (movementType)
            {
                case MovementType.Move:
                    if (piece.LegalPositions().Contains(xCoordTo, yCoordTo))
                    {
                        piece.SetCoordinates(xCoordTo, yCoordTo);
                        return MoveOutcome.Moved;
                    }
                    return MoveOutcome.Illegal;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }
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
