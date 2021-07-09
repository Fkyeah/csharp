using Cost_Control.CostManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Cost_Control.Users
{
    class UsersViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Users";
        public ObservableCollection<User> Users { get; set; } = UserList.Users;
        public User SelectedUser { get; set; }
        public string NewUser { get; set; } = "";
        public string AddUserResult { get; set; }
        public ICommand ClickAddUser
        {
            get => new DelegateCommand(AddUser, CanAdd);
        }
        private bool CanAdd(object obj) => NewUser.Length>1;
        private void AddUser(object obj)
        {
            if (UserList.AddUser(NewUser))
                AddUserResult = "Успешно добавлен!";
            else 
                AddUserResult = "Не добавлен!";
            OnPropertyChanged("Users");
        }
        public ICommand ClickDeleteUser
        {
            get => new DelegateCommand(DeleteUser, CanDelete);
        }
        private bool CanDelete(object obj) => SelectedUser != null;
        private void DeleteUser(object obj)
        {
            UserList.DeleteUser(SelectedUser);
            OnPropertyChanged("Users");
        }
    }
}
