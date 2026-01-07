using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    internal class MilitaryNotice : IEffect<IUnit>
    {
        public string Description => "ПОВЕСТКА В ВОЕНКОМАТ";

        public string Apply(IUnit target, int power)
        {
            target.HP = 0;
            return $"ПОВЕСТКА В ВОЕНКОМАТ ПОЛНОСТЬЮ РАЗОЧАРОВЫВАЕТ {target.Name}. ЕГО ВОЛЯ СРАЖАТЬСЯ СОШЛА НА НЕТ!!!";
        }
    }
}
