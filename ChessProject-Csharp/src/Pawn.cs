using System;
using System.Collections.Generic;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        protected Pawn(PieceColor pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard){}

        public static Pawn Create(PieceColor pieceColor, ChessBoard chessBoard) =>
            new Pawn(pieceColor, chessBoard);

        public override int MaxPieceCount { get; } = ChessBoard.MaxBoardWidth;

        public override LegalPositions LegalPositions()
        {
            int directionModifer = PieceColor == PieceColor.White ? 1 : -1;

            return Chess.LegalPositions.Create(ChessBoard)
                    .Add(XCoordinate, YCoordinate + directionModifer, this);
        } 

    }

    
}
