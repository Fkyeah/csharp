using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Cost_Control.CostManager.Model;
using System.Windows.Input;

namespace Cost_Control.CostManager
{
    class CostManagerViewModel : ObservableObject, IPageViewModel
    {
        public CostManagerViewModel()
        {
            Costs = costList.LoadCosts();
        }
        private CostList costList = new CostList();
        public string Name => "Cost_Manager";
        public ObservableCollection<Cost> Costs { get; set; } = new ObservableCollection<Cost>();
        // Select current user in combo box. Start
        public IEnumerable<string> Users { get; set; } = UserList.GetUserList();
        public string SelectedName { get; set; }
        public ICommand CurrentUserChangedCommand
        {
            get => new DelegateCommand(SelectCosts, CanSelect);
        }
        // Select current user in combo box. End
        // Select date in calendar. Start
        public double TotalSum { get; set; }
        public DateTime SelectedDate { get; set; }
        public ICommand DateChangedCommand
        {
            get => new DelegateCommand(SelectCosts, CanSelect);
        }
        // Select date in calendar. End
        private void SelectCosts(object obj)
        {
            Costs = costList.GetCosts(SelectedName, SelectedDate);
            OnPropertyChanged("Costs");
            TotalSum = costList.GetSum(SelectedName, SelectedDate);
            OnPropertyChanged("TotalSum");
        }
        private bool CanSelect(object obj) => Costs != null;
        // Click button AddCost. Start
        public string CostName { get; set; }
        public double CostSum { get; set; }
        public ICommand ClickAdd
        {
            get => new DelegateCommand(AddCost, CanAdd);
        }
        private void AddCost(object obj)
        {
            costList.AddCost(new Cost(UserList.Users.Where(t => t.Name == SelectedName).First(), CostName, CostSum, SelectedDate));
            SelectCosts(obj);
            CostName = "";
            CostSum = 0;
            OnPropertyChanged("CostName");
            OnPropertyChanged("CostSum");
        }
        private bool CanAdd(object obj) => SelectedName == null || SelectedDate.ToString("d") == "01.01.0001"  || CostName == null || CostSum < 0 ? false : true;
        // Click button AddCost. End
        // Click button DeleteCost. Start
        public Cost SelectedCost { get; set; }
        public ICommand ClickDelete
        {
            get => new DelegateCommand(DeleteCost, CanDelete);
        }
        private void DeleteCost(object obj)
        {
            costList.DeleteCost(SelectedCost);
            SelectCosts(obj);
        }
        private bool CanDelete(object obj) => SelectedCost == null ? false : true;
        // Click button DeleteCost. End
        // Close main window. Start
        public ICommand WindowClosing
        {
            get => new DelegateCommand(CloseWindow, CanCloseWindow);
        }
        private void CloseWindow(object obj)
        {
            costList.SaveCosts();
            UserList.SaveUsers();
        }
        private bool CanCloseWindow(object obj) => true;
        // Close main window. End
    }
}
