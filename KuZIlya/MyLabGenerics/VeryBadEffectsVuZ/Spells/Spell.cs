using VeryBadEffectsVuZ.Effects;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Spells
{
    /// <summary>
    /// Класс, описывает любое заклинание
    /// </summary>
    /// <typeparam name="TTarget">Тип цели атаки</typeparam>
    /// <typeparam name="TAttacker">Тип атакующего</typeparam>
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
                return effect.Apply(specificTarget, power);
            return "Ошибка: Неподходящая цель!";
        }
    }
}
