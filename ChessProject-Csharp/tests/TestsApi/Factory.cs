using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public static partial class TestsApi
    {
        public static partial class Factory
        {
            
            public static ChessBoard CreateChessBoard() =>
                ChessBoard.Create();
            
            public static Pawn CreatePawn(PieceColor pieceColor, ChessBoard chessBoard) =>
                (Pawn)PieceFactory.CreatePiece(pieceColor, chessBoard, PieceType.Pawn);

        }
    }
}
