using System;

class View
{
    public int getInt(string str)
    {
        int number = 0;
        bool success = true;
        do
        {
            Console.WriteLine(str);
            if (!success) Console.WriteLine("Ошибка. Введите числовое значение");
            success = Int32.TryParse(Console.ReadLine(), out number);
        } while (!success);
        return number;
    }
    public double getDouble(string str)
    {
        double number = 0;
        bool success = true;
        do
        {
            Console.WriteLine(str);
            if (!success) Console.WriteLine("Ошибка. Введите числовое значение с плавающей запятой/точкой");
            success = Double.TryParse(Console.ReadLine().Replace('.',','), out number);
        } while (!success);
        return number;
    }
    public string getString(string str)
    {
        Console.WriteLine(str);
        return Console.ReadLine();
    }
    public void Pause()
    {
        Console.WriteLine("\nДля продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}

