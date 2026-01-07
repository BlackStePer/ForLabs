using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IDamageable : ITargetable
    {
        void TakeDamage(int amount);
        public int HP { get; }
    }
}
