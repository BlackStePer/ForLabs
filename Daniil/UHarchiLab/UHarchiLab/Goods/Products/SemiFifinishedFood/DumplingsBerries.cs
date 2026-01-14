using System;

namespace UHarchiLab.Products.SemiFifinishedFood
{
    internal class DumplingsBerries : ISemiFifinishedFood
    {
        public string Name { get; } = "Вареники с ягодами";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = false;
        public bool Carbohydrates { get; } = true;
    }
}
