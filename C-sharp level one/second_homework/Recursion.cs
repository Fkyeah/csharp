using System;
class Recursion
{
    int sum = 0;
    public void getSequence(int a, int b)
    {
        Console.Write($"{a} ");
        if (a < b) getSequence(a+1, b);
    }
    public int SequenceSum(int a, int b)
    {
        sum += a;
        return (a == b) ? sum : SequenceSum(a + 1, b);
    }
}


