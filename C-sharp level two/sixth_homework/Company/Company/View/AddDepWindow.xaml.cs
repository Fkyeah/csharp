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
    /// Логика взаимодействия для AddDepWindow.xaml
    /// </summary>
    public partial class AddDepWindow : Window
    {
        public Department Dep { get; private set; }
        public ObservableCollection<Department> _deps;
        public AddDepWindow(ObservableCollection<Department> departments)
        {
            InitializeComponent();
            _deps = departments;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Dep = new Department(_deps.Last().DepartId + 1, DepartmentTextBox.Text);
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
