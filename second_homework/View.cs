using System;
using System.Runtime.Remoting.Messaging;

class View
{
    public int getInt(string str)
    {
        int number;
        bool success = true;
        do
        {
            if (!success) Console.WriteLine("Ошибка. Введите числовое значение.");
            Console.WriteLine(str);
            success = Int32.TryParse(Console.ReadLine(), out number);
        }
        while (!success);
        return number;
    }
    public void Pause()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }
}

