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
    public partial class EndGame : Form
    {
        Form mainMenu = Application.OpenForms[0];
        public EndGame(int stepResult, bool checkResult)
        {
            mainMenu.Hide();
            InitializeComponent();
            LabelInfo.Text = "Игра окончена. ";
            Result.Text = stepResult.ToString();
            if (checkResult) LabelInfo.Text += "Поздравляю! Вы получили нужное число.";
            else LabelInfo.Text += " К сожалению, вы проиграли!\nВаше число получилось больше загаданного.";
        }
        private void EndGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainMenu.Show();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Close();
            Game game = new Game();
            game.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
