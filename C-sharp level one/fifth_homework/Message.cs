using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class Message
{
    private string _newMessage;
    private string[] _tempMessage;
    private void SplitString(string UserMessage)
    {
        char[] separator = { '.', '?', ',', '!', ' ' };
        this._tempMessage = UserMessage.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    }

    public void RemoveMessage(int n)
    {
        for (int j = 0; j < _tempMessage.Length; j++)
        {
            if (_tempMessage[j].Length <= n)
                _newMessage +=  $"{_tempMessage[j]} ";
        }
    }
    private void CheckLastLetter(char letter)
    {
        _newMessage = "";
        string regexMask = @"^[\w\.\S\s\W]{0,}["+letter+"]$";
        Regex regex = new Regex(regexMask);
        for (int i = 0; i < _tempMessage.Length; i++)
        {
            if (regex.IsMatch(_tempMessage[i]) == false)
            {
                _newMessage += $"{_tempMessage[i]} ";
            }
        }
    }
    private string MaxLengthWord()
    {
        _newMessage = "";
        int max = _tempMessage[0].Length;
        for (int i = 0; i < _tempMessage.Length; i++)
        {
            if (_tempMessage[i].Length >= max) max = _tempMessage[i].Length;
        }
        for (int j = 0; j < _tempMessage.Length; j++)
        {
            if (_tempMessage[j].Length == max) _newMessage += $"{_tempMessage[j]} ";
        }
        return _newMessage;
    }
    private void StringBuilderMessage()
    {
        StringBuilder builder = new StringBuilder();
        int max = _tempMessage[0].Length;
        for (int i = 0; i < _tempMessage.Length; i++)
        {
            if (_tempMessage[i].Length >= max) max = _tempMessage[i].Length;
        }
        for (int j = 0; j < _tempMessage.Length; j++)
        {
            if (_tempMessage[j].Length == max) builder.Append($"{_tempMessage[j]} ");
        }
        Console.WriteLine(builder);
    }
    public void Main()
    {
        Console.WriteLine("Программа по работе со строками.\n");
        View view = new View();
        Console.WriteLine("Введите сообщение и число букв. Программа выведет только те слова сообщения, которые содержат не более n букв.");
        string UserMessage = view.getString("Введите сообщение:");
        view.FileWriter("Message.txt", UserMessage);
        int maxLetters = view.getInt("Введите число букв: ");
        SplitString(UserMessage);
        RemoveMessage(maxLetters);
        Console.WriteLine($"Получившаяся строка: {_newMessage}");
        view.FileWriter("Result_message_after_RemoveMessage.txt", _newMessage);
        Console.WriteLine($"Строка из файла: {view.FileReader("Result_message_after_RemoveMessage.txt")}");
        char letter = view.getChar("Введите букву. Программа уберет из вашего первого сообщения все слова, которые будут заканчиваться на эту букву.");
        CheckLastLetter(letter);
        Console.WriteLine($"Получившаяся строка: {_newMessage}");
        view.FileWriter("Result_message_after_CheckLastLetter.txt", _newMessage);
        Console.WriteLine($"Строка из файла: {view.FileReader("Result_message_after_CheckLastLetter.txt")}");
        Console.WriteLine($"Самые длинные слова в вашем сообщении: {MaxLengthWord()}");
        Console.WriteLine("Строка, которая получилась из самых длинных слов вашего сообщения:");
        StringBuilderMessage();
        view.Pause();
    }
}
