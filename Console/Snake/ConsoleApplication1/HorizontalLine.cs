using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int x, int yUp, int yDown, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++ )
            {
                Point p = new Point(x,y,sym);
                pList.Add(p);
            }
        }
    }
}
