using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Effects;
using VeryBadEffectsVuZ.Effects.ConcreteEffects;
using VeryBadEffectsVuZ.Potions;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Potion
{
    internal class Spell<TTarget, TAttacker> : ISpellTarget<TTarget>, ISpellAttacker<TAttacker>
        where TTarget : ITargetable
        where TAttacker : IUnit
    {
        private readonly int power;
        private readonly IEffect<TTarget> effect;
        public string Description => effect.Description;
        public Spell(IEffect<TTarget> effect, int power)
        {
            this.effect = effect;
            this.power = power;
        }
        public bool CanTarget(ITargetable user) => user is TTarget;
        public bool CanBeUsedBy(IUnit attacker) => attacker is TAttacker;
        public string Use(ITargetable target)
        {
            if (target is TTarget specificTarget)
                return effect.Apply(specificTarget, this.power);
            return "Ошибка: Неподходящая цель!";
        }
    }
}
