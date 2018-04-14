namespace SolarWinds.MSP.Chess
{
    public class BoardPosition 
    {
        /// <summary>
        /// Piece occupying this position
        /// </summary>
        public Piece Occupier { get; set; }

        /// <summary>
        /// Position is vacant/no piece present
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Occupier == null;
    }
}