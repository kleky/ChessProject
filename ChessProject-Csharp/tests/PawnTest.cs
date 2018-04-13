using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    //test that a black pawn can only move down the board
    //test that a white pawn can only move up the board

    [TestClass]
	public class PawnTest
	{
		private ChessBoard chessBoard;
		private Pawn pawn;
		private Pawn pawn2;

		[TestInitialize]
		public void SetUp()
		{
		    chessBoard = ChessApi.Factory.CreateChessBoard();
			pawn = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);
			pawn2 = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.White, chessBoard: chessBoard);
			
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
            var outcome = chessBoard.Add(pawn, 6, 3, PieceColor.Black);

            Assert.AreEqual(outcome, MethodOutcome.Success);
			Assert.AreEqual(pawn.XCoordinate, 6);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
		    var outcome = chessBoard.Add(pawn, 6, 3, PieceColor.Black);

            Assert.AreEqual(outcome, MethodOutcome.Success);
			Assert.AreEqual(pawn.YCoordinate, 3);
        }

	    [TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
		    chessBoard.Add(pawn, 6, 3, PieceColor.Black);
		    var outcome = pawn.Move(MovementType.Move, 7, 3);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
		    var outcome = pawn.Move(MovementType.Move, 4, 3);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
		    var outcome = pawn.Move(MovementType.Move, 6, 2);

            Assert.AreEqual(outcome, MoveOutcome.Moved);
			Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 2);
		}

	    [TestMethod]
	    public void Pawn_Move_IllegalCoordinates_Forward_DoesNotMove()
	    {
	        chessBoard.Add(pawn, 6, 3, PieceColor.Black);
	        chessBoard.Add(pawn2, 6, 2, PieceColor.White);
	        var outcome = pawn.Move(MovementType.Move, 6, 2);

            Assert.AreEqual(outcome, MoveOutcome.Illegal);
	        Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
	    }

    }
}
