using System;

class Index
{
    double height;
    public double getIdx(int w, int h)
    {
        height = (float)h / 100;
        return w / Math.Pow(height, 2);
    }
    public void getRecomendation(double userIdx)
    {
        double minLimit = 18.50;
        double maxLimit = 24.99;
        double i;
        double _userIdx = Math.Round(userIdx,2);
        Console.WriteLine($"Диапазон нормы массы тела: {minLimit} - {maxLimit}");
        if (_userIdx > maxLimit)
        {
            i = (_userIdx - maxLimit) * Math.Pow(height, 2);
            Console.WriteLine($"Ваш индекс довольно высок. Вам необходимо похудеть на {i:0.00} кг");
        }
        else if (_userIdx < minLimit)
        {
            i = (minLimit - _userIdx) * Math.Pow(height, 2);
            Console.WriteLine($"Ваш индекс слишком низок. Для достижения нормы индекса массы тела вам необходимо добрать {i:0.00} кг");
        }
        else Console.WriteLine("Индекс массы Вашего тела находится в пределах нормы");
    }
}

