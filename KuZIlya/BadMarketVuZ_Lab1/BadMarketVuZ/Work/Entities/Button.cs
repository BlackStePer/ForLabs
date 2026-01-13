namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Кнопка, на неё надо поставить коробку
    /// </summary>
    internal class Button : Entity
    {
        public Button(Point point) => rectangle = new Rectangle(point.X, point.Y, 1, 1);
        public override void Draw(ref char[,] screen) => screen[rectangle.Y, rectangle.X] = 'X';
    }
}
