using VirusVuZ.ProtectionSystemGame.Notifiers;

namespace VirusVuZ.ProtectionSystemGame
{
    /// <summary>
    /// Класс, описывает любой слой
    /// </summary>
    internal class ProtectionLayer
    {
        public string Name { get; }
        public double Health { get; set; }
        public double Resistance { get; private set; }
        public int Level { get; set; }
        public bool IsBreached { get; set; } = false;
        public IReactProtectionFall Notifier { get; set; }
        public ProtectionLayer(string name, int health, int resistance, IReactProtectionFall notifier)
        {
            Name = name;
            Health = health;
            Resistance = resistance;
            Notifier = notifier;
            Level = 1;
        }
        /// <summary>
        /// Получени урона слоем
        /// </summary>
        /// <param name="damage">Кол-во урона</param>
        public void TakeDamage(double damage)
        {
            damage -= Resistance;
            if (damage > 0)
                Health -= damage;
        }
        /// <summary>
        /// Улучшить слой
        /// </summary>
        public void Upgrade()
        {
            Level++;
            Health += 20;
            Resistance *= 1.2;
        }
    }
}
