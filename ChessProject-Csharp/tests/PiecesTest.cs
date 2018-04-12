using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PiecesTest
    {
       
		[TestMethod]
		public void Pieces_Add_Pawn_and_Fetch_Pawn()
		{
		    Pieces pieces = new Pieces();
            Pawn pawn = new Pawn(PieceColor.White);

            pieces.Add(pawn, 0, 1);

            Assert.AreEqual(pawn, pieces.Fetch(0, 1));
		}

        [TestMethod]
        public void Pieces_Fetch_Invalid_Coordinates_Returns_Null()
        {
		    Pieces pieces = new Pieces();
            var result = pieces.Fetch(10, 10);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Pieces_Fetch_Valid_Coordinates_Empty_Space_Returns_Null()
        {
		    Pieces pieces = new Pieces();
            var result = pieces.Fetch(0, 0);

            Assert.IsNull(result);
        }


    }
}
