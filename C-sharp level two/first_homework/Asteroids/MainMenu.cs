using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class MainMenu
    {
        static BaseText university;
        static Name name;
        static SurName surName;
        public static BufferedGraphics Buffer;
        private static BufferedGraphicsContext _context;
        private static Graphics g;
        private static Timer _timer;
        private static BaseText[] _text;
        public static int Width { get; private set; }
        public static int Height { get; private set; }


        public static void Load(Form form)
        {
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            university = new BaseText("GeekBrains",new Point(MainMenu.Width / 2 - 15, 0), new Point(0,10), new Size(40,40));
            name = new Name("Дмитрий",new Point(0, MainMenu.Height / 2), new Point(10, 0), new Size(20, 20));
            surName = new SurName("Тихонов", new Point(Width, Height / 2), new Point(-10, 0), new Size(20, 20));
            _text = new BaseText[3] { name, surName, university };
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += MoveText;
            _timer.Start();
        }
        private static void Draw()
        { 
            foreach (var text in _text)
            {
                text.UpdatePos();
                text.Move();
            }
            Buffer.Render();
            Buffer.Dispose();
        }

        private static void MoveText(object sender, EventArgs e)
        {
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Buffer.Graphics.DrawImage(Game.Background, 0, 0);
            Draw();
        }
    }
}
