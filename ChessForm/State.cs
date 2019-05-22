using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class State
    {

        public int[,] Board { get; set; } = new int[9, 9];
        public int CurrentTurn { get; set; }


        public State(int[,] board, int currentTurn)
        {
            Board = board;
            CurrentTurn = currentTurn;
        }

    }
}
