using System;
using System.Collections.Generic;
using System.IO;

class Second_Quest
{
    /* 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
        б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
        в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
            возвращает минимум через параметр. */
    
    private delegate double function(double x);
    private double F1(double x)
    {
        return x * x - 50 * x + 10;
    }

    public static double F2(double x)
    {
        return x * x - 10 * x + 50;
    }
    private void SaveFunc(string fileName, double a, double b, double h, function F)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x <= b)
        {
            bw.Write(F(x));
            x += h;
        }
        bw.Close();
        fs.Close();
    }
    private List<double> Load(string fileName, ref double min)
    {
        List<double> list = new List<double>();
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        min = double.MaxValue;
        double d;
        for (int i = 0; i < fs.Length / sizeof(double); i++)
        {
            d = bw.ReadDouble();
            if (d < min) min = d;
            list.Add(d);
        }
        bw.Close();
        fs.Close();
        return list;
    }
    public void Main()
    {
        View view = new View();
        function[] F = { F1, F2 };
        int index = 0;
        do
        {
            index = view.getInt("Сделайте выбор: 1 - функция F1, 2 - функция F2");
        } while (index != 1 && index != 2);
        int startRange = view.getInt("Введите начало диапазона:");
        int endRange = view.getInt("Введите конец диапазона:");
        double step = view.getDouble("Введите шаг:");
        SaveFunc("data.bin", startRange, endRange, step, F[index - 1]);
        double minValue = 0;
        Console.WriteLine("Список значений");
        foreach (double t in Load("data.bin", ref minValue))
        {
            Console.WriteLine($"{t:0.00} ");
        }
        Console.WriteLine($"\nМинимальное значение из получившегося списка: {minValue}");
        view.Pause();
    }

}

