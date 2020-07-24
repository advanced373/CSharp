using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        private string sign;   //X or O
        public string Sign { get { return sign; } }
        public Player(string sign)
        {
            this.sign = sign;
        }
    }
}
