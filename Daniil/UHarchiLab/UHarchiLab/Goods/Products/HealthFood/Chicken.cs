using System;

namespace UHarchiLab.Products.HealthFood
{
    internal class Chicken : IHealthyFood
    {
        public string Name { get; } = "Курица";
        public bool Proteins { get; } = true;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = false;
    }
}
