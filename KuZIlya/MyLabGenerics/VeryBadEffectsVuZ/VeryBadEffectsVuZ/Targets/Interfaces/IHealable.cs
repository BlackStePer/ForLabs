using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IHealable : ITargetable
    {
        void Heal(int amount);
    }
}
