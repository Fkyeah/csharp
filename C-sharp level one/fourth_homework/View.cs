using System;

class View
{
    public int getInt(string str)
    {
        int number = 0;
        bool success = true;
        do
        {
            if (!success) Console.WriteLine("Ошибка. Введите числовое значение");
            Console.WriteLine(str);
            success = Int32.TryParse(Console.ReadLine(), out number);
        } while (!success);
        return number;
    }
    public string getString(string str)
    {
        string String = "";
        Console.WriteLine(str);
        String = Console.ReadLine();
        return String;
    }
    public void Pause()
    {
        Console.WriteLine("\nДля продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}

