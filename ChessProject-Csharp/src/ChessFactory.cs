using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess
{
    public class ChessFactory
    {
        public static IPiece CreatePiece(
            PieceColor pieceColor,
            IChessBoard chessBoard,
            PieceType pieceType)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return Pawn.Create(
                        pieceColor: pieceColor, 
                        pieceType: pieceType, 
                        chessBoard: chessBoard);
            }

            throw new ArgumentException("Wrong type provided to CreatePiece");
        }

        public static IChessBoard CreateChessBoard()
        {
            return ChessBoard.Create();
        }

        public static BoardPosition[,] CreateBoardPositions(int maxWidth, int maxHeight)
        {
            BoardPosition[,] pieces = new BoardPosition[maxWidth, maxHeight];

            for (int x = 0; x <= maxWidth - 1; x++)
            for (int y = 0; y <= maxHeight - 1; y++)
                pieces[x, y] = new BoardPosition();

            return pieces;
        }
    }
}
