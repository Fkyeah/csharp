using System;
using System.Security.Cryptography.X509Certificates;

class OddNumbers
{
    View view = new View();
    public int getSum()
    {
        int digit = 0;
        int sum = 0;
        do
        {
            digit = view.getInt("Введите число.");
            if (digit % 2 != 0 && digit > 0) sum += digit;
        } while (digit != 0);
        return sum;
    }
}

