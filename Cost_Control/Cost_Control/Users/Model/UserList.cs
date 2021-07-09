using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cost_Control.CostManager.Model
{
    [Serializable]
    public static class UserList
    {
        private static string _fileName = "JsonUser.json";
        private static ObservableCollection<User> _users = LoadUsers();
        public static ObservableCollection<User> Users
        {
            get => _users;
            private set
            {
                _users = value;
            }
        }
        public static IEnumerable<string> GetUserList() => from t in _users select t.Name;
        public static bool FindUser(User user) => _users.Any(t => t.Id == user.Id) ? true : false;
        private static bool FindUser(string userName) => _users.Any(t => t.Name == userName) ? true : false;
        public static bool AddUser(string newUser)
        {
            int id;
            if (_users.Count == 0)
                id = 1;
            else
                id = _users.Max(t => t.Id) + 1;
            if (!FindUser(newUser))
            {
                _users.Add(new User (id, newUser));
                return true;
            }
            else
                return false;
        }
        public static void DeleteUser(User user) => Users.Remove(user);
        public static void SaveUsers()
        {
            string json = JsonSerializer.Serialize(_users);
            try
            {
                string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(_users, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_fileName, outputJSON + Environment.NewLine);
                Console.WriteLine("Запись выполнена!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Запись не выполнена! Ошибка:\n{e.Message}");
            }
        }

        public static ObservableCollection<User> LoadUsers()
        {
            try
            {
                if (!File.Exists(_fileName))
                    File.Create(_fileName);
                string json = File.ReadAllText(_fileName);
                Console.WriteLine(json);
                Users = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Users;
        }
    }
}
