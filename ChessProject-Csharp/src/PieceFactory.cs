using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class PieceFactory
    {
        public static Piece CreatePiece(PieceColor pieceColor, ChessBoard chessBoard, PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return Pawn.Create(pieceColor, chessBoard);
            }

            throw new ArgumentException("Wrong type provided to CreatePiece");
        }
    }
}
