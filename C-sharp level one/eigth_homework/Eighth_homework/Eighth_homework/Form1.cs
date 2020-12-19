using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eighth_homework
{
    public partial class Form1 : Form
    {
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException("Создайте новую БД или откройте существующую");
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException("Создайте новую БД или откройте существующую");
                database.Add((database.Count + 1).ToString(), true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string nameBox = "Удаление вопроса";
            string acceptDelete = "Вы действительно хотите удалить вопрос?";
            DialogResult result;
            try
            {
                if (nudNumber.Maximum == 0 || database == null) throw new Exception("Нет вопроса для удаления");
                else
                {
                    result = MessageBox.Show(acceptDelete, nameBox, MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.Yes)
                {
                    database.Remove((int)nudNumber.Value - 1);
                    nudNumber.Maximum--;
                    tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                    if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
                }
                else return;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}");
            }    
        }
        private void miSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException("Создайте новую БД или откройте существующую");
                database.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка");
            }
        }
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException("Создайте новую БД или откройте существующую");
                database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка");
            }
        }
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Автор программы: Тихонов Дмитрий\nВерсия 1.0.0\n© Tikhonov Dmitry {DateTime.Now.Year}");
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (database == null) throw new NullReferenceException("Создайте новую БД или откройте существующую");
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                    database.SaveAs(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}");
            }
        }
    }
}
