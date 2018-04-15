using System;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.ExtensionMethods;
using SolarWinds.MSP.Chess.Types;

namespace SolarWinds.MSP.Chess.Pieces
{
    public class PieceBase : IPiece
    {
        protected PieceBase(
            PieceColor pieceColor, 
            PieceType pieceType, 
            IChessBoard chessBoard,
            int maxPieceCount)
        {
            PieceColor = pieceColor;
            PieceType = pieceType;
            ChessBoard = chessBoard;
            MaxPieceCount = maxPieceCount;
        }

        public IChessBoard ChessBoard { get; }

        public int XCoordinate { get; protected set; }

        public int YCoordinate { get; protected set; }

        public PieceColor PieceColor { get; }

        public PieceType PieceType { get; }

        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        public int MaxPieceCount { get; }

        /// <summary>
        /// The count of this piece type on the ChessBoard has reached
        /// the limit of MaxPieceCount
        /// </summary>
        public bool BoardCountLimitReached =>
            ChessBoard.Pieces.CountPieces(PieceType) >= MaxPieceCount;

        /// <summary>
        /// Positionas available for legal next move
        /// </summary>
        /// <returns></returns>
        public virtual LegalPositions LegalPositions()
        {
            throw new NotImplementedException("LegalPositions not implemented");
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        public void SetCoordinates(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }


    
}
