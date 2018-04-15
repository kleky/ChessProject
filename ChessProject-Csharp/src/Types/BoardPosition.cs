using SolarWinds.MSP.Chess.Pieces;

namespace SolarWinds.MSP.Chess.Types
{
    public class BoardPosition
    {
        /// <summary>
        /// Piece occupying this position
        /// </summary>
        public IPiece Occupier { get; set; }

        /// <summary>
        /// Position is vacant/no piece present
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Occupier == null;
    }
}