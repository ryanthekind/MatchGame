using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Documents;




namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8) 
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
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

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        // declares findingMatch bool to be false
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text) 
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                // Resets game
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}