using System;
using System.Windows;

namespace Doubler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();
        private int _userNumber = 0;
        private int _answer = r.Next(1, 100);
        private int _countSteps = 0;
        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }
        private void IncrementStep()
        {
            _countSteps++;
            lblNumbStep.Content = _countSteps.ToString();
        }
        private void StartNewGame()
        {
            tbUserNumb.Text = "0";
            _countSteps = 0;
            lblNumbStep.Content = _countSteps.ToString();
            _answer = r.Next(1, 100);
            tbAnswer.Text = _answer.ToString();
        }
        private void CheckAnswer(int userAnswer)
        {
            if (userAnswer == _answer)
            {
                MessageBox.Show($"Поздравляю! Вы победили! Количество шагов: {_countSteps}", "Конец игры", MessageBoxButton.OK, MessageBoxImage.Information);
                StartNewGame();
            }
            else if (userAnswer > _answer)
            {
                MessageBox.Show("К сожалению, вы проиграли! Ваше число оказалось больше загаданного", "Конец игры", MessageBoxButton.OK, MessageBoxImage.Error);
                StartNewGame();
            }   

        }

        private void btnIncrement_click(object sender, RoutedEventArgs e)
        {
            _userNumber = Convert.ToInt32(tbUserNumb.Text);
            _userNumber++;
            tbUserNumb.Text = _userNumber.ToString();
            IncrementStep();
            CheckAnswer(_userNumber);
        }

        private void btnDoubling_click(object sender, RoutedEventArgs e)
        {
            _userNumber = Convert.ToInt32(tbUserNumb.Text);
            _userNumber *= 2;
            tbUserNumb.Text = _userNumber.ToString();
            IncrementStep();
            CheckAnswer(_userNumber);
        }
    }
}
