using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void FirstQuest(string name, string lastName, int age, int height, double weight)
    {
        Console.WriteLine("Данные пользователя: " + name + " " + lastName + " " + age + " лет. " + "Рост - " + height + " и вес - " + weight);
        Console.WriteLine(string.Format("Данные пользователя: {0} {1} {2} лет. Рост - {3} и вес - {4}", name, lastName, age, height, weight));
        Console.WriteLine($"Данные пользователя: {name} {lastName} {age} лет. Рост - {height} и вес - {weight}");
    }
    static double SecondQuest(double m, int height)
    {
        double h = (double)height / 100;
        return m / (Math.Pow(h,2));
    }
    static double ThirdQuest(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    static void FourthQuest(int a, int b)
    {
        Console.WriteLine($"До обмена: А = {a} и B = {b}");
        int t = a;
        a = b;
        b = t;
        Console.WriteLine($"После обмена через третью переменную Т: А = {a} и B = {b}");
        a ^= b;
        b ^= a;
        a ^= b;
        Console.WriteLine($"Обратный обмен без использования третьей переменной: А = {a} и B = {b}");
    }
    static void Print(string S)
    {
        Console.WriteLine(S);
    }
    static void Pause()
    {
        Console.ReadKey();
    }
    static void Main()
    {
        Console.SetCursorPosition(30, 1);
        Print("Домашнее задание студента GeekBrains Тихонова Дмитрия\n");
        /* 1. Написать программу «Анкета». 
         * Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
         * В результате вся информация выводится в одну строчку.
        а) используя склеивание;
        б) используя форматированный вывод;
        в) *используя вывод со знаком $. */
        Print("Программа: Анкета.\nВведите Ваше имя:");
        string name = Console.ReadLine();
        Print("Введите Вашу фамилию:");
        string lastName = Console.ReadLine();
        Print("Введите Ваш возраст:");
        int age = Convert.ToInt32(Console.ReadLine());
        Print("Введите город Вашего проживания (для 5-ого задания):");
        string city = Console.ReadLine();
        Print("Введите Ваш рост:");
        int height = Convert.ToInt32(Console.ReadLine());
        Print("Введите Ваш вес:");
        double weight = Convert.ToDouble(Console.ReadLine());
        FirstQuest(name, lastName, age, height, weight);
        /* 2. Ввести вес и рост человека. 
         * Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
         * где m — масса тела в килограммах, h — рост в метрах */
        Print($"Индекс массы для пользователя равен {SecondQuest(weight, height):0.00}");
        Pause();
        /* 3. 
         * а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
         * по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
         * Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
         * б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода; */
        Print("\nВведите координаты двух точек: х1, у1 и х2, у2.\nПрограмма посчитает расстояние между ними.");
        Print("Введите х1:");
        int x1 = Convert.ToInt32(Console.ReadLine());
        Print("Введите у1:");
        int y1 = Convert.ToInt32(Console.ReadLine());
        Print("Введите х2:");
        int x2 = Convert.ToInt32(Console.ReadLine());
        Print("Введите у2:");
        int y2 = Convert.ToInt32(Console.ReadLine());
        Print($"Расстояние между точками: х1 = {x1}, y1 = {y1} и х2 = {x2}, у2 = {y2} равно {ThirdQuest(x1, y1, x2, y2):0.00}");
        Pause();
        /* 4. Написать программу обмена значениями двух переменных.
         * а) с использованием третьей переменной;
         * б) *без использования третьей переменной. */
        Print("\nДалее программа выполнит обмен значений двух переменных А и B. Обмен возможен двумя способами:");
        Print("1) С использованием третьей переменной;");
        Print("2) Без использования третьей переменной.");
        Print("Введите А:");
        int a = Convert.ToInt32(Console.ReadLine());
        Print("Введите B:");
        int b = Convert.ToInt32(Console.ReadLine());
        FourthQuest(a, b);
        /* 5.
         * а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
         * б) Сделать задание, только вывод организуйте в центре экрана
         * в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y) */
        Pause();
        Print($"\n{name} {lastName} проживает в городе {city}");
        /* 6. * Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
         * Достаточно решить 3 задачи.
         * Записывайте в начало программы условие и свою фамилию. 
         * Все программы создавайте в одном решении. 
         * Задания со звездочками выполняйте в том случае, если вы решили задачи без звездочек. */
        Pause();
        Console.SetCursorPosition(40, 50);
        Print($"{name} {lastName} проживает в городе {city}");
        Console.SetCursorPosition(40, 60);
        Pause();
    }
}