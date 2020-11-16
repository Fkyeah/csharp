using System;

class Program
{
    static void Main(string[] args)
    {
        View view = new View();
        /* Первое задание */
        First_Quest FirstQuest = new First_Quest();
        FirstQuest.Main();
        view.Pause();
        /* Второе задание */
        int n = view.getInt("\nВторое задание.\nВведите размерность массива");
        int firstValue = view.getInt("Введите начальное значение");
        int step = view.getInt("Введите шаг:");
        Second_Quest secondQuest = new Second_Quest("Text.txt", n, firstValue, step);
        secondQuest.Main();
        /* Третье задание */
        Third_Quest third = new Third_Quest("Authorization.txt");
        third.Main();
        /* Четвертое задание */
        int rows = view.getInt("Введите кол-во строк:");
        int columns = view.getInt("Введите кол-во столбцов: ");
        Fourth_Quest fourth = new Fourth_Quest(rows, columns);
        fourth.Main();
        view.Pause();
    }
}
