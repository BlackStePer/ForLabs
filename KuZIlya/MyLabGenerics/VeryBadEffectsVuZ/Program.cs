
namespace VeryBadEffectsVuZ
{
    /// <summary>
    /// Самый ненужный класс в лабе
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Какой-то бесполезный метод
        /// </summary>
        /// <param name="args">хз что это</param>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            GameEngine gameEngine = new();
            gameEngine.Run();
            #region НЕ СМОТРЕТЬ
            unsafe
            {
                Siberia siberia = new();
                Siberia* n = &siberia; // ЭТО ССЫЛКА В СИБИРЬ!!!
            }
        }

        public readonly struct Siberia()
        {
            private readonly int rabs = 52;
        }
        #endregion
    }
}
