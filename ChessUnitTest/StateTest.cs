using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Chess;

namespace ChessUnitTest
{
    public class StateTest
    {

        [Fact]
        public void TestStateConstruction()
        {
            int[,] testBoard = new int[9, 9]
            {

                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 15, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }

            };
            int testTurn = 1;

            State testState = new State(testBoard, testTurn);

            Assert.Equal(1, testState.CurrentTurn);
            Assert.Equal(15, testState.Board[5,5]);

        }
    }
}
