using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            // а) для целых чисел;
            ArrayList listNonGeneric = new ArrayList() { 1, 4, 3, 5, 4, 7, 6, 5, 4, 5, 3, 1, 8, 9, 8, 4 };
            int[] sortArr = new int[9];
            foreach (int val in listNonGeneric)
            {
                Console.Write($"{val} ");
                sortArr[val - 1]++;
            }
            Console.WriteLine();
            listNonGeneric.Sort();
            foreach (int val in listNonGeneric)
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
            for (int j = 1; j < sortArr.Length; j++)
            {
                if (sortArr[j] == 0) continue;
                Console.WriteLine($"Число {j}  встречается {sortArr[j]} раз");
            }
            // б) *для обобщенной коллекции;
            // в) *используя Linq.
            Console.WriteLine("Для обобщенной коллекции с помощью LINQ");
            List<int> listGeneric = new List<int>() { 1, 4, 3, 5, 4, 7, 6, 5, 4, 5, 3, 1, 8, 9, 8, 4 };
            IEnumerable<int> distNum = listGeneric.Distinct().OrderBy(value => value);
            foreach(var num in distNum)
            {
                Console.WriteLine($"Число {num} встречается {listGeneric.Where(val => val == num).Count()} раз");
            }
            Console.ReadLine();
        }        
    }
}
