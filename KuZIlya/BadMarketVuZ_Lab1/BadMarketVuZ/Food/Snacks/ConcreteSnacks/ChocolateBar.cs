namespace BadMarketVuZ.Food.Snacks.ConcreteSnacks
{
    internal record ChocolateBar : ISnacks
    {
        public int HarmFactor => 3;

        public string Name => "ШОКОЛАДОЧКА";

        public double Proteins => 6.3;

        public double Fats => 31.5;

        public double Carbohydrates => 52.2;

        public int Calories => 518;

        public int Price => 150;
    }
}
