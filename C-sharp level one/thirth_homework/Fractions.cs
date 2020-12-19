using System;

class Fractions
{
    public void simplificationFraction(ref Fraction f)
    {
        if (f.numerator % 2 == 0 && f.denominator % 2 == 0) // включает в себя упрощение на 2 или 4, или 6, или 8
        {
            f.numerator /= 2;
            f.denominator /= 2;
            simplificationFraction(ref f);
        }
        else if (f.numerator % 3 == 0 && f.denominator % 3 == 0) // включает в себя упрощение на 3 или 9
        {
            f.numerator /= 3;
            f.denominator /= 3;
            simplificationFraction(ref f);
        }
        else if (f.numerator % 5 == 0 && f.denominator % 5 == 0)
        {
            f.numerator /= 5;
            f.denominator /= 5;
            simplificationFraction(ref f);
        }
        else if (f.numerator % 7 == 0 && f.denominator % 7 == 0)
        {
            f.numerator /= 7;
            f.denominator /= 7;
            simplificationFraction(ref f);
        }
    }
    private void getCommonDenominator(ref Fraction f1, ref Fraction f2)
    {
        for (int i = 1; i <= f2.denominator; i++)
        {
            if (f1.denominator * i % f2.denominator == 0)
            {
                f1.numerator *= i;
                f1.denominator *= i;
                int addFactor = f1.denominator / f2.denominator;
                f2.numerator *= addFactor;
                f2.denominator *= addFactor;
                break;
            }
        }
        Console.WriteLine($"\nПриведение к общему знаменателю.\nПервая дробь  - {f1.numerator} / {f1.denominator}");
        Console.WriteLine($"Вторая дробь  - {f2.numerator} / {f2.denominator}");
    }
    public Fraction Plus(Fraction f1, Fraction f2) // TODO
    {
        getCommonDenominator(ref f1, ref f2);
        Fraction f3;
        f3.numerator = f1.numerator + f2.numerator;
        f3.denominator= f1.denominator;
        simplificationFraction(ref f3);
        return f3;
    }
    public Fraction Minus(Fraction f1, Fraction f2) // TODO
    {
        getCommonDenominator(ref f1, ref f2);
        Fraction f3;
        f3.numerator = f1.numerator - f2.numerator;
        f3.denominator = f1.denominator;
        simplificationFraction(ref f3);
        return f3;
    }
    public Fraction Multiplication(Fraction f1, Fraction f2) //TODO
    {
        Fraction f3;
        f3.denominator = f1.denominator * f2.denominator;
        f3.numerator = f1.numerator * f2.numerator;
        simplificationFraction(ref f3);
        return f3;
    }
    public Fraction Division(Fraction f1, Fraction f2) // TODO
    {
        f2.numerator ^= f2.denominator;
        f2.denominator ^= f2.numerator;
        f2.numerator ^= f2.denominator;
        Fraction f3 = Multiplication(f1, f2);
        simplificationFraction(ref f3);
        return f3;
    }
    public void getResultFraction(Fraction f1)
    {
        if (f1.numerator == 0)
            Console.WriteLine(" 0");
        else if (f1.denominator == 0)
            Console.WriteLine("Получается неправильная дробь, так как знаменатель результирующей дроби равен 0");
        else if (f1.numerator == 1 && f1.denominator == 1) Console.WriteLine(" 1");
        else Console.WriteLine($" {f1.numerator} / {f1.denominator}");
    }
}

