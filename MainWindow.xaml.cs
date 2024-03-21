using Microsoft.Windows.Themes;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfThomas1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clicks = 0;
        public MainWindow()
        {
            InitializeComponent();
            mainGrid.Background = new SolidColorBrush(Colors.Red);                    
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            List<string> buttonText = new List<string>();
            buttonText = clicks < 8 ? new List<string> { "Almost", "Ah-Ah-Ah", "Try Again" } : new List<string> { "Almost", "magic word?", "Ah-Ah-Ah" };
            Random random = new Random();

            double maxLeftMargin = this.Width - myButton.Width;
            double maxTopMargin = this.Height - myButton.Height;

            myButton.Margin = new Thickness(random.Next(-(int)maxLeftMargin, (int)maxLeftMargin), random.Next(0, (int)maxTopMargin), 0, 0); int randomIndex = random.Next(buttonText.Count);
            myButton.Content = buttonText[randomIndex];
           
            if (myButton.Content.ToString() == "magic word?")
            {
                myImage.Visibility = Visibility.Visible;
                myTextBox.Visibility = Visibility.Visible;
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri("Sounds/ahahah.mp3", UriKind.RelativeOrAbsolute));
                mediaPlayer.Play();
            }
            else
            {
                myImage.Visibility = Visibility.Collapsed;
                myTextBox.Visibility = Visibility.Collapsed;
            }

        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myTextBox.Text == "dinosaur")
            {
                myImage.Visibility = Visibility.Collapsed;
                myTextBox.Visibility = Visibility.Collapsed;
                safeTextBlock.Visibility = Visibility.Visible;
                mainGrid.Background = new SolidColorBrush(Colors.Green);
                safeTextBlock.Text = "Park Security back ONLINE \nCongratulations!";
                safeTextBlock.TextAlignment = TextAlignment.Center;
                safeTextBlock.Padding = new Thickness(120, 120, 120, 120);  
                safeTextBlock.Background = new SolidColorBrush(Colors.LightGreen);
                myButton.Visibility = Visibility.Collapsed;
                MediaPlayer mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(new Uri("Sounds/congratulations.mp3", UriKind.RelativeOrAbsolute));
                mediaPlayer.Play();
            }
        }
    }
}