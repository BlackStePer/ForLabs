using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Effects;
using VeryBadEffectsVuZ.Potions;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Potion
{
    internal interface ISpellTarget <out TTarget> where TTarget : ITargetable
    {
        string Description { get; }
        public bool CanTarget(ITargetable user);
        public bool CanBeUsedBy(IUnit attacker);
        public string Use(ITargetable target);
    }   
}
