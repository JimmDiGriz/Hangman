using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Hangman
{
    class Game
    {
        private string Word { get; set; }
        public int Lenght { get; private set; }
        private int Stage { get; set; }
        public char[] Alphabet { get; private set; }

        public Game(string word, GameLanguage lang)
        {
            Word = word;
            Lenght = Word.Length;
            Stage = 0;
            InitializeAlphabet(lang);
        }

        private void InitializeAlphabet(GameLanguage lang)
        {
            switch (lang)
            {
                case GameLanguage.En:
                    Alphabet = new char[] {'A', 'B', 'C', 'D', 'E',
                        'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                        'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                        'X', 'Y', 'Z'};
                    break;
                case GameLanguage.Ru:
                    Alphabet = new char[] {'А', 'Б', 'В', 'Г', 'Д', 'Е',
                        'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                        'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш',
                        'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};
                    break;
            }
        }

        public BitmapImage GetStageImage()
        {
            return new BitmapImage(
                new Uri(System.IO.Path.Combine(
                    Environment.CurrentDirectory,
                    "Images", Stage+".png")));
        }

        public int[] TakeCharacter(char ch)
        {
            int[] temp = new int[Word.Length];

            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == ch)
                {
                    temp[i] = 1;
                }
                else
                {
                    temp[i] = 0;
                }
            }

            if (temp.Count(i => i == 1) == 0)
            {
                Stage++;
            }

            return temp;
        }
    }
}