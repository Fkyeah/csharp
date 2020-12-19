using System;
using System.Windows.Forms;

namespace Asteroids
{


    class Program
    {
        static void Main(string[] args)
        {
            Form1 form = new Form1();
            // если Height > 768 или Height == 0 сработает исключение
            form.Height = 769;
            // если задать Width > 1024 или Width < 0 сработает исключение
            form.Width = 1024;
            MainMenu.Load(form);
            Application.Run(form);
        }
    }
}
