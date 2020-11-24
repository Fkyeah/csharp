using System;
using System.Text;
using System.IO;
class View
{
    public int getInt(string str)
    {
        int number;
        bool success = true;
        do
        {
            if (!success) Console.WriteLine("Ошибка. Введите числовое значение.");
            Console.WriteLine(str);
            success = Int32.TryParse(Console.ReadLine(), out number);
        }
        while (!success);
        return number;
    }
    public string getString(string str)
    {
        Console.WriteLine(str);
        return Console.ReadLine();
    }
    public char getChar(string str)
    {
        Console.WriteLine(str);
        return Convert.ToChar(Console.ReadLine());
    }
    public void Pause()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }
    public void FileWriter(string path, string message)
    {
        StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
        sw.WriteLine(message);
        sw.Close();
    }
    public string FileReader(string path)
    {
        string message = ""; ;
        StreamReader text = new StreamReader(path);
        while (!text.EndOfStream)
        {
            message += text.ReadLine();  
        }
        text.Close();
        return message;
    }
}
