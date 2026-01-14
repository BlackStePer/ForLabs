using System;

namespace UHarchiLab.Products.SemiFifinishedFood
{
    internal class Cheburek : ISemiFifinishedFood
    {
        public string Name { get; } = "Чебурек";
        public bool Proteins { get; } = false;
        public bool Fats { get; } = true;
        public bool Carbohydrates { get; } = false;
    }
}
