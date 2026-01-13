namespace BadMarketVuZ.Work.Entities
{
    /// <summary>
    /// Какая-то сущность
    /// </summary>
    internal abstract class Entity
    {
        public Rectangle rectangle;
        /// <summary>
        /// Рисует сущность
        /// </summary>
        /// <param name="screen">Массив для отрисовки</param>
        public abstract void Draw(ref char[,] screen);
    }
}
