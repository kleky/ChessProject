using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;

namespace SolarWinds.MSP.Chess
{
    public static partial class ChessApi {
        public static partial class Factory
        {
            
            public static IChessBoard CreateChessBoard() =>
                ChessBoard.Create();
            
            public static IPiece CreatePawn(PieceColor pieceColor, IChessBoard chessBoard) =>
                ChessFactory.CreatePiece(pieceColor, chessBoard, PieceType.Pawn);

        }
    }
}
