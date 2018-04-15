using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.Pieces
{
    public class Pawn : PieceBase
    {
        protected Pawn(
            PieceColor pieceColor, 
            PieceType pieceType, 
            IChessBoard chessBoard) : 
            base(pieceColor, pieceType, chessBoard, maxPieceCount: 8){}

        public static Pawn Create(PieceColor pieceColor, PieceType pieceType, IChessBoard chessBoard) =>
            new Pawn(pieceColor, pieceType, chessBoard);

        public override LegalPositions LegalPositions()
        {
            int directionModifer = PieceColor == PieceColor.White ? 1 : -1;

            return Types.LegalPositions.Create(ChessBoard)
                    .Add(XCoordinate, YCoordinate + directionModifer, this);
        } 

    }

    
}
