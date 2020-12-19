using System;

class First_Quest
{
    public void Main()
    {
        /*
        * Дан целочисленный массив из 20 элементов. 
        * Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
        * Написать программу, позволяющую найти и вывести количество пар элементов массива, 
        * в которых хотя бы одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
        * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4. */
        int[] array = new int[20];
        int MinValue = -10000;
        int MaxValue = 10000;
        Console.WriteLine("Первое задание.\nМассив из рандомных чисел в диапазоне от -10000 до 10000:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = GetNumber(MinValue, MaxValue);
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine($"\nКоличество пар в текущем массиве: {TwoNumbers(array)}");
    }
    Random rand = new Random();
    public int GetNumber(int min, int max)
    {
        return rand.Next(min, max);
    }
    public int TwoNumbers(int[] array)
    {
        int count = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] % 3 == 0 || array[i-1] % 3 == 0)
                count++;
        }
        return count;
    }
}

