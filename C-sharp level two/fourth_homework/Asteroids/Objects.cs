using System;
using System.Drawing;

namespace Asteroids
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class BaseObject : ICollision
    {
        protected Point _pos;
        protected Point _dir;
        protected Size _size;

        public Point Pos => _pos; 
        public Point Dir => _dir;
        public int DirX { set { _dir.X = value; } }
        public int DirY { set { _dir.Y = value; } }

        public Size Size => _size; 
        public BaseObject(Point pos, Point dir, Size size)
        {
            _pos = pos;
            _dir = dir;
            _size = size;
        }
        public Rectangle Rect => new Rectangle(_pos, _size);
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
        public abstract void Draw();

        public abstract void Update();

        public virtual void RestartPos()
        {
            _pos.X = 0;
            _pos.Y = Game.r.Next(0, Game.Height - 20);
        }
    }
    class Star:BaseObject
    {
        static Image star = Image.FromFile("Images\\star.png");
        public Star(Point pos, Point dir, Size size):base(pos,dir,size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(star, _pos);
        }
        public override void Update()
        {
            _pos.X += _dir.X;
            if (_pos.X < -5) _pos.X = Game.Width;
        }
    }
    class Asteroid : BaseObject
    {
        static Image asteroid = Image.FromFile("Images\\asteroid.png");
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(asteroid, _pos);
        }
        public override void Update()
        {
            _pos.X += _dir.X;
            if (_pos.X < -5)
            {
                _pos.X = Game.Width;
                _pos.Y = Game.r.Next(0,Game.Height-20);
                _dir.X = Game.r.Next(-6, -3);
            }
        }
    }
    class Bullet : BaseObject
    {
        public static event Action<Bullet> OverScreen;
        public static event Action<Bullet> StrikeAsteroid;
        static Image bullet = Image.FromFile("Images\\bullet.png");
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(bullet, _pos);
        }
        public override void Update()
        {
            StrikeAsteroid(this);
            _pos.X += _dir.X;
            if (_pos.X > Game.Width)
            {
                OverScreen(this);
            }
        }
    }

    class Ship : BaseObject
    {
        static Image ship = Image.FromFile("Images\\ship.png");
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(ship, _pos);
        }
        public override void Update()
        {
            _pos.X += _dir.X;
            _pos.Y += _dir.Y;
        }
        public void Up()
        {
            _dir.Y = -Math.Abs(_dir.Y);
        }
        public void Down()
        {
            _dir.Y = Math.Abs(_dir.Y);
        }
    }
    class FirstAidKit : BaseObject
    {
        static Image firstAidKit = Image.FromFile("Images\\first_aid_kit.jpg");
        public FirstAidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(firstAidKit, _pos);
        }
        public override void Update()
        {
            _pos.X += _dir.X;
            if (_pos.X < -5)
            {
                _pos.X = Game.Width;
                _dir.X = 0;
            }
        }
        public override void RestartPos()
        {
            _pos.X = Game.Width;
            _pos.Y = Game.r.Next(0, Game.Height - 20);
            _dir.X = 0;
        }
    }
}
