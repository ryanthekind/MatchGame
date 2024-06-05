﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create a SetUpGame Method
            SetUpGame();
        }

        private void SetUpGame()
        {
            // Create a list of eight pairs of emoji
            List<string> animalEmoji = new List<string>()
            {
                "🐵","🐵", 
                "🦊","🦊",
                "🐺","🐺",
                "🐸","🐸",
                "🦄","🦄",
                "🦌","🦌",
                "🐘","🐘",
                "🦔","🦔",
            };

            // Create a new random number generator
            Random random = new Random();

            // Find every Textblock in the main grid and repeat the following statements for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) 
            {
                // Pick a random number between 0 and the number of emoji left in the list and call it "index"
                int index = random.Next(animalEmoji.Count);

                // Use the random number called "index" to get random emoji from the list
                string nextEmoji = animalEmoji[index];

                // Update the TextBlock with the random emoji from the list
                textBlock.Text = nextEmoji;

                // Remove the random emoji from the list
                animalEmoji.RemoveAt(index);

            }

        }
    }
}