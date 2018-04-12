using System;

namespace SolarWinds.MSP.Chess
{
    public class Pieces
    {
        public Pieces()
        {
            pieces = new Piece[ChessBoard.MaxBoardWidth + 1, ChessBoard.MaxBoardHeight + 1];
        }

        //todo - use dictionary instead
        protected Piece[,] pieces;

        public void Add(Piece piece, int xCoordinate, int yCoordinate)
        {
            pieces[xCoordinate, yCoordinate] = piece;
        }

        public Piece Fetch(int xCoordinate, int yCoordinate)
        {
            try
            {
                return pieces[xCoordinate, yCoordinate];
            }
            catch
            {
                return null;
            }
        }
    }
}