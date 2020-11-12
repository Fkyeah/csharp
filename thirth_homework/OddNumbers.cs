using System;

class OddNumbers
{
    public int getSum(View view)
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

