using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для UpdateEmpWindow.xaml
    /// </summary>
    public partial class UpdateEmpWindow : Window
    {
        private WebService.WebServiceSoapClient _serviceClient;
        private Employer _emp;
        public UpdateEmpWindow(WebService.Employer emp)
        {
            InitializeComponent();
            _emp =  new Employer(emp.Id, emp.Name, emp.LastName, emp.Department_Id);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _serviceClient.UpdateEmployer(_emp.Id, NameTextBox.Text, LastNameTextBox.Text, (int)DepartamentComboBox.SelectedItem);
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _serviceClient = new WebService.WebServiceSoapClient();
            foreach (var dep in _serviceClient.GetDepartments())
            {
                DepartamentComboBox.Items.Add(dep.Id);
            }
            NameTextBox.Text = _emp.Name;
            LastNameTextBox.Text = _emp.LastName;
            DepartamentComboBox.Text = _emp.Department_Id.ToString();
        }
    }
}
