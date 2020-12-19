using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Image _background = Image.FromFile("Images\\background.jpg");
        private static Graphics _g;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static Image Background { get { return _background; } }
        private static Star[] _stars;
        private static Asteroid[] _asteroids;
        private static Timer _timer;
        public static Timer Timer { get {return _timer;} }
        public static Random r = new Random();
        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            _g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
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
            _asteroids = new Asteroid[4];
            for (int i = 0; i < _stars.Length ; i++)
            {
                _stars[i] = new Star(new Point(r.Next(Width), r.Next(Height)), new Point(r.Next(-3,-1), 0), new Size(20, 20));
            }
            for (int i = 0; i < _asteroids.Length; i++)
            {
                _asteroids[i] = new Asteroid(new Point(r.Next(Width), r.Next(Height-10)), new Point(r.Next(-6,-3), 0), new Size(20, 20));
            }
            _timer.Start();
        }

        public static void Draw()
        {
            try
            {
                Buffer = _context.Allocate(_g, new Rectangle(0, 0, Width, Height));
                // Проверяем вывод графики
                Game.Buffer.Graphics.DrawImage(_background, 0, 0);
                //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200,200));
                //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200,200));
                foreach (Star star in _stars)
                {
                    star.Draw();
                }
                foreach (Asteroid asteroid in _asteroids)
                {
                    asteroid.Draw();
                }
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
            }
        }
    }
}
