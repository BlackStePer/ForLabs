
namespace VeryBadEffectsVuZ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            GameEngine gameEngine = new GameEngine();
            gameEngine.Run();
        }
    }
}
