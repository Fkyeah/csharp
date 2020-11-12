using System;

class GetMin
{
    public int getValue (int a, int b, int c)
    {
        int min = a;
        if (min > b && b < c) min = b;
        else if (min > c && c < b) min = c;
        return min;
    }
}

