using System;

namespace UHarchiLab.Products
{
    internal class Crisps : Isnacks
    {
        public string Name { get; } = "Чипсы";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = true;
        public bool Carbohydrates { get; } = false;
    }
}
