using VeryBadEffectsVuZ.Potion;
using VeryBadEffectsVuZ.Potions;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ
{
    internal class SpellScroll<TAttacker> where TAttacker : IUnit
    {
        public ISpellAttacker<TAttacker> Potion { get; }
        public SpellScroll(ISpellAttacker<TAttacker> potion) => Potion = potion;
    }
}