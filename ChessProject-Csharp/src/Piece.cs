using System;

namespace SolarWinds.MSP.Chess
{
    public abstract class Piece
    {
        public ChessBoard ChessBoard { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public PieceColor PieceColor { get; }

        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        public abstract int MaxPieceCount { get; }

        protected Piece(PieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        public abstract void Move(MovementType movementType, int newX, int newY);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
