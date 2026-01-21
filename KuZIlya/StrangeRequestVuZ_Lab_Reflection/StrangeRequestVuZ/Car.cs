namespace StrangeRequestVuZ
{
    /// <summary>
    /// Класс бибики
    /// </summary>
    internal class Car
    {
        public string Model;
        public Engine CarEngine; // Вложенный объект для проверки 150% решения
        public Car(string model, int hp) { Model = model; CarEngine = new Engine(hp); }
    }
}
