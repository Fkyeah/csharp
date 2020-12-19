using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
class Student
{
    /* 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
         а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
         б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(частотный массив);
         в) отсортировать список по возрасту студента;
         г) *отсортировать список по курсу и возрасту студента;
         д) разработать единый метод подсчета количества студентов по различным параметрам
            выбора с помощью делегата и методов предикатов. */
    private string _firstName { get; set; }
    private string _secondName { get; set; }
    private string _univercity { get; set; }
    private string _faculty { get; set; }
    private int _age { get; set; }
    private int _course { get; set; }
    private string _group { get; set; }
    private string _city { get; set; }
    public override string ToString()
    {
        return string.Format($"{_firstName} {_secondName}. Университет - {_univercity}. Возраст - {_age}. Курс - {_course}. Группа - {_group}. Город - {_city}");
    }
    private List<Student> CreateListOfStudents(string filename)
    {
        StreamReader sr = new StreamReader(filename, Encoding.UTF8);
        List<Student> list = new List<Student>();

        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                list.Add(new Student() { _firstName = s[0], _secondName = s[1], _univercity = s[2], _faculty = s[3], _age = int.Parse(s[4]), _course = int.Parse(s[5]), _group = s[6], _city = s[7] });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        sr.Close();
        return list;
    }
    private int CountStudentsOfCourse(List<Student> list, int course) // задание а)
    {
        int count = 0;
        foreach (Student s in list)
        {
            if (s._course == course) count++;
        }
        return count;
    }
    private List<int[]> GetFrequencyArrayOfAge(List<Student> list, int minValue, int maxValue) // задание б)
    {
        List<int[]> result = new List<int[]>();
        for(int currValue = minValue; currValue <= maxValue; currValue++)
        {
            int[] arr = new int[2];
            int countAge = 0;
            arr[0] = currValue;
            foreach(Student s in list)
            {
                if (s._age == currValue) countAge++;
            }
            arr[1] = countAge;
            result.Add(arr);
        }
        return result;
    }
    private List<Student> ListStudents { get; set; }
    private string _userAnswer { get; set; }
    private int CountStudents(Predicate<Student> predicate) // задание д) 
    {
        int count = 0;
        foreach (Student s in ListStudents)
        {
            if (predicate(s))
            {
                count++;
            }
        }
        return count;
    }
    private bool InUnivercity(Student s)
    {
        return s._univercity.ToLower() == _userAnswer.ToLower();
    }
    private bool InGroup(Student s)
    {
        return s._group.ToLower() == _userAnswer.ToLower();
    }
    private bool InCity(Student s)
    {
        return s._city.ToLower() == _userAnswer.ToLower();
    }
    private List<Student> SortList(List<Student> list) // задания в) и г)
    {
        return list.OrderBy(x => x._age).ThenBy(x => x._course).ToList();
    }
    private void PrintList<T>(string message, IEnumerable<T> list)
    {
        Console.WriteLine(message);
        foreach (var s in list)
        {
            Console.WriteLine(s.ToString());
        }
    }
    public void Main()
    {
        View view = new View();
        int numOfBachelors = 0;
        int numOfMasters = 0;
        ListStudents = CreateListOfStudents("students.txt");
        DateTime dt = DateTime.Now;
        foreach (Student s in ListStudents)
        {
            if (s._course < 5) numOfBachelors++;
            else numOfMasters++;
            Console.WriteLine(s.ToString());
        }
        Console.WriteLine($"Всего студентов:{ListStudents.Count} Магистров:{numOfMasters} Бакалавров:{numOfBachelors}");
        view.Pause();
        Console.WriteLine($"Количество студентов на пятом курсе = {CountStudentsOfCourse(ListStudents, 5)}, на шестом курсе - {CountStudentsOfCourse(ListStudents, 6)}");
        Console.WriteLine(DateTime.Now - dt);
        view.Pause();
        List<int[]> ageCounter = GetFrequencyArrayOfAge(ListStudents, 22, 24);
        Console.WriteLine("Частотный массив студентов в диапазоне от 22 до 24 лет");
        foreach (int[] arr in ageCounter)
        {
            Console.WriteLine($"Возраст - {arr[0]}. Количество студентов - {arr[1]}");
        }
        view.Pause();
        PrintList("Отсортированный список студентов по возрасту и по курсу:", SortList(ListStudents));
        view.Pause();
        int userChoice = view.getInt("Через методы предикатов возможен подсчет студентов по разным параметрам\n1 - По университетам\n2 - По группам\n3 - По городам.\nВыберите вариант:");
        switch(userChoice)
        {
            case 1:
                _userAnswer = view.getString("Введите университет, в котором хотите посчитать количество студентов:");
                Console.WriteLine($"Студентов из города {_userAnswer}: {CountStudents(InUnivercity)}");
                break;
            case 2:
                _userAnswer = view.getString("Введите группу, в которой хотите посчитать количество студентов:");
                Console.WriteLine($"Студентов в группе {_userAnswer}: {CountStudents(InGroup)}");
                break;
            case 3:
                _userAnswer = view.getString("Введите город, из которого хотите посчитать количество студентов:");
                Console.WriteLine($"Студентов из города {_userAnswer}: {CountStudents(InCity)}");
                break;
            default:
                Console.WriteLine("Нет такого варианта");
                break;
        }
        view.Pause();
    }
}



