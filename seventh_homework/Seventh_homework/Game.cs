using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_homework_first_quest
{
    public partial class Game : Form
    {
        public int CountUserStep { get; private set; }
        Stack<string> userNumber = new Stack<string>();
        public Game()
        {
            Form mainMenu = Application.OpenForms[0];
            mainMenu.Hide();
            InitializeComponent();
            NumberGenerator numberGenerator = new NumberGenerator(100);
            GameNumberLabel.Text = numberGenerator.Result.ToString();
            int result = Int32.Parse(GameNumberLabel.Text);
            Label_CountMinValueSteps.Text = countCompStep(result).ToString();
            CountUserStep = 0;
        }
        public int countCompStep(int value)
        {
            int minCountStep = 0;
            while(value != 0)
            {
                if (value % 2 != 0) value -= 1;
                else value /= 2;
                minCountStep++;
            }
            return minCountStep;
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            UserNumberLabel.Text = (int.Parse(UserNumberLabel.Text) + 1).ToString();
            userNumber.Push(UserNumberLabel.Text);
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            UserNumberLabel.Text = (int.Parse(UserNumberLabel.Text) * 2).ToString();
            userNumber.Push(UserNumberLabel.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                userNumber.Pop();
                UserNumberLabel.Text = userNumber.Peek();
            }
            catch 
            {
                UserNumberLabel.Text = "0";
            }
        }

        private void UserNumberLabel_TextChanged(object sender, EventArgs e)
        {
            CountUserStep++;
            LabelCountSteps.Text = CountUserStep.ToString();
            if (GameNumberLabel.Text == UserNumberLabel.Text)
            {
                Close();
                EndGame endGame = new EndGame(CountUserStep, true);
                endGame.Show();
            }
            else if (Int32.Parse(GameNumberLabel.Text) < Int32.Parse(UserNumberLabel.Text))
            {
                Close();
                EndGame endGame = new EndGame(CountUserStep, false);
                endGame.Show();
            }
        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form mainMenu = Application.OpenForms[0];
            mainMenu.Show();
        }
    }
}
