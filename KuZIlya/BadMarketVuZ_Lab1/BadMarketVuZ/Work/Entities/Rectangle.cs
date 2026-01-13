namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Четырёхугольник, у которого все четыре угла прямые (равны 90 градусам), а противоположные стороны попарно параллельны и равны.
    /// </summary>
    internal class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// Делает копию
        /// </summary>
        /// <returns>Копия объекта</returns>
        public Rectangle Clone() => (Rectangle)MemberwiseClone();
        /// <summary>
        /// Проверка пересечения
        /// </summary>
        /// <param name="rectangle">Объект прямоугольника</param>
        /// <returns>true если есть пересечение, иначе false</returns>
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
