namespace BadMarketVuZ.Work.Scenes
{
    /// <summary>
    /// Описание сцены
    /// </summary>
    internal abstract class Scene
    {
        /// <summary>
        /// Отрисовывает сцену
        /// </summary>
        /// <param name="screen">Массив для отрисовки</param>
        public abstract void Update(ref char[,] screen);
        /// <summary>
        /// Обрабатывает нажатия
        /// </summary>
        /// <param name="inp">Команда для обработчика</param>
        public abstract void OnInput(char inp);
        public bool workIsOver = false;
        public static int salary;
    }
}
