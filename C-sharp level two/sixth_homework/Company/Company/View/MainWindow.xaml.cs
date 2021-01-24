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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employer> employers = new ObservableCollection<Employer>();
        public ObservableCollection<Department> departments = new ObservableCollection<Department>();
        public MainWindow()
        {
            InitializeComponent();
            departments.Add(new Department(1, "Департамент 1"));
            departments.Add(new Department(2, "Департамент 2"));
            departments.Add(new Department(3, "Департамент 3"));
            departments.Add(new Department(4, "Департамент 4"));
            departments.Add(new Department(5, "Департамент 5"));

            employers.Add(new Employer(1, "Иван", "Иванов", departments[1]));
            employers.Add(new Employer(2, "Петр", "Петров", departments[2]));
            employers.Add(new Employer(3, "Дмитрий", "Тихонов", departments[3]));
            employers.Add(new Employer(4, "Николай", "Николаев", departments[4]));
            employers.Add(new Employer(5, "Никита", "Шпаков", departments[4]));
            employers.Add(new Employer(6, "Кирилл", "Дмитриев", departments[0]));
            EmployersDataGrid.ItemsSource = employers;
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmpWindow addEmpWindow = new AddEmpWindow(employers, departments);
            addEmpWindow.ShowDialog();
            if (addEmpWindow.DialogResult.HasValue && addEmpWindow.DialogResult.Value == true)
            {
                employers.Add(addEmpWindow.Emp);
            }
        }

        private void btnAddDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDepWindow = new AddDepWindow(departments);
            addDepWindow.ShowDialog();
            if (addDepWindow.DialogResult.HasValue && addDepWindow.DialogResult.Value == true)
            {
                departments.Add(addDepWindow.Dep);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Employer emp = (Employer)EmployersDataGrid.SelectedItem;
            UpdateEmployerWindow updateEmployerWindow = new UpdateEmployerWindow(emp, departments);
            updateEmployerWindow.ShowDialog();
            if (updateEmployerWindow.DialogResult.HasValue && updateEmployerWindow.DialogResult.Value == true)
            {
                employers[emp.Id - 1] = updateEmployerWindow.Emp;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            employers.Remove(EmployersDataGrid.SelectedItem as Employer);
        }
    }
}
