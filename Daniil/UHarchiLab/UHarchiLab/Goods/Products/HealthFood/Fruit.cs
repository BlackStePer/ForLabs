using System;

namespace UHarchiLab.Products.HealthFood
{
    internal class Fruit : IHealthyFood
    {
        public string Name { get; } = "Фрукт";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = true;
    }
}
