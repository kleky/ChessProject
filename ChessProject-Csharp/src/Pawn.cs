using System;
using System.Collections.Generic;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        protected Pawn(PieceColor pieceColor, PieceType pieceType, ChessBoard chessBoard) : 
            base(pieceColor, pieceType, chessBoard){}

        public static Pawn Create(PieceColor pieceColor, PieceType pieceType, ChessBoard chessBoard) =>
            new Pawn(pieceColor, pieceType, chessBoard);

        public override int MaxPieceCount { get; } = ChessBoard.MaxBoardWidth;

        public override LegalPositions LegalPositions()
        {
            int directionModifer = PieceColor == PieceColor.White ? 1 : -1;

            return Chess.LegalPositions.Create(ChessBoard)
                    .Add(XCoordinate, YCoordinate + directionModifer, this);
        } 

    }

    
}
