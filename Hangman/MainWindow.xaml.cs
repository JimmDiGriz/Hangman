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

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameField();
        }

        private void NewGameBtnClick(object sender, RoutedEventArgs e)
        {
            InitializeGameField();
        }

        private void CharacterBtnClick(object sender, RoutedEventArgs e)
        {
            int[] temp = HangmanGame.TakeCharacter((char)((Button)sender).Content);

            (sender as Button).IsEnabled = false;
        }

        private void InitializeGameField()
        {
            HangmanGame = new Game("test", GameLanguage.En);

            CreateImage();
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

            button.Name = "NewGameBtn";
            button.Click += new RoutedEventHandler(NewGameBtnClick);

            GameGrid.Children.Add(button);
        }

        private void CreateImage()
        {
            Image image = new Image();

            image.Name = "StageImage";
            image.VerticalAlignment = VerticalAlignment.Center;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.Width = 150;
            image.Height = 150;

            GameGrid.Children.Add(image);
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

                GameGrid.Children.Add(button);
            }
        }
        #endregion
    }
}
