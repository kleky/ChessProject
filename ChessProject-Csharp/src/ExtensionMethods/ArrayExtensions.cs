using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.ExtensionMethods
{
    public static class ArrayExtensions
    {
        public static int CountPieces(this BoardPosition[,] boardPositions, PieceType pieceType)
        {
            int count = 0;
            foreach (BoardPosition position in boardPositions)
            {
                if (!position.IsEmpty() &&
                    position.Occupier.PieceType == pieceType)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
