using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Chess;
namespace ChessUnitTest
{
    public class GameTest
    {

        [Fact]

        public void TestGameConstructor()
        {
            Game testGame = new Game();

            Assert.Equal("First", testGame.Players[0].Username);
            Assert.Equal(2, testGame.Players[1].UserId);
        }


        [Fact]

        public void TestGameRedo()
        {
            Game testGame = new Game();

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
            testGame.UndoStack.Push(testState);
            testGame.Undo();

            Assert.Equal(testState, testGame.RedoStack.Peek());

            testGame.Redo();

            Assert.Equal(testState, testGame.UndoStack.Peek());
            

        }
    }
}
