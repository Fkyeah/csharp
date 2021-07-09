using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class MainMenu : Form
    {
        LoadQuestions database;
        public MainMenu()
        {
            InitializeComponent();
            lblGameRules.Text = "Компьютер случайным образом выбирает 5 вопросов из загруженной базы\nи задаёт их игроку.\nИгрок отвечает Да или Нет на каждый вопрос\nи набирает баллы за каждый правильный ответ.";
            lblStatusDB.Text = "Перед началом игры, пожалуйста,\nзагрузите список вопросов в XML формате";
        }

        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    database = new LoadQuestions(ofd.FileName);
                    database.Load();
                }
                if (database != null) lblStatusDB.Text = "Вопросы успешно загружены!\nМожно начинать играть.";
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}\nНеверный формат данных внутри файла!", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка");
            }
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException();
                this.Hide();
                Game game = new Game(database);
                game.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Перед началом игры необходимо загрузить список вопросов!","Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
