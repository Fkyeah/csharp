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
        private WebService.WebServiceSoapClient _serviceClient;
        public AddEmpWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _serviceClient.InsertEmployer(NameTextBox.Text, LastNameTextBox.Text, (int)DepartmentComboBox.SelectedItem);
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _serviceClient = new WebService.WebServiceSoapClient();
            foreach (var dep in _serviceClient.GetDepartments())
            {
                DepartmentComboBox.Items.Add(dep.Id);
            }
        }
    }
}
