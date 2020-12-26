using System;
using System.Windows.Forms;

namespace Asteroids
{


    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Height = 769;
            form.Width = 1024;
            Game.Init(form);
            Application.Run(form);
        }
    }
}
