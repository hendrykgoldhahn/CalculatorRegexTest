using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorViewModel myCalculator = new CalculatorViewModel();
        public MainWindow()
        {
            DataContext = myCalculator;
            InitializeComponent();
        }

        public void ButtonWasClicked(object sender, RoutedEventArgs e)
        {            
            myCalculator.SetDisplayText(((Button)sender).Content.ToString());
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.CalculateResult();
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.ClearDisplayText();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.DeleteLastChar();
        }
    }
}
