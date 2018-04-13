using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
    public class PieceFactoryTest
    {

        [TestMethod]
        public void CreatePiece_Will_Create_A_Pawn()
        {
            var chessBoard = TestsApi.Factory.CreateChessBoard();
            var piece = PieceFactory.CreatePiece(PieceColor.White, chessBoard, PieceType.Pawn);

            Assert.IsInstanceOfType(piece, typeof(Pawn));
            Assert.AreEqual(piece.PieceColor, PieceColor.White);
            Assert.AreEqual(piece.ChessBoard, chessBoard);
        }

    }
}
