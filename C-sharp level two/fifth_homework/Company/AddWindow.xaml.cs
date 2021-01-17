﻿using System;
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
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Employer Emp { get; private set; } = new Employer();
        private ObservableCollection<Department> _deps;
        private ObservableCollection<Employer> _emps;
        public AddWindow(ref ObservableCollection<Employer> employers, ObservableCollection<Department> departments)
        {
            InitializeComponent();
            _deps = departments;
            _emps = employers;
            DepartmentComboBox.ItemsSource = _deps.Select(t => t.DepartName).ToList();
            DepartmentComboBox.SelectedItem = _deps[0].DepartName.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Emp.Id = _emps.Count + 1;
            Emp.Name = NameTextBox.Text;
            Emp.LastName = LastNameTextBox.Text;
            Emp.department = _deps.First(t => t.DepartName == DepartmentComboBox.SelectedItem.ToString());
            this.DialogResult = true;
            _emps.Add(Emp);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
