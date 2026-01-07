using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IBurnable : ITargetable
    {
        public int BurnMovesCount { get; set; }
        public int BurnPower { get; set; }
        void GetBurned(int rounds,int power);
        void GetBurnDamage();
    }
}
