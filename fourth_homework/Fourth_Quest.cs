using System;
using System.Text;
using System.IO;
class Fourth_Quest
{
    private int[,] array { get; set; }
    private string path = "Fourth_Quest.txt";
    public Fourth_Quest(int rows, int columns)
    {
        int[,] _array = new int[rows, columns];
        Random rand = new Random();
        int minValue = 0;
        int maxValue = 100;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                _array[i, j] = rand.Next(minValue, maxValue);
            }
        }
        this.array = _array;
    }
    private void getArray()
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine("");
        }
    }
    private int getSumAll(int[,] _array)
    {
        int result = 0;
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                result += _array[i, j];
            }
        }
        return result;
    }
    private int getSumAfterNumber(int[,] _array, int a)
    {
        int result = 0;
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                if (_array[i, j] > a) result += _array[i, j];
            }
        }
        return result;
    }
    private void getMin(ref int _min)
    {
        _min = array[0, 0];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (_min >= array[i, j]) _min = array[i, j];
            }
        }
    }
    private void getMax(ref int _max)
    {
        _max = array[0, 0];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (_max <= array[i, j]) _max = array[i, j];
            }
        }
    }
    private void FileWriter(int[,] array)
    {
        try
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.ASCII);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == array.GetLength(1) - 1) sw.Write($"{array[i, j]}");
                    else sw.Write($"{array[i, j]} ");
                }
                sw.WriteLine("");
            }
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"При записи возникла ошибка:\n{e.Message}");
        }   
    }
    private void FileReader()
    {
        try
        {
            string[] lines = File.ReadAllLines(path);
            int[,] arr = new int[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    arr[i, j] = Convert.ToInt32(temp[j]);
            }
            // проверяем выводом на консоль
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine("");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"При чтении возникла ошибка:\n{e.Message}");
        }   
    }
    public void Main()
    {
        View view = new View();
        /*а) Реализовать класс для работы с двумерным массивом.
         *   Реализовать конструктор, заполняющий массив случайными числами.
         *   Создать методы, которые возвращают сумму всех элементов массива, 
         *   сумму всех элементов массива больше заданного, 
         *   свойство, возвращающее минимальный элемент массива, 
         *   свойство, возвращающее максимальный элемент массива, 
         *   метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out)
         *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл. */
        Console.WriteLine("Получившийся массив:");
        getArray();
        Console.WriteLine($"Сумма всех элементов массива равна: {getSumAll(array)}");
        int numb = view.getInt("Программа посчитает сумму элементов массива больше указанного вами числа:");
        Console.WriteLine($"Сумма элементов массива больше числа {numb} равна {getSumAfterNumber(array, numb)}");
        int min = 0;
        getMin(ref min);
        Console.WriteLine($"Минимальный элемент исходного массива равен {min}");
        int max = 0;
        getMax(ref max);
        Console.WriteLine($"Максимальный элемент исходного массива равен {max}");
        Console.WriteLine("Массив записан в файл, который хранится в каталоге ../bin/Debug/Fourth_Quest.txt");
        Console.WriteLine("Массив прочитанный из файла:");
        FileWriter(array);
        FileReader();
    }
}

