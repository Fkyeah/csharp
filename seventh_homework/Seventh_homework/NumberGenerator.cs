using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_homework_first_quest
{
    class NumberGenerator
    {
        public int Result { get; private set; }
        public NumberGenerator(int x)
        {
            Random r = new Random();
            Result = r.Next(x);
        }
    }
}
