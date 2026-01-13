using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWorld {
    internal class Button : Entity {
        public Button(Point point) => rectangle = new Rectangle(point.X, point.Y, 1, 1);
        public override void Draw(ref char[,] screen) => screen[rectangle.Y, rectangle.X] = 'X';
    }
}
