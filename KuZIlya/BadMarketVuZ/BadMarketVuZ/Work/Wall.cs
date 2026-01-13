using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWorld {
    internal class Wall : Entity {
        public Wall(Rectangle rectangle) => this.rectangle = rectangle;
        public override void Draw(ref char[,] screen)
        {
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                    screen[j, i] = '█';
        }
    }
}
