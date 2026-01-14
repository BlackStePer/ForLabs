using System;

namespace UHarchiLab.Products.HealthFood
{
    internal class OliveOil : IHealthyFood
    {
        public string Name { get; } = "Оливковое масло";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = true;
        public bool Carbohydrates { get; } = false;
    }
}
