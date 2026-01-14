using System;

namespace UHarchiLab.Products.SemiFifinishedFood
{
    internal class DumplingsMeat : ISemiFifinishedFood
    {
        public string Name { get; } = "Пельмени";
        public bool Proteins { get; } = true;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = false;
    }
}
