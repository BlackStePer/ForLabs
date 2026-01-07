using System;
using System.Collections.Generic;
using System.Text;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IStunnable : ITargetable
    {
        void SetStun(int rounds);
        void SetProtectionFromStun(bool active);
        public int StunRoundsCount { get; set; }
        public bool IsProtectedFromStun { get; }
    }
}
