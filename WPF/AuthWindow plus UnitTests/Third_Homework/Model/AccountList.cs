using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace Third_Homework.Model
{
    [Serializable]
    public static class AccountList
    {
        public static ObservableCollection<Account> accounts = new ObservableCollection<Account>();

        public static ObservableCollection<Account> GetList(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                Console.WriteLine(json);
                accounts = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Account>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return accounts;
        }
        
        public static bool SaveList(ObservableCollection<Account> accounts, string path)
        {
            string json = JsonSerializer.Serialize(accounts);
            try
            {
                string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, outputJSON + Environment.NewLine);
                Console.WriteLine("Запись выполнена!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Запись не выполнена! Ошибка:\n{e.Message}");
                return false;
            }
        }

        public static bool Find(Account account)
        {
            foreach (Account acc in accounts)
                if (acc.Username == account.Username && acc.Password == account.Password) return true;
            return false;
        }
    }
}
