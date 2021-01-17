using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static int _score;
        private static int _health;
        private static int _levelAsteroids;
        private static Form _form;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image _background = Image.FromFile("Images\\background.jpg");
        private static Graphics _g;
        private static Star[] _stars;
        private static List<Asteroid> _asteroids;
        private static List<Bullet> _bullets;
        private static Ship _ship;
        private static FirstAidKit _kit;
        private static Timer _timer;
        public static Random r = new Random();
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static Image Background { get { return _background; } }
        static Game()
        {
        }
        public static Action<string> LogTo;
        public static void Init(Form form)
        {
            _form = form;
            _context = BufferedGraphicsManager.Current;
            _g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Generate_Objects;
            form.KeyDown += new KeyEventHandler(Form_KeyDown);
            Bullet.OverScreen += Bullet_OverScreen;
            Bullet.StrikeAsteroid += Bullet_StrikeAsteroid;
            LogTo += Log.LogToConsole;
            LogTo += Log.LogToFile;
            Load();
        }

        private static void Bullet_StrikeAsteroid(Bullet bullet)
        {
            foreach(Asteroid asteroid in _asteroids)
            {
                if (bullet.Collision(asteroid))
                {
                    LogTo.Invoke("Астероид сбит!");
                    _score++;
                    _bullets.Remove(bullet);
                    _asteroids.Remove(asteroid);
                    break;
                }
            }
        }

        private static void Bullet_OverScreen(Bullet obj)
        {
            _bullets.Remove(obj);
        }

        private static void Generate_Objects(object sender, EventArgs e)
        {
            Buffer.Dispose();
            Update();
            Draw();
        }

        public static void Load()
        {
            _score = 0;
            _health = 3;
            _levelAsteroids = 6;
            _stars = new Star[100];
            LogTo.Invoke("Звезды созданы");
            _asteroids = new List<Asteroid>();
            _bullets = new List<Bullet>();
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i] = new Star(new Point(r.Next(Width), r.Next(Height)), new Point(r.Next(-3, -1), 0), new Size(20, 20));
            }
            _ship = new Ship(new Point(0, Height / 2), new Point(0, 10), new Size(100, 40));
            _kit = new FirstAidKit(new Point(Width, r.Next(Height - 20)), new Point(0, 0), new Size(60, 40));
            GenerateAsteroids(_levelAsteroids);
            LogTo.Invoke("Корабль создан");
            _timer.Start();
        }

        private static void GenerateAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _asteroids.Add(new Asteroid(new Point(r.Next(Width / 2, Width), r.Next(30, Height - 30)), new Point(r.Next(-6, -3), 0), new Size(30, 40)));
                LogTo.Invoke($"Астериод номер {i} создан. Его скорость {_asteroids[i].Dir.X}");
            }
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Space)
            {
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 80, _ship.Rect.Y+20), new Point(20, 0), new Size(5, 3)));
                LogTo.Invoke("Выстрел!");
            }
        }
        public static void Draw()
        {
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            Game.Buffer.Graphics.DrawImage(_background, 0, 0);
            Buffer.Graphics.DrawString($"Cчет: {_score}", SystemFonts.MenuFont, Brushes.White, new Point(10, 10), StringFormat.GenericTypographic);
            Buffer.Graphics.DrawString($"Жизни: {_health}", SystemFonts.MenuFont, Brushes.White, new Point(100, 10), StringFormat.GenericTypographic);
            foreach (Star star in _stars)
            {
                star.Draw();
            }
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.Draw();
            }
            foreach (Bullet bullet in _bullets)
            {
                bullet?.Draw();
            }
            _ship.Draw();
            if (_score % 10 == 0) _kit.DirX = -3;
            _kit?.Draw();
            Buffer.Render();
            if (_health < 1)
            {
                _timer.Stop();
                MessageBox.Show($"Игра окончена!\nВаш счет: {_score}");
            }
        }

        public static void Update()
        {
            foreach (Star star in _stars)
            {
                star.Update();
            }
            if (_asteroids.Count == 0)
            {
                _levelAsteroids++;
                LogTo.Invoke($"Уровень повышен. Количество астериодов: {_levelAsteroids}");
                GenerateAsteroids(_levelAsteroids);
                _bullets.Clear();
            }
            foreach (Asteroid asteroid in _asteroids.ToArray())
            {
                if (_ship.Collision(asteroid))
                {
                    LogTo.Invoke("Корабль врезался в астероид");
                    _health--;
                    _asteroids.Remove(asteroid);
                    break;
                }
                asteroid.Update();
            }
            foreach (Bullet bullet in _bullets.ToArray())
            {
                bullet.Update();
                if (bullet.Collision(_kit))
                {
                    _kit.RestartPos();
                    _bullets.Remove(bullet);
                    _health++;
                    break;
                }
            }
            if (_kit.Collision(_ship))
            {
                _kit.RestartPos();
                _health--;
            }
            _kit?.Update();
            _ship.Update();
        }
    }
}
