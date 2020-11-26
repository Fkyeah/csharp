using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_homework_second
{
    public partial class Game : Form
    {
        private int _trueNumber;
        private int _countSteps;
        public Game()
        {
            InitializeComponent();
            Label_Rules.Text = "Компьютер загадывает число от 1 до 100,\nа Вам необходимо его угадать за минимальное число попыток.";
            _trueNumber = GenerateNumber();
            Label_Prompt.Text = "Тут будет подсказка после нажатия кнопки 'Проверить'";
            _countSteps = 0;
            Label_StepCounter.Text = $"Количество шагов: {_countSteps}"; ;
        }
        private int GenerateNumber()
        {
            Random r = new Random();
            return r.Next(1, 100);
        }
        private bool checkUserAnswer(ref int userNumber)
        {
            bool success = Int32.TryParse(textBoxt_UserAnswer.Text, out userNumber);
                if (userNumber < 0 || userNumber > 100) success = false;
                if (!success) textBoxt_UserAnswer.Clear();
            return success; 
        }
        private void button_checkAnswer_Click(object sender, EventArgs e)
        {
            _countSteps++;
            Label_StepCounter.Text = $"Количество шагов: {_countSteps}";
            int userNumber = 0;
            if (!checkUserAnswer(ref userNumber)) Label_Prompt.Text = "Ошибка. Введите число от 1 до 100";
            else
            {
                if (userNumber > _trueNumber) Label_Prompt.Text = "Компьютер загадал число меньше вашего";
                else if (userNumber < _trueNumber) Label_Prompt.Text = "Компьютер загадал число больше вашего";
                else
                {
                    EndGame endGame = new EndGame(_countSteps, userNumber);
                    endGame.Show();
                    this.Hide();
                }
            }
        }
        private void Game_Deactivate(object sender, EventArgs e)
        {
            textBoxt_UserAnswer.Clear();
            _trueNumber = GenerateNumber();
            _countSteps = 0;
            Label_StepCounter.Text = $"Количество шагов: {_countSteps}"; ;
            Label_Prompt.Text = "Тут будет подсказка после нажатия кнопки 'Проверить'";

        }
    }
}
