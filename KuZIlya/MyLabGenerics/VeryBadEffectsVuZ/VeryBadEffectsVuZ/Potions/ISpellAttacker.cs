using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Potions
{
    internal interface ISpellAttacker<out TAttacker> where TAttacker : IUnit
    {
        string Description { get; }
    }
}
