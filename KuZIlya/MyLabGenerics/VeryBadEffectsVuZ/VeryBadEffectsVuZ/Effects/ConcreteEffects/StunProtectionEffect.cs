using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    internal class StunProtectionEffect : IEffect<IStunnable>
    {
        public string Description => "НАШАТЫРНЫЙ СПИРТ";

        public string Apply(IStunnable target, int power)
        {
            target.SetProtectionFromStun(true);
            return $"НАШАТЫРЬ ЗАЩИЩАЕТ {target.Name} ОТ ЛЮБОГО ВИДА ОГЛУШЕНИЯ!!!";
        }
    }
}
