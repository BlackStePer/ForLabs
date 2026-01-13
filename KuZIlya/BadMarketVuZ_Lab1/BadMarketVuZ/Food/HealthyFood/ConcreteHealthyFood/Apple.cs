namespace BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood
{
    internal record Apple : IHealthyFood
    {
        public int BenefitFactor => 5;

        public int Calories => 452;

        public string Name => "КИЛОГРАММ ЯБЛОЧЕК";

        public double Proteins => 4.0;

        public double Fats => 4.0;

        public double Carbohydrates => 100.0;

        public int Price => 180;
    }
}
