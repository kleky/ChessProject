﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarWinds.MSP.Chess.Enums;
using SolarWinds.MSP.Chess.Pieces;

namespace SolarWinds.MSP.Chess
{
    //test that a black pawn can only move down the board
    //test that a white pawn can only move up the board

    [TestClass]
	public class PawnTest
	{
		private ChessBoard chessBoard;
		private Pawn pawnBlack;
		private Pawn pawnBlack2;
        private Pawn pawnWhite;

		[TestInitialize]
		public void SetUp()
		{
		    chessBoard = ChessApi.Factory.CreateChessBoard();
			pawnBlack = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);
			pawnBlack2 = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);
			pawnWhite = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.White, chessBoard: chessBoard);
			
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
            var outcome = chessBoard.Add(pawnBlack, 6, 3);

            Assert.AreEqual(outcome, MethodOutcome.Success);
			Assert.AreEqual(pawnBlack.XCoordinate, 6);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
		    var outcome = chessBoard.Add(pawnBlack, 6, 3);

            Assert.AreEqual(outcome, MethodOutcome.Success);
			Assert.AreEqual(pawnBlack.YCoordinate, 3);
        }

	    [TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
		    chessBoard.Add(pawnBlack, 6, 3);
		    var outcome = pawnBlack.Move(MovementType.Move, 7, 3);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
            Assert.AreEqual(pawnBlack.XCoordinate, 6);
            Assert.AreEqual(pawnBlack.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			chessBoard.Add(pawnBlack, 6, 3);
		    var outcome = pawnBlack.Move(MovementType.Move, 4, 3);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
            Assert.AreEqual(pawnBlack.XCoordinate, 6);
            Assert.AreEqual(pawnBlack.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			chessBoard.Add(pawnBlack, 6, 3);
		    var outcome = pawnBlack.Move(MovementType.Move, 6, 2);

            Assert.AreEqual(outcome, MoveOutcome.Moved);
			Assert.AreEqual(pawnBlack.XCoordinate, 6);
            Assert.AreEqual(pawnBlack.YCoordinate, 2);
		}

	    [TestMethod]
	    public void Pawn_Move_Forward_Onto_Own_Colour_DoesNotMove()
	    {
	        chessBoard.Add(pawnBlack, 6, 3);
	        chessBoard.Add(pawnBlack2, 6, 2);
	        var outcome = pawnBlack.Move(MovementType.Move, 6, 2);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
	        Assert.AreEqual(pawnBlack.XCoordinate, 6);
            Assert.AreEqual(pawnBlack.YCoordinate, 3);
	    }

	    [TestMethod]
	    public void Pawn_LegalPositions_Single_Move_Forward_Onto_Enemy_Colour()
	    {
	        chessBoard.Add(pawnBlack, 6, 3);
	        chessBoard.Add(pawnWhite, 6, 2);

            Assert.IsTrue(pawnBlack.LegalPositions().Count == 1);
	        Assert.IsTrue(pawnBlack.LegalPositions().Contains(6, 2));
        }

        [TestMethod]
	    public void Pawn_LegalPositions_Only_One_Move_Forward()
	    {
	        chessBoard.Add(pawnBlack, 0, 6);

            Assert.IsTrue(pawnBlack.LegalPositions().Count == 1);
	        Assert.IsTrue(pawnBlack.LegalPositions().Contains(0, 5));
	    }

        [TestMethod]
	    public void Pawn_LegalPositions_End_Of_Board_With_No_Moves()
	    {
	        chessBoard.Add(pawnBlack, 4, 0);

	        Assert.IsTrue(pawnBlack.LegalPositions().Empty());
	    }
    }
}
