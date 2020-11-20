using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Fifth_Quest
{
    View view = new View();
    List<string[]> _questAndAnswer = new List<string[]>();
    string path = "Game.txt";
    private void ReadFile()
    {
        StreamReader text = new StreamReader(path);
        while (!text.EndOfStream)
        {
            _questAndAnswer.Add(text.ReadLine().Split(' '));
        }
        text.Close();
    }
    private bool CheckAnswer(int numberQuestion, string userAnswer)
    {
        return _questAndAnswer[numberQuestion][_questAndAnswer[numberQuestion].Length - 1].ToLower() == userAnswer;
    }
    private string UserAnswer()
    {
        string userAnswer = "";
        while (userAnswer != "да" && userAnswer != "нет")
        {
            Console.WriteLine("\nВаш ответ:");
            userAnswer = Console.ReadLine().ToLower();
            if (userAnswer != "да" && userAnswer != "нет") Console.WriteLine($"Неверный формат ввода ответа. Введите - да или нет:") ;
        }
        return userAnswer;
    }

    private int Game()
    {
        int countQuestion = 5;
        Random r = new Random();
        int countTrueAnswers = 0;
        for (int i = 0; i < countQuestion; i++)
        {
            int numberQuestion = r.Next(_questAndAnswer.Count);
            for (int j = 0; j < _questAndAnswer[numberQuestion].Length - 1; j++)
            {
                Console.Write($"{_questAndAnswer[numberQuestion][j]} ");
            }
            if (CheckAnswer(numberQuestion, UserAnswer()))
            {
                Console.WriteLine("Верно!");
                countTrueAnswers++;
            }
            else Console.WriteLine("Неверно!");
            _questAndAnswer.Remove(_questAndAnswer[numberQuestion]);
            Console.WriteLine();
        }
        return countTrueAnswers;
    }

    /* 5. **Написать игру «Верю. Не верю». 
     * В файле хранятся вопрос и ответ, правда это или нет. 
     * Например: «Шариковую ручку изобрели в древнем Египте», «Да». 
     * Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
     * Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. 
     * Список вопросов ищите во вложении или воспользуйтесь интернетом.*/
    public void Main()
    {
        Console.WriteLine("Игра: Верю. Не верю.\nКомпьютер задаем вам вопрос, вы отвечаете: да или нет\nВ конце компьютер выведет количество правильных ответов");
        view.Pause();
        ReadFile();
        int result = Game();
        Console.WriteLine($"Игра окончена. Поздравляю!\nКоличество правильных ответов: {result}");
        Console.ReadKey();
    }
}

