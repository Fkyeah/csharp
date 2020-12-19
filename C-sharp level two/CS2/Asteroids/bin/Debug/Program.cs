using System;
using System.Windows.Forms;

namespace Asteroids
{


    class Program
    {
        static void Main(string[] args)
        {
            Form1 form = new Form1();
            MainMenu.Load(form);
            Application.Run(form);
        }
    }
}
