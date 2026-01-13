namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Стена, граница карты
    /// </summary>
    internal class Wall : Entity
    {
        public Wall(Rectangle rectangle) => this.rectangle = rectangle;
        public override void Draw(ref char[,] screen)
        {
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                    screen[j, i] = '█';
        }
    }
}
