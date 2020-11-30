using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_homework_second
{
    public partial class EndGame : Form
    {
        public EndGame(int countSteps, int answer)
        {
            InitializeComponent();
            label_resultGame.Text = $"Поздравляю! Было загадано число {answer}\nКоличество ваших шагов: {countSteps}";
        }

        private void Button_NewGame_Click(object sender, EventArgs e)
        {
            this.Close();
            Form startGame = Application.OpenForms[0];
            startGame.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
