using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// Коварная магическая субстанция, проникающая в саму суть живого организма и медленно разрушающая его изнутри ядовитыми эманациями
    /// </summary>
    internal class PoisonEffect : IEffect<IPoisonable>
    {
        public string Description => "ТУХЛАЯ ШАВА";
        public string Apply(IPoisonable target, int power)
        {
            string message = "";
            target.GetPoisoned(2, power);
            message += $"{target.Name} БЫЛ ПОРАЖЁН НЕКАЧЕСТВЕННОЙ ШАУРМОЙ И ОТРАВИЛСЯ НА {target.PoisonedMovesCount} ХОД(ОВ)!!!\n";
            if (target is IDamageable damageTarget)
            {
                int startHP = damageTarget.HP;
                damageTarget.TakeDamage(power);
                message += $"А ТАКЖЕ ЯД ТУХЛОЙ ШАУРМЫ НАНОСИТ {startHP - damageTarget.HP} ЕДЕНИЦ УРОНА!!!";
            }
            return message;
        }
    }
}
