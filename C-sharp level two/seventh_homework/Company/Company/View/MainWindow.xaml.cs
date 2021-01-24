using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Linq;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|CompanyDB.mdf;Integrated Security = True";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dt.NewRow();
            AddEmpWindow addEmpWindow = new AddEmpWindow(newRow);
            addEmpWindow.ShowDialog();
            if (addEmpWindow.DialogResult.HasValue && addEmpWindow.DialogResult.Value)
            {
                dt.Rows.Add(addEmpWindow.resultRow);
                adapter.Update(dt);
            }
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDepWindow = new AddDepWindow();
            addDepWindow.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)EmployersDataGrid.SelectedItem;
            newRow.BeginEdit();
            UpdateEmpWindow editWindow = new UpdateEmpWindow(newRow.Row);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                adapter.Update(dt);
            }
            else
            {
                newRow.CancelEdit();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView newRow = (DataRowView)EmployersDataGrid.SelectedItem;
            newRow.Row.Delete();
            adapter.Update(dt);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter = new SqlDataAdapter();
            connection = new SqlConnection(connectionString);
            //select main table
            SqlCommand selectMain = new SqlCommand("select Id, Name, LastName, Department_Id from Employers", connection);
            adapter.SelectCommand = selectMain;
            //update Emp
            SqlCommand updateEmp = new SqlCommand(@"update Employers set Name = @Name, LastName = @LastName, Department_Id = @Department_Id where Id = @Id", connection);
            updateEmp.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            updateEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            updateEmp.Parameters.Add("@Department_Id", SqlDbType.Int, 0, "Department_Id");
            SqlParameter param = updateEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = updateEmp;
            //insert Emp
            SqlCommand insertEmp = new SqlCommand(@"insert into Employers (Name, LastName, Department_Id) values (@Name, @LastName, @Department_Id); set @Id = @@identity;", connection);
            insertEmp.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            insertEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            insertEmp.Parameters.Add("@Department_Id", SqlDbType.Int, 50, "Department_Id");
            param = insertEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = insertEmp;
            //delete Emp
            SqlCommand deleteEmp = new SqlCommand(@"delete from Employers where Id = @Id", connection);
            SqlParameter parameter = deleteEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            adapter.DeleteCommand = deleteEmp;
            dt = new DataTable();
            adapter.Fill(dt);
            dt.DefaultView.Sort = "Id asc";
            EmployersDataGrid.DataContext = dt.DefaultView;
        }
    }
}
