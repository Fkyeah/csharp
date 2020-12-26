using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class MainMenu
    {
        private static BaseText _university;
        private static Name _name;
        private static SurName _surName;
        public static BufferedGraphics Buffer;
        private static BufferedGraphicsContext _context;
        private static Graphics _g;
        private static Timer _timer;
        private static BaseText[] _text;
        public static int Width { get; private set; }
        public static int Height { get; private set; }


        public static void Load(Form form)
        {
            _context = BufferedGraphicsManager.Current;
            _g = form.CreateGraphics();
            try
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                // 4. Сделать проверку на задание размера экрана в классе Game. 
                // Если высота больше 1024 или ширина больше 768 (Width, Height) или принимают отрицательное значение, выбросить исключение
                if (Width > 1024 || Width < 0) throw new ArgumentOutOfRangeException("Ширина игрового окна не может быть больше 1024 или отрицательным");
                else if (Height > 768 || Height == 0) throw new ArgumentOutOfRangeException("Ширина игрового окна не может быть больше 768 или отрицательным");
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show($"{e.Message}");
                Environment.Exit(0);
            }
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            _university = new BaseText("GeekBrains",new Point(MainMenu.Width / 2 - 15, 0), new Point(0,10), new Size(40,40));
            _name = new Name("Дмитрий",new Point(0, MainMenu.Height / 2), new Point(10, 0), new Size(20, 20));
            _surName = new SurName("Тихонов", new Point(Width, Height / 2), new Point(-10, 0), new Size(20, 20));
            _text = new BaseText[3] { _name, _surName, _university };
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
                text.WriteText();
            }
            Buffer.Render();
            Buffer.Dispose();
        }

        private static void MoveText(object sender, EventArgs e)
        {
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            Buffer.Graphics.DrawImage(Game.Background, 0, 0);
            Draw();
        }
    }
}
