using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IPoisonable : ITargetable
    {
        void GetPoisonDamage();
        void GetPoisoned(int rounds, int power);
        public int PoisonedMovesCount { get; set; }
        public int PoisonPower { get; set; }
    }
}
