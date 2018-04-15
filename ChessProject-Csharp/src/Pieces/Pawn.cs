using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.Pieces
{
    public class Pawn : Piece
    {
        protected Pawn(
            PieceColor pieceColor, 
            PieceType pieceType, 
            ChessBoard chessBoard) : 
            base(pieceColor, pieceType, chessBoard, maxPieceCount: 8){}

        public static Pawn Create(PieceColor pieceColor, PieceType pieceType, ChessBoard chessBoard) =>
            new Pawn(pieceColor, pieceType, chessBoard);

        public override LegalPositions LegalPositions()
        {
            int directionModifer = PieceColor == PieceColor.White ? 1 : -1;

            return Types.LegalPositions.Create(ChessBoard)
                    .Add(XCoordinate, YCoordinate + directionModifer, this);
        } 

    }

    
}
