using Cost_Control.CostManager.Model;
using Cost_Control.Reports.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cost_Control.Reports
{
    class ReportsViewModel : ObservableObject, IPageViewModel
    {
        private CostList costLists = new CostList();
        private StatsList statsList = new StatsList();
        public string Name => "Reports";
        public IEnumerable<string> Users { get; set; } = UserList.GetUserList();
        public string SelectedName { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
        public DateTime SelectedDate { get; set; }
        public ObservableCollection<Cost> CostsForReports { get; set; } = new ObservableCollection<Cost>();
        public ICommand DateChangedCommand
        {
            get => new DelegateCommand(SelectCosts, CanSelect);
        }
        private void SelectCosts(object obj)
        {
            CostsForReports = costLists.GetCosts(SelectedName, SelectedDate);
            OnPropertyChanged("CostsForReports");
        }
        private bool CanSelect(object obj) => SelectedDate != null && SelectedName != null;
        public ICommand GetStat
        {
            get => new DelegateCommand(GetStatInPeriod, CanGetStats);
        }
        private void GetStatInPeriod(object obj)
        {
            CostsForReports = statsList.GetStatInPeriod(costLists, SelectedName, FromDate, ToDate);
            OnPropertyChanged("CostsForReports");
        }
        private bool CanGetStats(object obj) => SelectedName != null;
    }
}
