using System;
using System.IO;
using System.Text;


class Second_Quest
{
    private int arraySize { get; set; }
    private string path { get; set; }
    public int[] setArray { get; set; }
    public Second_Quest(int _arraySize, int firstValue, int step)
    {
        this.arraySize = _arraySize;
        int[] array = new int[_arraySize];
        array[0] = firstValue;
        for(int i = 1; i < array.Length; i++)
        {
            array[i] = array[i - 1] + step;
        }
        setArray = array;
    }
    public Second_Quest(string _path, int _arraySize, int firstValue, int step)
    {
        this.path = _path;
        this.arraySize = _arraySize;
        int[] array = new int[_arraySize];       
        array[0] = firstValue;       
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = array[i - 1] + step;
        }
        FileWriter(array);
    }
    public int Sum { get; set; }
    private void getSum(int[] array)
    {
        this.Sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            this.Sum += array[i];
        }
    }
    public void Inverse()
    {
        int[] array = setArray;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= -1;
        }
        setArray = array;       
    }
    private void Multi(int n)
    {
        int[] array = setArray;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= n;
        }
        setArray = array;
    }
    private int MaxCount()
    {
        int[] array = setArray;
        int max = array[0];
        this.Sum = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] >= max)
            {
                max = array[i];
            }
        }
        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] == max) this.Sum++;
        }
        return max;
    }
    private void getArray()
    {
        int[] array = setArray;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine("");
    }
    private void FileWriter(int[] array)
    {
        StreamWriter sw = new StreamWriter(path, false, Encoding.ASCII);
        for (int i = 0; i < array.Length; i++)
        {
            sw.WriteLine($"{array[i]}");
        }
        sw.Close();
    }
    private void FileReader(string path)
    {
        StreamReader text = new StreamReader(path);
        int a = 0;
        int counter = 0;
        int[] newArray = new int[arraySize];
        while (!text.EndOfStream)
        {
            a = Int32.Parse(text.ReadLine());
            newArray[counter] = a;
            counter++;
        }
        setArray = newArray;
        text.Close();
    }
    View view = new View();
    public void Main()
    {
        /* а) Дописать класс для работы с одномерным массивом. 
         * Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
         * Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, 
         * умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. 
         * В Main продемонстрировать работу класса. */ 
        FileReader(path);
        Console.WriteLine("Получившийся массив:");
        getArray();
        getSum(setArray);
        int sum = Sum;
        Console.WriteLine($"Сумма элементов массива равна: {sum}");
        Inverse();
        FileWriter(setArray);
        Console.WriteLine($"Инверсированный массив: ");
        getArray();
        Inverse();
        Console.WriteLine("Далее программа умножит каждый элемент изначального массива на введенное вами число");
        int n = view.getInt("Введите множитель: ");
        Multi(n);
        FileWriter(setArray);
        getArray();
        Console.WriteLine($"Максимальный элемент массива: {MaxCount()}, количество таких элементов: {Sum}");
        Console.WriteLine("Результаты перемножения записаны в файл ../bin/Debug/Text.txt");
    }
}

