using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow updateWindow = new AddWindow(ref employers, departments);
            updateWindow.ShowDialog();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            employers.Remove(EmployersDataGrid.SelectedItem as Employer);
        }
    }
}
