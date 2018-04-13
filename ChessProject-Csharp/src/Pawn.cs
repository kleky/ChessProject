using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        protected Pawn(PieceColor pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard){}

        public static Pawn Create(PieceColor pieceColor, ChessBoard chessBoard) =>
            new Pawn(pieceColor, chessBoard);

        
        public override int MaxPieceCount { get; } = ChessBoard.MaxBoardWidth;

        public override MoveOutcome Move(MovementType movementType, int newX, int newY)
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
                        return MoveOutcome.Moved;
                    }
                    return MoveOutcome.Illegal;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }
        }        
    }

    
}
