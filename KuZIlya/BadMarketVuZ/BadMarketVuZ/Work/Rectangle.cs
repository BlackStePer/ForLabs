using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWorld {
    internal class Rectangle {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle Clone() => (Rectangle)MemberwiseClone();
        public bool Intersects(Rectangle rectangle) => X + Width > rectangle.X && X < rectangle.X + rectangle.Width && Y + Height > rectangle.Y && Y < rectangle.Y + rectangle.Height;
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
