using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// Поток восстанавливающей жизненной энергии, который мгновенно затягивает раны и наполняет тело существа новой природной силой
    /// </summary>
    internal class HealthEffect : IEffect<IHealable>
    {
        public string Description => "ЗЕЛЬЕ ЛЕЧЕНИЯ ИЗ МАЙНКРАФТА";
        public string Apply(IHealable target, int power)
        {
            target.Heal(power);
            return $"{target.Name} ИЗЛЕЧИЛ СЕБЯ НА {power} ЕДЕНИЦ ЗДОРОВЬЯ!!!";
        }
    }
}
