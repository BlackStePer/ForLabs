using System;

namespace UHarchiLab.Products
{
    internal class ChocolateBar : Isnacks
    {
        public string Name { get; } = "Плитка шоколада";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = true;

    }
}
