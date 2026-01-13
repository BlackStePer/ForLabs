namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Коробка, её можно двигать
    /// </summary>
    internal class Box : Entity
    {
        public bool onButton = false;
        public Box(Point point) => rectangle = new Rectangle(point.X, point.Y, 1, 1);
        public override void Draw(ref char[,] screen) => screen[rectangle.Y, rectangle.X] = '▒';

    }
}
