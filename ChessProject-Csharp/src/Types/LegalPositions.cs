using System.Collections.Generic;
using System.Linq;
using SolarWinds.MSP.Chess.Pieces;

namespace SolarWinds.MSP.Chess.Types
{
    /// <summary>
    /// Container type for a list of position coordinates
    /// </summary>
    public class LegalPositions
    {
        protected LegalPositions(ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
            positionsList = new List<Position>();
        }

        protected ChessBoard chessBoard { get; }
        protected List<Position> positionsList { get; }

        public static LegalPositions Create(ChessBoard chessBoard) => new LegalPositions(chessBoard);

        public LegalPositions Add(int xCoordinate, int yCoordinate, Piece piece)
        {
            if (chessBoard.IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                (chessBoard.Pieces[xCoordinate, yCoordinate].IsEmpty() ||
                chessBoard.Pieces[xCoordinate, yCoordinate].Occupier.PieceColor != piece.PieceColor))
            {
                positionsList.Add(Position.New(xCoordinate, yCoordinate));
            }

            return this;
        }

        /// <summary>
        /// Search for a position
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns>True when coordinates found</returns>
        public bool Contains(int xCoordinate, int yCoordinate)
        {
            var contained = positionsList.Any(e => e.xCoordinates == xCoordinate && e.yCoordinates == yCoordinate);
            return contained;
        }

        /// <summary>
        /// No legal positions exist
        /// </summary>
        /// <returns>True when no positions exist</returns>
        public bool Empty() => positionsList.Count == 0;

        /// <summary>
        /// Count of positions
        /// </summary>
        public int Count => positionsList.Count;
    }
}