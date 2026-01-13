namespace BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood
{
    internal record OliveOil : IHealthyFood
    {
        public int BenefitFactor => 52;

        public int Calories => 4095;

        public string Name => "ОЛИВКОВОЕ МАСЛО (БУТЫЛКА)";

        public double Proteins => 0.0;

        public double Fats => 455.0;

        public double Carbohydrates => 0.0;

        public int Price => 1000;
    }
}
