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

        public Point Pos { get { return _pos; } }
        public Point Dir { get { return _dir; } }
        public Size Size { get { return _size; } }
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

        // 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
        public abstract void Update();

        // 3. Сделать так, чтобы при столкновениях пули с астероидом они регенерировались в разных концах экрана.
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
    class Asteroid:BaseObject
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
        public override void RestartPos()
        {
            _pos.X = Game.Width;
            _pos.Y = Game.r.Next(0, Game.Height - 20);
        }
    }
    class Bullet : BaseObject
    {
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
            _pos.X += _dir.X;
            if (_pos.X > Game.Width)
            {
                _pos.X = 0;
                _pos.Y = Game.r.Next(0, Game.Height - _size.Height);
            }
        }
    }
}
