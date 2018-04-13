using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{

    [TestClass]
	public class ChessBoardTest
	{
		private ChessBoard chessBoard;

        [TestInitialize]
		public void SetUp()
        {
            chessBoard = ChessApi.Factory.CreateChessBoard();
        }

        [TestMethod]
		public void Has_MaxBoardWidth_of_7()
		{
			Assert.AreEqual(ChessBoard.MaxBoardWidth, 7);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_7()
		{
			Assert.AreEqual(ChessBoard.MaxBoardHeight, 7);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(0, 0);
			Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(5, 5);
            Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(11, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(0, 9);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(11, 0);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_X_Values()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(-1, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_Y_Values()
		{
			var isValidPosition = chessBoard.IsLegalBoardPosition(5, -1);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void Avoids_Duplicate_Positioning()
		{
			Pawn firstPawn = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);
			Pawn secondPawn = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);

			var firstPawnOutcome =  chessBoard.Add(firstPawn, 6, 3, PieceColor.Black);
		    var secondPawnOutcome = chessBoard.Add(secondPawn, 6, 3, PieceColor.Black);

            Assert.AreEqual(firstPawnOutcome, MethodOutcome.Success);
            Assert.AreEqual(secondPawnOutcome, MethodOutcome.Fail);
			Assert.AreEqual(firstPawn.XCoordinate, 6);
            Assert.AreEqual(firstPawn.YCoordinate, 3);
            
		}

        [TestMethod]
		public void Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
				Pawn pawn = ChessApi.Factory.CreatePawn(pieceColor: PieceColor.Black, chessBoard: chessBoard);
                int row = i / ChessBoard.MaxBoardWidth;

                var outcome = chessBoard.Add(pawn, i % ChessBoard.MaxBoardWidth, 6 + row, PieceColor.Black);

                if (row < 1)
				{
                    Assert.AreEqual(outcome, MethodOutcome.Success);
				    Assert.AreEqual(pawn.XCoordinate, (i % ChessBoard.MaxBoardWidth));
				    Assert.AreEqual(pawn.YCoordinate, (6 + row));
				}
				else
                    Assert.AreEqual(outcome, MethodOutcome.Fail);

            }
        }


	}
}
