using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    internal class StunEffect : IEffect<IStunnable>
    {
        public string Description => "ЗЕЛЬЕ РАЗОЧАРОВАНИЕ В СЕБЕ";
        public string Apply(IStunnable target, int power)
        {
            if (!target.IsProtectedFromStun)
            {
                target.SetStun(2);
                return $"{target.Name} РАЗОЧАРОВЫВАЕТСЯ В СЕБЕ И ОГЛУШАЕТСЯ НА {target.StunRoundsCount} ХОД(ОВ)!!!";
            }
            return $"ВЕЛИКИЙ НАШАТЫРЬ ЗАЩИТИЛ {target.Name} ОТ РАЗОЧАРОВАНИЯ!!!";
        }
    }
}
