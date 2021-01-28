using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Linq;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebService.WebServiceSoapClient _serviceClient;
        private WebService.Employer _emp;
        private Department _department;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmpWindow addEmpWindow = new AddEmpWindow();
            addEmpWindow.ShowDialog();
            if (addEmpWindow.DialogResult.HasValue && addEmpWindow.DialogResult.Value)
            {
                EmployersDataGrid.ItemsSource = null;
                EmployersDataGrid.ItemsSource = _serviceClient.GetEmployers();
            }
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDepWindow = new AddDepWindow();
            addDepWindow.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmpWindow editWindow = new UpdateEmpWindow((WebService.Employer)EmployersDataGrid.SelectedItem);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                EmployersDataGrid.ItemsSource = null;
                EmployersDataGrid.ItemsSource = _serviceClient.GetEmployers();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _emp = (WebService.Employer)EmployersDataGrid.SelectedItem;
            _serviceClient.DeleteEmployer(_emp.Id);
            EmployersDataGrid.ItemsSource = null;
            EmployersDataGrid.ItemsSource = _serviceClient.GetEmployers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _serviceClient = new WebService.WebServiceSoapClient();
            EmployersDataGrid.ItemsSource = _serviceClient.GetEmployers();
        }
    }
}
