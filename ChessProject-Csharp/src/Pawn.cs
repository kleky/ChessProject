using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {}
        
        public override int MaxPieceCount { get; } = ChessBoard.MaxBoardWidth;

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
