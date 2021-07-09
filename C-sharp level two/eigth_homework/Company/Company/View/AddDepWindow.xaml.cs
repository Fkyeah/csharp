using System.Collections.ObjectModel;
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
        private WebService.WebServiceSoapClient _serviceClient;
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
            _serviceClient.InsertDepartment(DepartmentTextBox.Text);
            DepDataGrid.ItemsSource = null;
            DepDataGrid.ItemsSource = _serviceClient.GetDepartments();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _serviceClient = new WebService.WebServiceSoapClient();
            DepDataGrid.ItemsSource = _serviceClient.GetDepartments();
        }
    }
}
