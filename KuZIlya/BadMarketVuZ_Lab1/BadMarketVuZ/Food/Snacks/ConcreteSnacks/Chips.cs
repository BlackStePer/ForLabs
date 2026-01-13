namespace BadMarketVuZ.Food.Snacks.ConcreteSnacks
{
    internal record Chips : ISnacks
    {
        public int HarmFactor => 5;

        public string Name => "ЧИПСЕКИ";

        public double Proteins => 9.0;

        public double Fats => 45.0;

        public double Carbohydrates => 79.5;

        public int Calories => 760;

        public int Price => 200;
    }
}
