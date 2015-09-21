using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Game
    {
        private string Word { get; set; }
        private int Stage { get; set; }

        public Game(string word)
        {
            Word = word;
            Stage = 0;
        }

        public int[] TakeCharacter(char ch)
        {
            return null;
        }
    }
}
