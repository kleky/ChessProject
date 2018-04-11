﻿using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn
    {
        private ChessBoard chessBoard;
        private int xCoordinate;
        private int yCoordinate;
        private PieceColor pieceColor;

        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            private set { pieceColor = value; }
        }

        public Pawn(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        public void Move(MovementType movementType, int newX, int newY)
        {
            int moveValue = PieceColor == PieceColor.White ? 1 : -1;

            switch (movementType)
            {
                case MovementType.Move:
                    if (newX == xCoordinate && newY == yCoordinate + moveValue &&
                        chessBoard.IsLegalBoardPosition(newX, newY))
                    {
                        xCoordinate = newX;
                        yCoordinate = newY;
                    }
                    return;
                default:
                    throw new NotImplementedException("Pawn Move capture");
            }

        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
