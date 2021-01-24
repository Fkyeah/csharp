using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для UpdateEmployerWindow.xaml
    /// </summary>
    public partial class UpdateEmployerWindow : Window
    {
        public Employer Emp { get; private set; } = new Employer();
        public ObservableCollection<Department> departments;
        public UpdateEmployerWindow(Employer emp, ObservableCollection<Department> deps)
        {
            InitializeComponent();
            Emp.Id = emp.Id;
            departments = deps;
            NameTextBox.Text = emp.Name;
            LastNameTextBox.Text = emp.LastName;
            DepartamentComboBox.ItemsSource = departments.Select(t => t.DepartName);
            DepartamentComboBox.Text = emp.department.DepartName;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Emp.Name = NameTextBox.Text;
            Emp.LastName = LastNameTextBox.Text;
            Emp.department = departments.First(t => t.DepartName == DepartamentComboBox.SelectedItem.ToString());
            this.DialogResult = true;
        }
    }
}
