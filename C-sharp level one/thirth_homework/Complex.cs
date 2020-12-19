using System;

class ComplexNumbers
{
    public Complex ComplexNumbersPlus(Complex x, Complex z)
    {
        Complex y;
        y.im = z.im + x.im;
        y.re = z.re + x.re;
        return y;
    }
    public Complex ComplexNumbersMulti(Complex x, Complex z)
    {
        Complex y;
        y.im = z.re * x.im + z.im * x.re;
        y.re = z.re * x.re - z.im * x.im;
        return y;
    }
    public void ComplexToString(Complex x)
    {
        Console.WriteLine($"{x.re} + {x.im}i");
    }
    public Complex ComplexNumbersMinus(Complex x, Complex z)
    {
        Complex y;
        y.im = x.im - z.im;
        y.re = x.re - z.re;
        return y;
    }
    public void getResult(Complex x)
    {
        if (x.im < 0) Console.WriteLine($"{x.re} {x.im}i"); // re + "" + im + "i";
        else if (x.im == 0) Console.WriteLine($"{x.re}"); // re + "";
        else if (x.re == 0) Console.WriteLine($"{x.im}i"); // im + "i";
        else Console.WriteLine($"{x.re} + {x.im}i"); // re + "+" + im + "i";
    }
}

