using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface ITargetable 
    {
        public string Name { get; }
        public int Position { get; set; }
    }
}
