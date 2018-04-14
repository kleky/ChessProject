using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess
{
    public class Position
    {
        protected Position (int xCoordinates, int yCoordinates)
        {
            this.xCoordinates = xCoordinates;
            this.yCoordinates = yCoordinates;
        }
        public int xCoordinates { get; }
        public int yCoordinates { get; }

        public static Position New(int xCoordinates, int yCoordinates) =>
            new Position(xCoordinates, yCoordinates);
    }
}
