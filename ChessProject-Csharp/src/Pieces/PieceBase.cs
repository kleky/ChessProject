using System;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.ExtensionMethods;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.Pieces
{
    public class PieceBase : IPiece
    {
        protected PieceBase(
            PieceColor pieceColor, 
            PieceType pieceType, 
            IChessBoard chessBoard,
            int maxPieceCount)
        {
            PieceColor = pieceColor;
            PieceType = pieceType;
            ChessBoard = chessBoard;
            MaxPieceCount = maxPieceCount;
        }

        public IChessBoard ChessBoard { get; }

        public int XCoordinate { get; protected set; }

        public int YCoordinate { get; protected set; }

        public PieceColor PieceColor { get; }

        public PieceType PieceType { get; }

        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        public int MaxPieceCount { get; }

        /// <summary>
        /// The count of this piece type on the ChessBoard has reached
        /// the limit of MaxPieceCount
        /// </summary>
        public bool BoardCountLimitReached =>
            ChessBoard.Pieces.CountPieces(PieceType) >= MaxPieceCount;

        /// <summary>
        /// Positionas available for legal next move
        /// </summary>
        /// <returns></returns>
        public virtual LegalPositions LegalPositions()
        {
            throw new NotImplementedException("LegalPositions not implemented");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movementType"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <returns></returns>
        public virtual  MoveOutcome Move(MovementType movementType, int newX, int newY)
        {
            switch (movementType)
            {
                case MovementType.Move:
                    if (LegalPositions().Contains(newX, newY))
                    {
                        XCoordinate = newX;
                        YCoordinate = newY;
                        return MoveOutcome.Moved;
                    }
                    return MoveOutcome.Illegal;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        public void SetCoordinates(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }


    
}
