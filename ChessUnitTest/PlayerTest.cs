using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Chess;

namespace ChessUnitTest
{
    public class PlayerTest
    {

        //katie-Tests constructor of Player class 
        [Fact]

        public void TestPlayerConstruction()
        {
            Player testPlayer = new Player("Katie", 2);

            Assert.Equal("Katie", testPlayer.Username);
            Assert.Equal(2, testPlayer.UserId);
        }

        //katie-Tests scenario of user entering valid username; expect to set username and return true
        [Fact]

        public void TestNameInputValid()
        {
            Player testPlayer = new Player("",1);

           bool valid = testPlayer.SetUsername("  Katie");

            Assert.Equal("Katie",testPlayer.Username);
            Assert.True(valid);
        }

        //katie-Tests scenario of user entering invalid username; expect not to change username and return false
        [Fact]

        public void TestNameInputInvalid()
        {
            Player testPlayer = new Player( "invalid", 1);

            bool invalid = testPlayer.SetUsername(" ");

            Assert.Equal("invalid", testPlayer.Username);
            Assert.False(invalid);
        }

    }
}
