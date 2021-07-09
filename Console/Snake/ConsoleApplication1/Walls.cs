using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Walls : Figure
    {
        List<Figure> wallList;
        public Walls(int lenght, int weight)
        {
            wallList = new List<Figure>();
            HorizontalLine LeftLine = new HorizontalLine(2, 0, weight - 1, '+');
            HorizontalLine RightLine = new HorizontalLine(lenght - 2, 0, weight - 1, '+');
            VerticalLine UpLine = new VerticalLine(2, lenght - 2, 0, '+');
            VerticalLine DownLine = new VerticalLine(2, lenght - 2, weight - 1, '+');
            wallList.Add(LeftLine);
            wallList.Add(RightLine);
            wallList.Add(UpLine);
            wallList.Add(DownLine);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
        internal bool HitinWall(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

    }
}

