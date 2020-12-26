using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Base[] workers = new Base[5];
            workers[0] = new Hourly(200, "Ivan");
            workers[1] = new Monthly(30000, "Alexandr");
            workers[2] = new Hourly(350, "Dmitry");
            workers[3] = new Monthly(40000, "Nikita");
            workers[4] = new Hourly(250, "Vladimir");
            Array.Sort(workers);
            foreach (Base w in workers)
            {
                Console.WriteLine(w.ToString());
            }

            Console.ReadKey();
        }
    }
}
