using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Third_Homework.Model;
using System.Windows;


namespace Third_Homework.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public Account CurrentAccount { get; set; } = new Account(4, "None", "None");

        private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();
        public ObservableCollection<Account> Accounts 
        { 
            get
            {
                return _accounts;
            }
            set
            {
                if (value != _accounts)
                {
                    _accounts = value;
                    Console.WriteLine("Уведомляем об изменении списка аккаунтов");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Accounts"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public bool Access { get; set; } = false;

        public Account newAccount { get; set; } = new Account();
        public Account selectedAccount { get; set; } = new Account();
        private void Login(object obj)
        {
            Console.WriteLine("Execute Click");
            Access = AccessToApp.Checks(CurrentAccount);
            Console.WriteLine(Access);
            if (Access) MessageBox.Show("Вход выполнен успешно!");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Access"));   
        }
        private bool CanLogin(object obj)
        {
            return AccessToApp.Attempt < 3;
        }

        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand(Login, CanLogin);
            }
        }

        public int AttemptCount
        {
            get => AccessToApp.Attempt;
        }

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand(AddNewAccount, CanAdd);
            }
        }

        public bool CanAdd(object obj)
        {
            return newAccount != null ?  true : false;
        }

        public void AddNewAccount(object obj)
        {
            Console.WriteLine("Добавился новый аккаунт");
            Accounts.Add(new Account(Accounts.Count + 1, newAccount.Username, newAccount.Password));
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
            return (selectedAccount != null);
        }

        public void DeleteAccount(object obj)
        {
            Console.WriteLine("Удалили аккаунт");
            Accounts.Remove(selectedAccount);
        }

        public ICommand ClickSave
        {
            get
            {
                return new DelegateCommand(Save, CanSave);
            }
        }

        public void Save(object obj)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.ShowDialog();
            bool saveSuccess = AccountList.SaveList(Accounts, fileDialog.FileName);
            if (saveSuccess) MessageBox.Show("Список аккаунтов успешно сохранен на диск!");
            else MessageBox.Show("Файл не сохранен!");
        }
        public bool CanSave(object obj)
        {
            return (Accounts.Count != 0) ? true : false;
        }

        public ICommand ClickOpen
        {
            get
            {
                return new DelegateCommand(Open, CanOpen);
            }
        }

        public void Open(object obj)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                Accounts = AccountList.GetList(fileDialog.FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка!\n{e.Message}");
            }
        }
        
        public bool CanOpen(object obj)
        {
            return true;
        }
    }
}
