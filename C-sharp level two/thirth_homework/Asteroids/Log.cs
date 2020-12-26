using System;
using System.IO;

namespace Asteroids
{
    class Log
    {
        static FileStream fs = new FileStream($"logs{DateTime.Today.ToString("d")}.txt", FileMode.OpenOrCreate, FileAccess.Write);
        static StreamWriter sw = new StreamWriter(fs);
        public static void LogToConsole(string message)
        {
            Console.WriteLine($"Время: {DateTime.Now} Событие: {message}");
        }
        public static void LogToFile(string message)
        {
            sw.WriteLine($"Время: {DateTime.Now} Событие: {message}");
        }
    }
}
