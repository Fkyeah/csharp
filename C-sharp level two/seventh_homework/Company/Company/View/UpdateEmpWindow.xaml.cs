using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для UpdateEmpWindow.xaml
    /// </summary>
    public partial class UpdateEmpWindow : Window
    {
        static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|CompanyDB.mdf;Integrated Security = True";
        SqlConnection connection  = new SqlConnection(connectionString);

        public DataRow resultRow { get; set; }
        public UpdateEmpWindow(DataRow row)
        {
            InitializeComponent();
            resultRow = row;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = NameTextBox.Text;
            resultRow["LastName"] = LastNameTextBox.Text;
            resultRow["Department_Id"] = DepartamentComboBox.Text;
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = resultRow["Name"].ToString();
            LastNameTextBox.Text = resultRow["LastName"].ToString();
            SqlCommand selectDeps = new SqlCommand("select Id from Departments", connection);
            connection.Open();
            SqlDataReader dr = selectDeps.ExecuteReader();
            while (dr.Read())
            {
                DepartamentComboBox.Items.Add(dr.GetInt32(0));
            }
            connection.Close();
            DepartamentComboBox.Text = resultRow["Department_Id"].ToString();
        }
    }
}
