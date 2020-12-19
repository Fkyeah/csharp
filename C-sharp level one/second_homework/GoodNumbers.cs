using System;
using System.Numerics;

namespace Lesson_two_homework
{
    class GoodNumbers
    {
        BigInteger count = 0;
        BigInteger number1 = 1;
        BigInteger number2 = 1;
        int intermediateNumber = 0;
        int sum = 0;
        public BigInteger findNumber(BigInteger maxLimit)
        {
            DateTime startTime = DateTime.Now;
            while (number1 <= maxLimit) // 1000000000
            {
                while (number1 != 0)
                {
                    
                    intermediateNumber = (int)number1 % 10;
                    number1 /= 10;
                    sum += (int)intermediateNumber;
                }
               if (number2 % sum == 0)
                {
                    count++;
                    double time = (DateTime.Now - startTime).TotalSeconds;
                    Console.WriteLine($"число = {number2} , сумма цифр = {sum}. Найдено за {time} секунд. Общее количество = {count}");
                }
                sum = 0;
                number2++;
                number1 = number2;
            }
            return count;
        }
    }
}
