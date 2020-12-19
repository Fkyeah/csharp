using System;
using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        public Point Pos;
        public Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()//позднее связывание
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < -5) Pos.X = Game.Width;
            if (Pos.X > Game.Width) Pos.X = 0;
            if (Pos.Y < -5) Pos.Y = Game.Height;
            if (Pos.Y > Game.Height) Pos.Y = 0;
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
            Game.Buffer.Graphics.DrawImage(star, Pos);
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
            Game.Buffer.Graphics.DrawImage(asteroid, Pos);
        }

        public override void Update()
        {
            Pos.X += Dir.X;
            if (Pos.X < -5)
            {
                Pos.X = Game.Width;
                Pos.Y = Game.r.Next(0,Game.Height-20);
                Dir.X = Game.r.Next(-6, -3);
            }
        }
    }
}
