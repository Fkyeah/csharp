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
        private static Form _form;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image _background = Image.FromFile("Images\\background.jpg");
        private static Graphics _g;
        private static Star[] _stars;
        private static Asteroid[] _asteroids;
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
                LogTo.Invoke(e.Message);
                Environment.Exit(0);
            }
            Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Generate_Objects;
            form.KeyDown += new KeyEventHandler(Form_KeyDown);
            Bullet.OverScreen += Bullet_OverScreen;
            LogTo += Log.LogToConsole;
            LogTo += Log.LogToFile;
            Load();
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
            _stars = new Star[100];
            LogTo.Invoke("Звезды созданы");
            _asteroids = new Asteroid[6];
            _bullets = new List<Bullet>();
            try
            {
                for (int i = 0; i < _stars.Length; i++)
                {
                    _stars[i] = new Star(new Point(r.Next(Width), r.Next(Height)), new Point(r.Next(-3, -1), 0), new Size(20, 20));
                }
                for (int i = 0; i < _asteroids.Length; i++)
                {
                    _asteroids[i] = new Asteroid(new Point(r.Next(Width / 2, Width), r.Next(30, Height - 30)), new Point(r.Next(-6, -3), 0), new Size(30, 40));
                    LogTo.Invoke($"Астериод номер {i} создан. Его скорость {_asteroids[i].Dir.X}");
                    if (_asteroids[i].Dir.X < -7) throw new GameObjectException("Задана слишком большая скорость для астероида!");
                }
                _ship = new Ship(new Point(0, Height / 2), new Point(0, 10), new Size(100, 40));
                _kit = new FirstAidKit(new Point(Width, r.Next(Height - 20)), new Point(0, 0), new Size(60, 40));
                LogTo.Invoke("Корабль создан");
            }
            catch (GameObjectException e)
            {
                LogTo.Invoke(e.Message);
            }
            _timer.Start();
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Space)
            {
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 80, _ship.Rect.Y+20), new Point(5, 0), new Size(5, 3)));
                LogTo.Invoke("Выстрел!");
            }
        }
        public static void Draw()
        {
            try
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
                if (_bullets != null)
                {
                    foreach (Bullet bullet in _bullets)
                    {
                        bullet.Draw();
                    }
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
            catch (Exception e)
            {
                LogTo.Invoke($"{e.Message}");
                _timer.Stop();
            }
        }

        public static void Update()
        {
            foreach (Star star in _stars)
            {
                star.Update();
            }
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid is Asteroid && _ship.Collision(asteroid))
                {
                    LogTo.Invoke("Корабль врезался в астероид");
                    _health--;
                    asteroid.RestartPos();
                }
                for (int i = 0; i < _bullets.Count; i++)
                {
                    if (asteroid is Asteroid && asteroid.Collision(_bullets[i]))
                    {
                        LogTo.Invoke("Астероид сбит!");
                        asteroid.RestartPos();
                        LogTo.Invoke($"Новый астероид создан. Его скорость {asteroid.Dir.X}");
                        _score++;
                        _bullets.RemoveAt(i);
                        i--;
                        break;
                    }
                    if (_kit.Collision(_bullets[i]))
                    {
                        _kit.RestartPos();
                        _bullets.RemoveAt(i);
                        _health++;
                        i--;
                        break;
                    }
                    _bullets[i].Update();
                }
                if (_kit.Collision(_ship))
                {
                    _kit.RestartPos();
                    _health--;
                }
            }
            _kit?.Update();
            _ship.Update();
        }
    }
}
