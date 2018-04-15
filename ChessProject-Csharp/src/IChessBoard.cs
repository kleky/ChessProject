using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess
{
    public interface IChessBoard
    {
        BoardPosition[,] Pieces { get; }

        MethodOutcome Add(IPiece piece, int xCoordinate, int yCoordinate);

        /// <summary>
        /// Do the provided co-ordinates exist
        /// </summary>
        /// <param name="xCoordinate">x column</param>
        /// <param name="yCoordinate">y row</param>
        /// <returns></returns>
        bool IsLegalBoardPosition(int xCoordinate, int yCoordinate);
    }
}