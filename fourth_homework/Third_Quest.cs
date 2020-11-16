using System;
using System.IO;
using System.Text;

class Third_Quest
{
    private string path { get; set; }
    private string[] LoginPass { get; set; }
    public Third_Quest(string path) 
    {
        this.path = path;
        StreamReader text = new StreamReader(path);
        int i = 0;
        string[] trueLogPass = new string[2];
        while (!text.EndOfStream)
        {
            trueLogPass[i] = text.ReadLine();
            i++;
        }
        LoginPass = trueLogPass;
    }
    private struct Account
    {
        public string Login;
        public string Pass;
    }
    private bool checkLogin(string userLogin)
    {
        return userLogin == LoginPass[0] ? true : false;
    }
    private bool checkPassword(string userPass)
    {
        return userPass == LoginPass[1] ? true : false;
    }
    private bool checkUser(bool _checkLogin, bool _checkPass)
    {
        return _checkLogin == false || _checkPass == false ? false : true;
    }
    public void Main()
    {
        /* Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
            * Создайте структуру Account, содержащую Login и Password. */
        Console.WriteLine("Третье задание.\nАвторизация. Для продолжения работы вам необходимо внести верные логин и пароль,\nкоторые хранятся в ../bin/Debug/Authorization.txt\n");
        View view = new View();
        Account trueAccount;
        trueAccount.Login = LoginPass[0];
        trueAccount.Pass = LoginPass[1];
        Account user;
        user.Login = view.getString("Введите логин");
        user.Pass = view.getString("Введите пароль");
        if (checkUser(checkLogin(user.Login), checkPassword(user.Pass))) Console.WriteLine("Авторизация успешна");
        else 
        {
            Console.WriteLine("Увы, данные введены неверно. Программа завершает свою работу");
            view.Pause();
            Environment.Exit(0);
        }

    }
}
