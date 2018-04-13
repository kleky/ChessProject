using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess.Enums
{
    public enum MoveOutcome
    {
        /// <summary>
        /// Move not allowed for Piece
        /// </summary>
        Illegal,
        /// <summary>
        /// Move successfull and position changed
        /// </summary>
        Moved
    }
}
