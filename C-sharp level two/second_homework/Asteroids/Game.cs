using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    // 5. Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками
    class GameObjectException : Exception
    {
        public GameObjectException()
        {
            Console.WriteLine(base.Message);
        }
        public GameObjectException(string value)
        {
            Console.WriteLine(value);
        }
    }
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image _background = Image.FromFile("Images\\background.jpg");
        private static Graphics _g;
        private static Star[] _stars;
        private static Asteroid[] _asteroids;
        private static Bullet _bullet;
        private static Timer _timer;
        public static Random r = new Random();
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static Image Background { get { return _background; } }

        static Game()
        {
        }
        public static void Init(Form form)
        {
            _context = BufferedGraphicsManager.Current;
            _g = form.CreateGraphics();
            try
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
                if (Width < 1000 || Width < 0) throw new ArgumentOutOfRangeException("Ширина игрового окна не может быть больше 1024");
                else if (Height > 768 || Height < 0) throw new ArgumentOutOfRangeException("Ширина игрового окна не может быть больше 768");
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(0);
            }
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Generate_Objects;
            Load();
        }

        private static void Generate_Objects(object sender, EventArgs e)
        {
            Buffer.Dispose();
            Update();
            Draw();
        }

        public static void Load()
        {
            _stars = new Star[100];
            _asteroids = new Asteroid[6];
            try
            {
                for (int i = 0; i < _stars.Length; i++)
                {
                    _stars[i] = new Star(new Point(r.Next(Width), r.Next(Height)), new Point(r.Next(-3, -1), 0), new Size(20, 20));
                }
                for (int i = 0; i < _asteroids.Length; i++)
                {
                    _asteroids[i] = new Asteroid(new Point(r.Next(Width), r.Next(Height - 10)), new Point(r.Next(-6, -3), 0), new Size(30, 40));
                    // ниже генерация астероида для срабатывания исключения на слишком большую скорость
                    //_asteroids[i] = new Asteroid(new Point(r.Next(Width), r.Next(Height - 10)), new Point(r.Next(-10, -3), 0), new Size(30, 40));
                    if (_asteroids[i].Dir.X < -7) throw new GameObjectException("Задана слишком большая скорость для астероида!");
                }
                _bullet = new Bullet(new Point(0, Game.Height / 2), new Point(3, 0), new Size(20, 20));

            }
            catch (GameObjectException e)
            {
                Console.WriteLine(e.Message);
            }
            _timer.Start();
        }

        public static void Draw()
        {
            try
            {
                Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
                Game.Buffer.Graphics.DrawImage(_background, 0, 0);
                foreach (Star star in _stars)
                {
                    star.Draw();
                }
                foreach (Asteroid asteroid in _asteroids)
                {
                    asteroid.Draw();
                }
                _bullet.Draw();
                Buffer.Render();
            }
            catch
            {
                Environment.Exit(0);
            }
            
        }

        public static void Update()
        {
            foreach(Star star in _stars)
            {
                star.Update();                
            }
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid is Asteroid && asteroid.Collision(_bullet))
                {
                    Console.WriteLine("Clash!");
                    asteroid.RestartPos();
                    _bullet.RestartPos();
                }
                _bullet.Update();
            }
        }
    }
}
