using System;
using System.Text;
using System.Linq;
class Thirth_Quest
{
    public bool CompareWithMethod(string a, string b)
    {
        a = string.Concat(a.OrderBy(x => x).ToArray());
        b = string.Concat(b.OrderBy(x => x).ToArray());
        return a.SequenceEqual(b);
    }
    private bool CompareWithoutMethod(string a, string b) 
    {
        string A = a.ToLower();
        string B = b.ToLower();
        if (A.Length == B.Length)
        {
            while(A.Length>0)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[0] == B[j])
                    {
                        B = B.Remove(j, 1);
                    }
                }
                A = A.Remove(0, 1);
            }
            return B.Length==0;
        }
        else return false;
    }
    public void Main()
    {
        //    3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.Регистр можно не учитывать:
        //          а) с использованием методов C#;
        //          б) *разработав собственный алгоритм.
        //          Например:
        //              badc являются перестановкой abcd.
        Console.WriteLine("Программа, которая сверит две строки и является ли одна строка перестановкой другой.");
        View view = new View();
        string a = view.getString("Введите первую строку:");
        string b = view.getString("Введите вторую строку:");
        int UserChoice = view.getInt("Введите вариант, с помощью которого будут проверяться строки:\n1 - С использованием методов c#\n2 - С собственным алгоритмом\n0 - Для выхода:");
        bool checkCompare = false;
        switch (UserChoice)
        {
            case 1:
                checkCompare = CompareWithMethod(a, b);
                break;
            case 2:
                checkCompare = CompareWithoutMethod(a,b);
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Нет такого варианта.");
                UserChoice = view.getInt("Введите вариант, с помощью которого будут проверяться строки:\n1 - С использованием методов c#\n2 - С собственным алгоритмом:");
                break;
        }
        Console.WriteLine("Строка {0} {1}является перестановкой {2}", a, checkCompare ? "" : "не ", b);
        view.Pause();
    }
}

