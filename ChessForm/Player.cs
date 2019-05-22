using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Player
    {
      
        public string Username { get; private set; }
        public int UserId { get; private set; }



        public Player(string usernameInput, int userIdInput)
        {
            Username = usernameInput;
            UserId = userIdInput;

        }


        private bool ValidateUsername(string input)
        {
            if(string.IsNullOrWhiteSpace(input.Trim()))
                return false;
            return true;
        }

        public bool SetUsername(string input)
        {
           if(ValidateUsername(input))
            {
                Username = input.Trim();
                return true;
            }
            return false;
        }

    }
}
