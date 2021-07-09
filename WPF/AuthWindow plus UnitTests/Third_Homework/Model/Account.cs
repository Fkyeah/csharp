using System;
using System.ComponentModel;
using Third_Homework.Model.Validation;

namespace Third_Homework.Model
{
    [Serializable]

    public class Account : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _id;
        private string _username;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Username 
        { 
            get => _username; 
            set
            {
                if (value != _username)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("Логин не может быть пустым");
                        throw new Exception("Логин не может быть пустым");
                    }
                    _username = value;
                    Console.WriteLine("Уведомляем об изменении логина");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Username"));
                }
            }                  
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("Пароль не может быть пустым");
                        throw new Exception("Пароль не может быть пустым");
                    }
                    _password = value;
                    Console.WriteLine("Уведомляем об изменении пароля");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }

        public string Error { get; set; }

        public string this[string columnName]
        {
            get
            {
                string Error = String.Empty;
                switch(columnName)
                {
                    case "Password":
                        if (Password.Length > 15)
                        {
                            Error = "Пароль не может быть длиннее 15-ти символов";
                            Console.WriteLine(Error);
                        }
                        break;
                }
                return Error;
            }
        }

        public Account(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
        public Account()
        {

        }
    }
}
