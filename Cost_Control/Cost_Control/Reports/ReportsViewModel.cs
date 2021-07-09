﻿using Cost_Control.CostManager.Model;
using Cost_Control.Reports.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cost_Control.Reports
{
    class ReportsViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Reports";
        public IEnumerable<string> Users { get; set; } = UserList.GetUserList();
        public string SelectedName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DateTime SelectedDate { get; set; }
        public ObservableCollection<Cost> CostsForReports { get; set; }
        public ICommand DateChangedCommand
        {
            get => new DelegateCommand(SelectCosts, CanSelect);
        }
        private void SelectCosts(object obj)
        {
            CostsForReports = CostList.GetCosts(SelectedName, SelectedDate);
            OnPropertyChanged("CostsForReports");
        }
        private bool CanSelect(object obj) => SelectedDate != null || SelectedName != null ? true : false;
        public ICommand GetStat
        {
            get => new DelegateCommand(GetStatInPeriod, CanGetStats);
        }
        private void GetStatInPeriod(object obj)
        {
            CostsForReports = Stats.GetStatInPeriod(SelectedName, FromDate, ToDate);
            OnPropertyChanged("CostsForReports");
        }
        private bool CanGetStats(object obj) => /*SelectedName != null || ToDate != null || FromDate != null ? true :*/ false;
    }
}
