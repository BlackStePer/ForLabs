using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWorld {
    internal abstract class Entity {
        public Rectangle rectangle;
        public abstract void Draw(ref char[,] screen);
    }
}
