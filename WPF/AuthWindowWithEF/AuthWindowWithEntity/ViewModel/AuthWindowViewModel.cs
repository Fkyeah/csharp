using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AuthWindowWithEntity.Model;

namespace AuthWindowWithEntity.ViewModel
{
    class AuthWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        #region Окно Авторизации
        public Accounts account { get; set; } = new Accounts(1, "None", "None");

        public int AttemptCount
        {
            get => AccessToApp.Attempt;
        }
        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand(Login, CanLogin);
            }
        }
        public bool Access { get; set; } = false;
        private void Login(object obj)
        {
            Console.WriteLine("Execute Click");
            Access = AccessToApp.Checks(account);
            Console.WriteLine(Access);
            if (Access) MessageBox.Show("Вход выполнен успешно!");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Access"));
        }
        private bool CanLogin(object obj)
        {
            return AccessToApp.Attempt < 3;
        }
        #endregion
        #region Окно с БД
        public ObservableCollection<Accounts> Accounts { get; set; } = AccountList.GetList();

        public Accounts newAccount { get; set; } = new Accounts();
        public Accounts selectedAccount { get; set; } = new Accounts();
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand(AddNewAccount, CanAdd);
            }
        }
        public bool CanAdd(object obj)
        {
            return newAccount != null ? true : false;
        }

        public void AddNewAccount(object obj)
        {
            AccountList.AddNewAccount(newAccount);
        }
        public ICommand ClickDelete
        {
            get
            {
                return new DelegateCommand(DeleteAccount, CanDelete);
            }
        }

        public bool CanDelete(object obj)
        {
            return selectedAccount != null ? true : false;
        }

        public void DeleteAccount(object obj)
        {
            Console.WriteLine("Удалили аккаунт");
            Accounts.Remove(selectedAccount);
        }
        #endregion
    }
}
