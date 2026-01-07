using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
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
