using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public abstract class Piece
    {
        public ChessBoard ChessBoard { get; }
        public int XCoordinate { get; protected set; }
        public int YCoordinate { get; protected set; }
        public PieceColor PieceColor { get; }
        
        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        public abstract int MaxPieceCount { get; }

        protected Piece(PieceColor pieceColor, ChessBoard chessBoard)
        {
            PieceColor = pieceColor;
            ChessBoard = chessBoard;
        }

        public abstract MoveOutcome Move(MovementType movementType, int newX, int newY);

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
