using System;


struct Complex
{
    public double im;
    public double re;
    public Complex Plus(Complex x)
    {
        Complex y;
        y.im = im + x.im;
        y.re = re + x.re;
        return y;
    }
    public Complex Multi(Complex x)
    {
        Complex y;
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }
    public string ToString()
    {
        if (im < 0) return re + "" + im + "i";
        else if (im == 0) return re + "";
        else if (re == 0) return im + "i";
        else return re + "+" + im + "i";
    }
    public Complex Minus(Complex x)
    {
        Complex y;
        y.im = im - x.im;
        y.re = re - x.re;
        return y;
    } 
}
struct Fraction
{
    public int numerator;
    public int denominator;
}
class Program
{
    static void Main(string[] args)
    {
        /* Первое задание. Пункт А */
        View view = new View();
        Complex complex1;
        complex1.re = view.getInt("Введите действительную часть первого числа");
        complex1.im = view.getInt("Введите мнимую часть первого числа");
        Complex complex2;
        complex2.re = view.getInt("Введите действительную часть второго числа"); ;
        complex2.im = view.getInt("Введите мнимую часть второго числа"); ;
        Complex result = complex1.Plus(complex2);
        Console.WriteLine($"Результат сложения двух комплексных чисел {complex1.ToString()} и {complex2.ToString()} равен: {result.ToString()}");
        result = complex1.Multi(complex2);
        Console.WriteLine($"Результат умножения двух комплексных чисел {complex1.ToString()} и {complex2.ToString()} равен: {result.ToString()}");
        result = complex1.Minus(complex2);
        Console.WriteLine($"Результат вычитания комплексного числа {complex2.ToString()} из {complex1.ToString()} равен: {result.ToString()}");
        view.Pause();
        /* Первое задание. Пункт Б */
        ComplexNumbers cNumbers = new ComplexNumbers();
        Console.Write("Первое комплексное число: ");
        cNumbers.getResult(complex1);
        Console.Write("Второе комплексное число: ");
        cNumbers.getResult(complex2);
        Console.Write("Результат сложения этих двух чисел: ");
        cNumbers.getResult(cNumbers.ComplexNumbersPlus(complex1, complex2));
        Console.Write("Результат умножения этих двух чисел равен: ");
        cNumbers.getResult(cNumbers.ComplexNumbersMulti(complex1, complex2));
        Console.Write("Результат вычитания этих двух чисел равен: ");
        cNumbers.getResult(cNumbers.ComplexNumbersMinus(complex1, complex2));
        view.Pause();
        /* Второе задание. Пункт А*/
        Console.WriteLine("Программа посчитает сумму положительных нечетных чисел. Последовательно вводите числа, числа принимаются, пока не будет введен 0");
        OddNumbers oddNumbers = new OddNumbers();
        /* функция второго задания пункта Б хранится в классе View */
        int sum = oddNumbers.getSum(view);
        Console.WriteLine($"Сумма положительных нечетных чисел равна {sum}");
        view.Pause();
        /* Третье задание */
        Console.WriteLine("Программа будет производить разные арифметические действия с дробями.");
        Fraction fraction1;
        fraction1.numerator = view.getInt("Введите числитель первой дроби:");
        // Исключение выбрасывается, если ввести в знаменатель 0. Функция реализована в классе View методе getDenominator
        fraction1.denominator = view.getDenominator("Введите знаменатель первой дроби:");
        Fraction fraction2;
        fraction2.numerator = view.getInt("Введите числитель второй дроби:");
        fraction2.denominator = view.getDenominator("Введите знаменатель второй дроби:");
        Fractions fractions = new Fractions();
        fractions.simplificationFraction(ref fraction1);
        Console.WriteLine($"Упрощенная первая дробь : {fraction1.numerator} / {fraction1.denominator}");
        fractions.simplificationFraction(ref fraction2);
        Console.WriteLine($"Упрощенная вторая дробь : {fraction2.numerator} / {fraction2.denominator}");
        Fraction resultFraction = fractions.Plus(fraction1, fraction2);
        Console.Write($"Результат сложения дробей  :");
        fractions.getResultFraction(resultFraction);
        resultFraction = fractions.Minus(fraction1, fraction2);
        Console.Write($"Результат вычитания дробей  :");
        fractions.getResultFraction(resultFraction);
        resultFraction = fractions.Multiplication(fraction1, fraction2);
        Console.Write($"\nРезультат умножения дробей  :");
        fractions.getResultFraction(resultFraction);
        resultFraction = fractions.Division(fraction1, fraction2);
        Console.Write($"\nРезультат деления дробей  :");
        fractions.getResultFraction(resultFraction);
        Console.ReadKey();
    }
}


