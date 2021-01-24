using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для AddDeoWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|CompanyDB.mdf;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt;
        public AddDepWindow()
        {
            InitializeComponent();  
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            dt.Rows.Add(1, DepartmentTextBox.Text);
            da.Update(dt);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //select departments
            SqlCommand selectDeps = new SqlCommand("select Id, Name from Departments", connection);
            da.SelectCommand = selectDeps;
            //insert departments
            SqlCommand insertDep = new SqlCommand(@"insert into Departments (Name) values (@Name); set @Id = @@identity", connection);
            insertDep.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            SqlParameter param = insertDep.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            da.InsertCommand = insertDep;
            dt = new DataTable();
            da.Fill(dt);
            dt.DefaultView.Sort = "Id asc";
            DepDataGrid.DataContext = dt.DefaultView;
        }
    }
}
