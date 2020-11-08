using System;

class Authorization 
{
    string userLogin;
    string userPass;
    public bool checkLogin(string str)
    {
        Console.WriteLine(str);
        userLogin = Console.ReadLine();
        string trueLogin = "root";
        return userLogin == trueLogin ? true : false;
    }
    public bool checkPassword(string str)
    {
        Console.WriteLine(str);
        userPass = Console.ReadLine();
        string truePassword = "GeekBrains";
        return userPass == truePassword ? true : false;
    }
    public bool checkUser(bool _checkLogin, bool _checkPass)
    {
        if (_checkLogin == false || _checkPass == false)
        {
            Console.WriteLine("К сожалению данные введены неверно");
            return false;
        }
        else
        {
            Console.WriteLine("Авторизация успешна!\n");
            return true;
        } 
            
    }
}

