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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            MenuInfoLabel.Text = "Домашнее задание студента GeekBrains Тихонова Дмитрия";
            NameGameLabel.Text = "Игра 'Удвоитель'";
            GameRulesLabel.Text = "За минимальеное количество ходов Вам необходимо получить\nслучайно сгенерированное число";
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game();
            game.ShowDialog();
            
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) Environment.Exit(0);
        }
    }
}
