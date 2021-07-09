using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class FoodCreator
    {
        int MapX;
        int MapY;
        char sym;
        Random random = new Random();
        public FoodCreator(int MapX, int MapY, char SYM)
        {
            this.MapX = MapX;
            this.MapY = MapY;
            this.sym = SYM;
        }

       
        public Point CreateFood()
        {
            int x = random.Next(3, MapX - 3);
            int y = random.Next(2, MapY - 3);
            return new Point(x, y, sym);
        }
        
    }
}
