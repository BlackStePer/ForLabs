
namespace BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood
{
    internal record Chicken : IHealthyFood
    {
        public int BenefitFactor => 3;

        public int Calories => 880;

        public string Name => "КУРОЧКА ФИЛЕ";

        public double Proteins => 184.0;

        public double Fats => 16.0;

        public double Carbohydrates => 0.0;

        public int Price => 520;
    }
}
