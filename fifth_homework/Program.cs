using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Домашнее задание Студента GeekBrains Тихонова Дмитрия");
        Console.WriteLine("Выберите номер задания, которое хотите выполнить:");
        Console.WriteLine("1 - Авторизация.Проверка логина");
        Console.WriteLine("2 - Класс Message по работе со стороками");
        Console.WriteLine("3 - Проверка перестановки строк");
        Console.WriteLine("4 - Задание ЕГЭ с учениками");
        Console.WriteLine("5 - Игра: Верю. Не верю.");
        Console.WriteLine("0 - для выхода из программы");
        View view = new View();
        while (true)
        {
            int UserChoise = view.getInt("Выберите вариант задания для проверки:");
            switch (UserChoise)
            {
                case 1:
                    First_Quest first = new First_Quest();
                    first.Main();
                    break;
                case 2:
                    Message message = new Message();
                    message.Main();
                    break;
                case 3:
                    Thirth_Quest thirth = new Thirth_Quest();
                    thirth.Main();
                    break;
                case 4:
                    Fourth_Quest fourth = new Fourth_Quest();
                    fourth.Main();
                    break;
                case 5:
                    Fifth_Quest fifth = new Fifth_Quest();
                    fifth.Main();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Нет такого варианта");
                    break;
            }
        }
    }
}

