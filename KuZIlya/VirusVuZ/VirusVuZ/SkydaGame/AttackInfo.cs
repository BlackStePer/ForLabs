namespace VirusVuZ.SkydaGame
{
    /// <summary>
    /// Класс, описывает атаки скуды
    /// </summary>
    internal record AttackInfo
    {
        public string Name { get; }
        public int Power { get; }
        public int ResourceCost { get; init; }
        public AttackInfo(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
