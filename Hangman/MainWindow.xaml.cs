using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Hangman
{
    public enum GameLanguage
    {
        En,
        Ru
    }

    public partial class MainWindow : Window
    {
        private Game HangmanGame { get; set; }
        private List<Button> Buttons { get; set; }
        private List<Label> Labels { get; set; }
        private Image StageImage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Labels = new List<Label>();
            Buttons = new List<Button>();
            CreateNewGameBtn();
        }

        private void NewGameBtnClick(object sender, RoutedEventArgs e)
        {
            /*
             * Поскольку мне лень писать что-то еще пока что,
             * то сделаю просто массив с парой слов.
             */

            string[] words = new string[] { 
                "word", "test", "language", "default",
                "world", "ship", "fleet", "blueprint"};
            InitializeGameField(words[new Random().Next(0, words.Length)]);
        }

        private void CharacterBtnClick(object sender, RoutedEventArgs e)
        {
            int[] temp = HangmanGame.TakeCharacter((sender as Button).Content.ToString()[0]);

            for (int i = 0; i < temp.Length; i++)
            { 
                if (temp[i] == 1)
                {
                    Labels[i].Content = HangmanGame.Word[i];
                }
            }

            StageImage.Source = HangmanGame.GetStageImage();

            if (Labels.Count(l => l.Content == null) == 0)
            {
                FinishGame("You Win!");
            }
            else if (HangmanGame.IsGameOver())
            {
                FinishGame("You Lose!");
            }
            else
            {
                (sender as Button).IsEnabled = false;
            }
        }

        private void FinishGame(string message)
        {
            MessageBox.Show(message);
            Buttons.ForEach(b => b.IsEnabled = false);
        }

        private void InitializeGameField(string word)
        {
            HangmanGame = new Game(word, GameLanguage.En);

            Labels.Clear();
            Buttons.Clear();
            GameGrid.Children.Clear();

            CreateImage();
            StageImage.Source = HangmanGame.GetStageImage();

            CreateNewGameBtn();
            CreateCharacterBtns(HangmanGame.Alphabet);
            CreateCharacterLbl(HangmanGame.Lenght);
        }

        #region Game Field Initialization
        private void CreateNewGameBtn()
        {
            Button button = new Button();
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Width = 150;
            button.Height = 35;

            button.Content = "New Game";
            button.Click += new RoutedEventHandler(NewGameBtnClick);

            GameGrid.Children.Add(button);
        }

        private void CreateImage()
        {
            StageImage = new Image();

            StageImage.Name = "StageImage";
            StageImage.VerticalAlignment = VerticalAlignment.Center;
            StageImage.HorizontalAlignment = HorizontalAlignment.Center;
            StageImage.Width = 150;
            StageImage.Height = 150;

            GameGrid.Children.Add(StageImage);
        }

        private void CreateCharacterLbl(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Label label = new Label();
                label.FontSize = 20;
                label.FontWeight = FontWeight;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.BorderThickness = new Thickness(1, 1, 1, 1);
                label.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x2D, 0x2D, 0x30));
                label.Height = label.Width = 38;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Top;

                label.Name = "Character" + i.ToString();

                label.Margin = new Thickness(i * label.Width, 0d, 0d, 0d);

                Labels.Add(label);

                GameGrid.Children.Add(label);
            }
        }

        private void CreateCharacterBtns(char[] alph)
        {
            double bot = 0;
            int count = 0;
            for (int i = 0; i < alph.Length; i++, count++)
            {
                Button button = new Button();
                button.FontSize = 20;
                button.FontWeight = FontWeight;
                button.HorizontalContentAlignment = HorizontalAlignment.Center;
                button.VerticalContentAlignment = VerticalAlignment.Center;
                button.Height = button.Width = 38;
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Bottom;

                button.Content = alph[i].ToString();

                if ((count + 1) * button.Width > GameGrid.Width)
                {
                    count = 0;
                    bot += button.Height;
                }

                button.Margin = new Thickness(count * button.Width, 0, 0, bot);
                button.Click += new RoutedEventHandler(CharacterBtnClick);

                Buttons.Add(button);

                GameGrid.Children.Add(button);
            }
        }
        #endregion
    }
}
