using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    internal class FireballEffect : IEffect<IDamageable>
    {
        public string Description { get; set; } = "ГОРЯЧАЯ КАРТОШКА!!!";
        public string Apply(IDamageable target, int power)
        {
            int startHP = target.HP;
            string message = "";
            target.TakeDamage(power * 2);
            if (target is IBurnable burnTarget)
            {
                burnTarget.GetBurned(2, power / 3);
                message += $"И {target.Name} ЗАГОРАЕТСЯ НА {burnTarget.BurnMovesCount} ХОД(ОВ)!!!\n";
            }
            message+= $"{target.Name} БЫЛ ПОРАЖЁН ОГНЁМ НА {startHP - target.HP} ЕДЕНИЦ УРОНА!!!";
            return message;

        }

    }
}
