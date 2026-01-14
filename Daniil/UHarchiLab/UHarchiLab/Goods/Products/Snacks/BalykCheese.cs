using System;

namespace UHarchiLab.Products
{
    internal class BalykCheese : Isnacks
    {
        public string Name { get; } = "Сыр Балык";
        public bool Proteins { get; } = true;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = false;
    }
}
