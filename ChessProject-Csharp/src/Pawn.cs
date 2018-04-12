using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor) : base(pieceColor)
        {
            MaxPieceCount = ChessBoard.MaxBoardWidth;
        }

        public override int MaxPieceCount { get; }

        public override void Move(MovementType movementType, int newX, int newY)
        {
            int moveValue = PieceColor == PieceColor.White ? 1 : -1;

            switch (movementType)
            {
                case MovementType.Move:
                    if (newX == XCoordinate && newY == YCoordinate + moveValue &&
                        ChessBoard.IsLegalBoardPosition(newX, newY))
                    {
                        XCoordinate = newX;
                        YCoordinate = newY;
                    }
                    return;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }
        }        
    }
}
