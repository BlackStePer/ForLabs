using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
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
