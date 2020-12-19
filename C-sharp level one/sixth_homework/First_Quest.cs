using System;
public delegate double Fun(double x, double a);

class First_Quest
{
    /* . Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
     * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x). */
    // Создаем метод, который принимает делегат
    // На практике этот метод сможет принимать любой метод
    // с такой же сигнатурой, как у делегата
    public void Table(Fun F, double x, double b, double a)
    {
        Console.WriteLine("------ A ------ X ------ Y -----");
        while (x <= b && a <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(x,a));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    private double MyFunc(double x, double a)
    {
        return a * x * x;
    }
    private double MySin(double x, double a)
    {
        return a * Math.Sin(x);
    }


    public void Main()
    {
        Console.WriteLine("Таблица функции MyFunc:");
        Table(new Fun(MyFunc), -2, 2, 2);
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        Table(MyFunc, -2, 2, 2);
        Console.WriteLine("Таблица функции Sin:");
        Table(new Fun(MySin), -2, 2, 2);     
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        Table(MySin, -2, 2, 2);
        Console.WriteLine("Еще раз через анонимный метод");
        Table(delegate (double x, double a) { return a * Math.Sin(x); }, 0, 3, 2);
        Console.WriteLine("Таблица функции a*x^2:");
        Table(new Fun(MyFunc), -2, 2, 2);
        Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
        Table(MyFunc, -2, 2, 2);
        Console.WriteLine("Еще раз через анонимный метод");
        Table(delegate (double x, double a) { return a * x * x; }, 0, 3, 2);
        
        Console.ReadKey();
    }

}

