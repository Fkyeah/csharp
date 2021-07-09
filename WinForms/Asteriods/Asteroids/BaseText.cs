using System;
using System.Drawing;

namespace Asteroids
{
    class BaseText
    {
        public Point Pos;
        protected Point Dir;
        protected Size Size;
        public string Value;

        public BaseText(string value, Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Value = value;
        }
        public virtual void UpdatePos()
        {
            if (Pos.Y < MainMenu.Height / 2 - 50)
                Pos.Y += Dir.Y;
        }
        public void WriteText()
        {
            MainMenu.Buffer.Graphics.DrawString(Value, SystemFonts.MenuFont, Brushes.White, Pos, StringFormat.GenericTypographic);
        }
    }
    class Name : BaseText
    {
        public Name(string value, Point pos, Point dir, Size size) : base(value, pos, dir, size)
        {      
        }
        public override void UpdatePos()
        {
            if (Pos.X < MainMenu.Width / 2 - 50)
                Pos.X += Dir.X;
        }
    }
    class SurName : BaseText
    {
        public SurName(string value, Point pos, Point dir, Size size) : base(value, pos, dir, size)
        {
        }
        public override void UpdatePos()
        {
            if (Pos.X > MainMenu.Width / 2 + 20)
                Pos.X += Dir.X;
        }
    }
}
