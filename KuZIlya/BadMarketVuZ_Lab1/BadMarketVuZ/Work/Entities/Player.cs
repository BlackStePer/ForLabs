namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Ваш игрок
    /// </summary>
    internal class Player : Entity
    {
        public Player(Point point) => rectangle = new Rectangle(point.X, point.Y, 1, 1);
        public override void Draw(ref char[,] screen) => screen[rectangle.Y, rectangle.X] = '☺';
    }
}
