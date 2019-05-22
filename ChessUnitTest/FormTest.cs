using System;
using Xunit;
using Chess;
using System.IO;
using System.Drawing;
// using System.Windows.Forms;

namespace ChessUnitTest
{
    public class FormTest
    {
        Chess.ChessForm TestChessForm = new Chess.ChessForm();
        Chess.ChessPanel TestChessPanel = new Chess.ChessPanel();
        [Fact]
        void CheckTileForPieceTest()
        {
            int[,] dummyArray = new int[,]
            {
                { 0, 2, 3, 4, 6, 5, 4, 3, 2 },
                { 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 7, 7, 7, 7, 7, 7, 7, 7 },
                { 0, 8, 9, 10, 12, 11, 10, 9, 8 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            // Assert.True(TestChessForm.CheckTileForPieceTest(1, 1, TestChessPanel));
            // Assert.False(TestChessForm.CheckTileForPieceTest(0, 0, TestChessPanel));
        }

        void GetGamePieceByNumberTest()
        {
            // Assert.True(TestChessForm.GetGamePieceByNumber(0), "None");
        }
    }
}
