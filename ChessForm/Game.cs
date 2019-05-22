using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Game
    {

        public Player[] Players { get; private set; } = new Player[2];
        public Stack<State> UndoStack { get; set; }
        public Stack<State> RedoStack { get; set; }


        public Game()
        {
            Players[0] = new Player("First", 1); 
            Players[1] = new Player("second", 2);
            UndoStack = new Stack<State>();
            RedoStack = new Stack<State>();


        }


        public void Start()
        {
            string buffer;
            bool player1Name, player2Name;

            do
            {
                Console.WriteLine("Enter name for Player 1");
                buffer = Console.ReadLine();
                player1Name = Players[0].SetUsername(buffer);

            } while (!player1Name);

            do
            {
                Console.WriteLine("Enter name for Player 2");
                buffer = Console.ReadLine();
                player2Name = Players[1].SetUsername(buffer);

            } while (!player2Name);


        }

        public void Undo()
        {
            RedoStack.Push((UndoStack.Pop()));
        }

        //katie- in move/turn  needs to reset redo stack to empty and then push state in redo
        public void Redo()
        {
            UndoStack.Push(RedoStack.Pop());

        }

    


    }
}
