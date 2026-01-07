using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    internal class FireEffect : IEffect<IBurnable>
    {
        public string Description => "ОСТРЫЕ КРЫЛЫШКИ KFC!!!";

        public string Apply(IBurnable target, int power)
        {
            target.GetBurned(2, power);
            if (target is IUnit)
                return $"{target.Name} СТАНОВИТСЯ ПЛОХО ОТ ВКУСА КРЫЛЫШЕК И ОН ЗАГОРАЕТСЯ НА {target.BurnMovesCount} ХОДОВ!!!";
            else
                return $"КРЛЫШКИ ИЗ КФЦ БЫЛИ НАСТОЛЬКО ОСТРЫМИ, ЧТО ПОДОЖГЛИ ВАШ ЗАМОК!!!";
        }
    }
}
