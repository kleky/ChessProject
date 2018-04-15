using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.Pieces
{
    public interface IPiece
    {
        IChessBoard ChessBoard { get; }
        int XCoordinate { get; }
        int YCoordinate { get; }
        PieceColor PieceColor { get; }
        PieceType PieceType { get; }

        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        int MaxPieceCount { get; }

        /// <summary>
        /// The count of this piece type on the ChessBoard has reached
        /// the limit of MaxPieceCount
        /// </summary>
        bool BoardCountLimitReached { get; }

        /// <summary>
        /// Positionas available for legal next move
        /// </summary>
        /// <returns></returns>
        LegalPositions LegalPositions();

        void SetCoordinates(int xCoordinate, int yCoordinate);
    }
}
