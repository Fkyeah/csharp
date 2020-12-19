using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Домашнее задание студента GeekBrains Тихонова Дмитрия");
        View view = new View();
        view.Pause();
        Console.WriteLine("Первое задание: Изменить программу вывода функции.");
        view.Pause();
        First_Quest fisrt = new First_Quest();
        fisrt.Main();
        Console.WriteLine("Второе задание: Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.");
        view.Pause();
        Second_Quest second = new Second_Quest();
        second.Main();
        Console.WriteLine("Третье задание: Переделать программу «Пример использования коллекций»");
        view.Pause();
        Student student = new Student();
        student.Main();
        Console.ReadKey();
    }
}

