using System;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private Piece[,] pieces;

        public ChessBoard ()
        {
            pieces = new Piece[MaxBoardWidth + 1, MaxBoardHeight + 1];
        }

        public void Add(Piece piece, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            if (IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                pieces[xCoordinate, yCoordinate] = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                piece.ChessBoard = this;
            }
            else
            {
                piece.XCoordinate = -1;
                piece.YCoordinate = -1;
            }
            
        }

        //Are co-ords legal and is the spot vacant
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || xCoordinate > MaxBoardWidth) return false;
            if (yCoordinate < 0 || yCoordinate > MaxBoardHeight) return false;

            if (pieces[xCoordinate, yCoordinate] != null) return false;

            return true;
        }

    }
}
