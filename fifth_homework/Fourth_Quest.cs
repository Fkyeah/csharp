using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class Fourth_Quest
{
    View view = new View();
    private string[] _students;
    private int _numberOfStudents { get; set; }
    private string[] Students
    {
        get
        {
            return _students;
        }
        set
        {
            _students = value;
        }
    }
    private void SetArrayStudents(string str)
    {
        Console.WriteLine(str);
        string[] ArrayOfStudents = { };
        string stringRegexMask = @"^[а-яА-Я]{0,}$";
        Regex StringRegex = new Regex(stringRegexMask);
        string intRegexMask = @"^[1-5]{1}$";
        Regex intRegex = new Regex(intRegexMask);
        ArrayOfStudents = new string[_numberOfStudents];
        for (int i = 0; i < ArrayOfStudents.Length; i++)
        {
            try
            {
                ArrayOfStudents[i] = view.getString("Введите данные ученика:");
                string[] tempArrayOfStudents = ArrayOfStudents[i].Split(' ');
                if (tempArrayOfStudents.Length < 5)
                {
                    throw new Exception("Неверный формат ввода данных. Данные передаются в формате: Иванов Иван 3 4 5");
                }
                else if (StringRegex.IsMatch(tempArrayOfStudents[0]) == false || StringRegex.IsMatch(tempArrayOfStudents[1]) == false)
                {
                    throw new Exception("Неверный формат ввода имени и фамилии. Они могут содержаться буквы от а до я в верхнем и нижнем регистре");
                }
                else if (intRegex.IsMatch(tempArrayOfStudents[2])== false || intRegex.IsMatch(tempArrayOfStudents[3]) == false || intRegex.IsMatch(tempArrayOfStudents[4]) == false)
                {
                    throw new Exception("Неверный формат ввода оценки. Оценка может быть от 1 до 5");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка:\n{e}\nПопробуйте повторить ввод.");
                i--;
            }
        }
        this.Students = ArrayOfStudents;
    }
    private void GetAverageRating()
    {
        double AverageRating = 0;
        string[] ArrayOfStudent;
        for (int i = 0; i < Students.Length; i++)
        {
            ArrayOfStudent = Students[i].Split(' ');
            for (int j = 1; j <= 3; j++)
            {
                AverageRating += Convert.ToInt32(ArrayOfStudent[ArrayOfStudent.Length - j]);
            }
            AverageRating /= 3;
            Students[i] += $" {AverageRating:0.0}";
            Console.WriteLine(Students[i]);
            AverageRating = 0;
        }
    }
    private string[][] SplitArrayOfStudents()
    {
        string[][] tempArray = new string[Students.Length][];
        for(int i = 0; i < Students.Length; i++)
        {
            tempArray[i] = Students[i].Split(' ');
        }
        return tempArray;
    }
    private void GetWorstStudents(string[][] ArrayOfStudents)
    {
        ArrayOfStudents = (from j in ArrayOfStudents orderby j.Last() select j).ToArray();
        for (int i = 0; i < ArrayOfStudents.Length; i++)
        {
            if ((i >= 3 && ArrayOfStudents[i].Last() == ArrayOfStudents[i - 1].Last()) || i < 3)
            {
                for (int j = 0; j < ArrayOfStudents[i].Length; j++)
                {
                    Console.Write($"{ArrayOfStudents[i][j]} ");
                }
            }
            else break;
            Console.WriteLine(); 
        }
    }
    public void Main()
    {
        _numberOfStudents = 0;
        do
        {
            if (_numberOfStudents < 10 || _numberOfStudents > 100) Console.WriteLine("Количество учеников должно быть не меньше 10 и не больше 100");
            _numberOfStudents = view.getInt("Введите количество учеников:");
        } while (_numberOfStudents < 10 || _numberOfStudents > 100);
        SetArrayStudents("Введите данные по ученикам в формате: Фамилия Имя три оценки через пробел.");
        Console.WriteLine("\nСписок учеников со средними оценками:");
        GetAverageRating();
        string[][] SplitStudents = SplitArrayOfStudents();
        Console.WriteLine("\nСписок трех или более худших учеников:");
        GetWorstStudents(SplitStudents);
        view.Pause();
    }
}

