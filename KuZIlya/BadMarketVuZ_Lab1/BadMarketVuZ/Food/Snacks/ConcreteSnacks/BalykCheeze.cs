namespace BadMarketVuZ.Food.Snacks.ConcreteSnacks
{
    internal record BalykCheeze : ISnacks
    {
        public int HarmFactor => 1;

        public string Name => "СЫР КОСИЧКА";

        public double Proteins => 24.0;

        public double Fats => 21.0;

        public double Carbohydrates => 2.0;

        public int Calories => 293;

        public int Price => 160;
    }
}
