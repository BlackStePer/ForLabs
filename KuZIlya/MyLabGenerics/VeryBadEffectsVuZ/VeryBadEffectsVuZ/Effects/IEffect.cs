using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects
{
    internal interface IEffect<in T> where T : ITargetable
    {
        string Description { get; }
        string Apply(T target, int power);
    }
}
