using System;
using System.Collections.Generic;
using System.Linq;

namespace Fragment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            Console.WriteLine("Исходный словарь:");
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("Свернуть обращение к OrderBy с использованием лямбда - выражения $. Результат:");
            // а) Свернуть обращение к OrderBy с использованием лямбда - выражения $.
            var lambda = dict.OrderByDescending(pair => pair.Value);
            foreach (var pair in lambda)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            // б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.

            Console.ReadKey();
        }
    }
}
