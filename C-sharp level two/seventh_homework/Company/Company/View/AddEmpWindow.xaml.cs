using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для AddEmpWindow.xaml
    /// </summary>
    public partial class AddEmpWindow : Window
    {
        public DataRow resultRow { get; set; }
        static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|CompanyDB.mdf;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public AddEmpWindow(DataRow row)
        {
            InitializeComponent();
            resultRow = row;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            resultRow["Name"] = NameTextBox.Text;
            resultRow["LastName"] = LastNameTextBox.Text;
            resultRow["Department_Id"] = Convert.ToInt32(DepartmentComboBox.Text);
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand selectDeps = new SqlCommand("select Id from Departments", connection);
            connection.Open();
            SqlDataReader dr = selectDeps.ExecuteReader();
            while (dr.Read())
            {
                DepartmentComboBox.Items.Add(dr.GetInt32(0));
            }
            connection.Close();
        }
    }
}
