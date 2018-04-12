using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

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
			chessBoard = new ChessBoard();
			pawn = new Pawn(PieceColor.Black);
			pawn2 = new Pawn(PieceColor.White);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			Assert.AreEqual(pawn.XCoordinate, 6);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			Assert.AreEqual(pawn.YCoordinate, 3);
		}

	    [TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 7, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 4, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			chessBoard.Add(pawn, 6, 3, PieceColor.Black);
			pawn.Move(MovementType.Move, 6, 2);
			Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 2);
		}

	    [TestMethod]
	    public void Pawn_Move_IllegalCoordinates_Forward_DoesNotMove()
	    {
	        chessBoard.Add(pawn, 6, 3, PieceColor.Black);
	        chessBoard.Add(pawn2, 6, 2, PieceColor.White);
            pawn.Move(MovementType.Move, 6, 2);
	        Assert.AreEqual(pawn.XCoordinate, 6);
	        Assert.AreEqual(pawn.YCoordinate, 3);
	    }

    }
}
