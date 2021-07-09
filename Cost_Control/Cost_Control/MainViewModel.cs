using Cost_Control.CostManager;
using Cost_Control.CostManager.Model;
using Cost_Control.Reports;
using Cost_Control.Users;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Cost_Control
{
    class MainViewModel : ObservableObject
    {
        
        public MainViewModel()
        {
            PageViewModels.Add(new CostManagerViewModel());
            PageViewModels.Add(new ReportsViewModel());
            PageViewModels.Add(new UsersViewModel());

            CurrentPageViewModel = PageViewModels[0];
        }


        private List<IPageViewModel> _pageViewModels;
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }
        private IPageViewModel _currentPageViewModel;
        private ICommand _changePageCommand;

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
        public ICommand WindowLoad
        {
            get => new DelegateCommand(LoadWindow, CanLoadWindow);
        }
        private void LoadWindow(object obj)
        {
            UserList.LoadUsers();
        }
        private bool CanLoadWindow(object obj) => true;
        // Close main window. Start
        public ICommand WindowClosing
        {
            get => new DelegateCommand(CloseWindow, CanCloseWindow);
        }
        private void CloseWindow(object obj)
        {
            CostList.SaveCosts();
            UserList.SaveUsers();
        }
        private bool CanCloseWindow(object obj) => true;
        // Close main window. End
    }
}
