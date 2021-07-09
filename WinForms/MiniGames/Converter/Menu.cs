using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class Menu : Form
    {
        Converter converter;
        public Menu()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
               {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    converter = new Converter(ofd.FileName);
                    converter.Load();
                    for (int i = 0; i < converter.list.Count; i++)
                    {
                        tboxCsvFile.Text += $"{converter.getStudent(i)}\r\n";
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Ошибка:\nОткрыт файл некорректного формата","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ShowDialog();
                converter.Convert(sfd.FileName);
                MessageBox.Show("Файл успешно создан!", "Сообщение");
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Перед конвертацией необходимо загрузить в программу .CSV файл!","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
