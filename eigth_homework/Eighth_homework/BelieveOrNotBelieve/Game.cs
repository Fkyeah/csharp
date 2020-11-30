using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BelieveOrNotBelieve
{
    public partial class Game : Form
    {
        LoadQuestions database;
        int numberQuestion;
        int countTrueAnswers;
        int countQuestions;
        public Game(LoadQuestions _database)
        {
            InitializeComponent();
            this.database = _database;
            countTrueAnswers = 0;
            getQuestion();
        }
        private void getQuestion()
        {
            countQuestions++;
            if (countQuestions <= 5)
            {
                Random r = new Random();
                numberQuestion = r.Next(database.Count - 1);
                tBoxQuestion.Text = SplitToLines(database[numberQuestion].Text, 60);
            }
            else EndGame();
        }
        public string SplitToLines(string str, int n)
        {
            return Regex.Replace(str, ".{" + n + "}( $)", "$0\n");
        }
        private void checkAnswer(bool answer)
        {
            if (database[numberQuestion].TrueFalse == answer)
            {
                countTrueAnswers++;
                lblTrueFalse.Text = "Верно!";
                lblCountAnswers.Text = $"Количество правильных ответов: {countTrueAnswers}";
            }
            else lblTrueFalse.Text = "Неверно!";
            getQuestion();
        }
        private void EndGame()
        {
            DialogResult result = MessageBox.Show($"Игра окончена!\n{lblCountAnswers.Text}\nНажмите ОК для выхода в Меню", "Конец игры", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            checkAnswer(true);
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            checkAnswer(false);
        }
        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menu = Application.OpenForms[0];
            menu.Show();
        }
    }
}
