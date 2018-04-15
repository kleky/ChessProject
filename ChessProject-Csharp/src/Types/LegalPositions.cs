using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SolarWinds.MSP.Chess.Pieces;

namespace SolarWinds.MSP.Chess.Types
{
    /// <summary>
    /// Container type for a list of position coordinates
    /// </summary>
    public class LegalPositions
    {
        protected LegalPositions(IChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
            positionsList = new List<LegalPosition>();
        }

        protected IChessBoard chessBoard { get; }
        protected List<LegalPosition> positionsList { get; }

        public static LegalPositions Create(IChessBoard chessBoard) => new LegalPositions(chessBoard);

        public LegalPositions Add(int xCoordinate, int yCoordinate, IPiece piece)
        {
            if (chessBoard.IsLegalBoardPosition(xCoordinate, yCoordinate) &&
                (chessBoard.Pieces[xCoordinate, yCoordinate].IsEmpty() ||
                chessBoard.Pieces[xCoordinate, yCoordinate].Occupier.PieceColor != piece.PieceColor))
            {
                positionsList.Add(LegalPosition.New(xCoordinate, yCoordinate));
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