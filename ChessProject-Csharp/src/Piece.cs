using System;
using System.Collections.Generic;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public abstract class Piece
    {
        protected Piece(PieceColor pieceColor, ChessBoard chessBoard)
        {
            PieceColor = pieceColor;
            ChessBoard = chessBoard;
        }

        public ChessBoard ChessBoard { get; }

        public int XCoordinate { get; protected set; }

        public int YCoordinate { get; protected set; }

        public PieceColor PieceColor { get; }

        /// <summary>
        /// Maximum number of pieces permitted on the chessboard
        /// </summary>
        public abstract int MaxPieceCount { get; }

        /// <summary>
        /// Positionas available for legal next move
        /// </summary>
        /// <returns></returns>
        public abstract LegalPositions LegalPositions();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movementType"></param>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <returns></returns>
        public virtual  MoveOutcome Move(MovementType movementType, int newX, int newY)
        {
            switch (movementType)
            {
                case MovementType.Move:
                    if (LegalPositions().Contains(newX, newY))
                    {
                        XCoordinate = newX;
                        YCoordinate = newY;
                        return MoveOutcome.Moved;
                    }
                    return MoveOutcome.Illegal;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }
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
