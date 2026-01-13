namespace BadMarketVuZ.Work
{
    internal abstract class Scene
    {
        public abstract void Update(ref char[,] screen);
        public abstract void OnInput(char inp);
        public bool workIsOver = false;
        public static int salary;
    }
}
