using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Chess;

namespace ChessUnitTest
{
    public class BoardUnitTests
    {
        [Fact]
        public void DisplayDebug()
        {
            //List<ChessPiece> pieces = new List<ChessPiece>
            //{
            //    new TestPiece(0, 0),
            //    new TestPiece(0, 7),
            //    new TestPiece(7, 0),
            //    new TestPiece(1, 9),
            //    new TestPiece(7, 7),
            //    new TestPiece(3, 4),
            //    new TestPiece(9, 1)
            //};

            Board board = new Board();

            board.ShowBoardState();
        }
    }
}
