using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lesson_two_homework
{
    class Program
    {
        static void Main()
        {
            /* Second Quest */
            Console.WriteLine("Перед началом работы введите логин и пароль. У вас три попытки.");
            Authorization user = new Authorization();
            bool success = false;
            int tryCount = 0;
            int maxTry = 3;
            do
            {
                success = user.checkUser(user.checkLogin("Введите логин"), user.checkPassword("Введите пароль"));
                tryCount++;
                if (tryCount == maxTry && success == false)
                {
                    Console.WriteLine("Вы использовали все три попытки. Увы, войти не удалось. Программа завершает свою работу");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            } while (tryCount <= maxTry && success == false);
            /* First Quest */
            View view = new View();
            view.Pause();
            Console.WriteLine("\nПрограмма выведет из трех чисел минимальное\nВведите три числа.");
            int a = view.getInt("Введите А:");
            int b = view.getInt("Введите B:");
            int c = view.getInt("Введите С:");
            GetMin Min = new GetMin();
            Console.WriteLine($"Минимальное число - {Min.getValue(a, b, c)}");
            /* Second Quest */
            view.Pause();
            Console.WriteLine("\nДалее программа подсчитает количество цифр в числе");
            int numberForCount = view.getInt("Введите число для подсчета:");
            CountDigits count = new CountDigits();
            Console.WriteLine($"Количество цифр в числе {numberForCount} = {count.getCount(numberForCount)}");
            /* Thirth Quest */
            view.Pause();
            Console.WriteLine("\nВводите числа с клавиатуры.\nПрограмма будет принимать их, пока не будет введен 0.\nВ конце она выдаст сумму всех нечетных положительных чисел");
            OddNumbers odd = new OddNumbers();
            int sum = odd.getSum();
            Console.WriteLine($"Сумма положительных нечетных чисел равна {sum}");
            /* Fifth Quest */
            view.Pause();
            Console.WriteLine("\nСледующая программа позволяет рассчитать индекс массы тела.\nПо полученному результату она выдаст рекомендации по похудению или набору массы тела");
            Index index = new Index();
            int height = view.getInt("Введите ваш рост в сантиметрах:");
            int weight = view.getInt("Введите ваш вес в киллограммах");
            double userIdx = index.getIdx(weight, height);
            Console.WriteLine($"Индекс массы тела равен {userIdx:0.00}");
            index.getRecomendation(userIdx);
            /* Sixth Quest */
            view.Pause();
            GoodNumbers goodNumber = new GoodNumbers();
            Console.WriteLine("\nПрограмма выведет общее кол-во хороших чисел в диапазоне от 1 до указанного вами числа.\nМаксимально возможное - 1000000000");
            int maxLimit;
            do
            {
                maxLimit = view.getInt("Введите число, указывающее на конец диапазона (число должно быть больше 1)");
            } while (maxLimit <= 1);
            goodNumber.findNumber(maxLimit);
            /* Seventh Quest*/
            view.Pause();
            Console.WriteLine("\nДалее с помощью рекурсионных методов программа выведет последовательность чисел от a до b и посчитает ее сумму.");
            Recursion recursion = new Recursion();
            int recA = view.getInt("Введите a:");
            int recB;
            do
            {
                recB = view.getInt("Введите b (при условии, что b должно быть больше a):");
            } while (recB < recA);
            Console.WriteLine($"Последовательность чисел:");
            recursion.getSequence(recA, recB);
            Console.WriteLine($"\nСумма данной последовательности равна {recursion.SequenceSum(recA, recB)}");
            Console.ReadKey();
            
        }
    }
}
