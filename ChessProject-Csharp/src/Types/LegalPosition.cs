namespace SolarWinds.MSP.Chess.Types
{
    public class LegalPosition
    {
        protected LegalPosition (int xCoordinates, int yCoordinates)
        {
            this.xCoordinates = xCoordinates;
            this.yCoordinates = yCoordinates;
        }
        public int xCoordinates { get; }
        public int yCoordinates { get; }

        public static LegalPosition New(int xCoordinates, int yCoordinates) =>
            new LegalPosition(xCoordinates, yCoordinates);
    }
}
