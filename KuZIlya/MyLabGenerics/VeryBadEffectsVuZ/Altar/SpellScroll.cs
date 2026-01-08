using VeryBadEffectsVuZ.Spells;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Altar
{
    /// <summary>
    /// Штука для инвариантности
    /// </summary>
    /// <typeparam name="TAttacker">Тип атакующего</typeparam>
    internal class SpellScroll<TAttacker> where TAttacker : IUnit
    {
        public ISpellAttacker<TAttacker> Spell { get; }
        public SpellScroll(ISpellAttacker<TAttacker> spell) => Spell = spell;
    }
}