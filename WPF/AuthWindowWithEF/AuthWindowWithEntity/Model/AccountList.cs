using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace AuthWindowWithEntity.Model
{
    [Serializable]
    public static class AccountList
    {
        private static AccountsDBContainer _context = new AccountsDBContainer();
        private static ObservableCollection<Accounts> _accounts = new ObservableCollection<Accounts>();

        public static ObservableCollection<Accounts> GetList()
        {
           _context.AccountsSet.LoadAsync();
            _accounts = _context.AccountsSet.Local;
            return _accounts;
        }

        public static void AddNewAccount(Accounts newAccount)
        {
            _context.AccountsSet.Add(
                new Accounts
                {
                    Id = newAccount.Id,
                    Login = newAccount.Login,
                    Password = newAccount.Password
                });
            _context.SaveChanges();
        }

        public static void DeleteAccount(Accounts account)
        {
            _context.AccountsSet.Remove(account);
            _context.SaveChanges();
        }

        public static bool Find(Accounts account)
        {
            GetList();
            foreach (Accounts acc in _accounts)
                if (acc.Login == account.Login && acc.Password == account.Password) return true;
            return false;
        }
    }
}
