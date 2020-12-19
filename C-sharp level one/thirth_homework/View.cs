using System;

class View
{
    public int getInt(string str)
    {
        int number;
        bool success = true;
        /* Второе задание. Пункт Б */
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
    // Третье задание. Пункт под звездочкой - выбрасывание исключения
    public int getDenominator(string str)
    {
        int number = 1;
        bool success = true;
        do
        {
            if (!success) 
                Console.WriteLine("Ошибка. Введите числовое значение.");
            else if (number == 0) 
                throw new System.ArgumentException("Знаменатель не может быть равен 0");
            Console.WriteLine(str);
            success = Int32.TryParse(Console.ReadLine(), out number);
        } while (!success || number == 0);
        return number;
    }
}