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

namespace Hangman
{
    public partial class MainWindow : Window
    {
        private enum Language
        { 
            En,
            Ru
        }

        public MainWindow()
        {
            InitializeComponent();
            CreateCharacterLbl(0);
            CreateCharacterLbl(1);
        }

        private void CreateCharacterLbl(int i)
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

        private void CreateCharacterBtns()
        { 
            
        }
    }
}
