using System;
using System.Text;
using System.Text.RegularExpressions;

class First_Quest
{
    private string _login;
    public string Login
    {
        get
        {
            return _login;
        }
        set
        {
            try
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[0] >= '1' && value[0] <= '9' || value[i] == ' ')
                    {
                        throw new Exception("Логин не может начинаться с цифры и содержать пробел. Введите корректный логин:");
                    }
                }
            _login = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла следующая ошибка:\n{e}\nДавайте попробуем повторить ввод логина:");
                Login = Console.ReadLine();
            }
        }
    }
    private void RegCheckLogin()
    {
        string login = Console.ReadLine();
        string regexMask = @"^\D[a-zA-Z0-9]{1,9}$";
        Regex regex = new Regex(regexMask);
        if (regex.IsMatch(login))
        {
            _login = login;
        }
        else
        {
            Console.WriteLine("Введен некорректный логин. Попробуйте еще раз:");
            RegCheckLogin();
        }  
    }
    public void Main()
    {
        Console.WriteLine("Перед началом работы давайте введем логин.");
        Console.WriteLine("Выберите метод проверки логина:\n1 - Без регулярных выражений;\n2 - С использованием регулярных выражений\n0 - Для выхода:");
        View view = new View();
        int UserChoice = view.getInt("Введите пункт:");
        switch (UserChoice)
        {
            case 1:
                Console.WriteLine("Введите логин:");
                Login = Console.ReadLine();
                break;
            case 2:
                Console.WriteLine("Введите логин:");
                RegCheckLogin();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Такого пункта нет.");
                UserChoice = view.getInt("Введите пункт:");
                break;
        }
        Console.WriteLine($"Введенный вами логин: {Login}");
        view.Pause();
    }
}
