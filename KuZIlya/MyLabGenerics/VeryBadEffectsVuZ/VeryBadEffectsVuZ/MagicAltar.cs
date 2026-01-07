using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ
{
    internal class MagicAltar
    {
        private static Random random = new Random();
        private static int requiredSacrificeCount = random.Next(3, 6);
        public MagicAltar(int position) => Position = position;
        public string Sacrifice(SpellScroll<Mage> scroll)
        {
            SacrificeCount++;
            if (SacrificeCount != requiredSacrificeCount)
                return $"Алтарь поглотил {scroll.Potion.Description}";
            else
            {
                SacrificeCount = 0;
                requiredSacrificeCount = random.Next(3, 6);
                Reward = true;
                return $"В награду за ваши жертвы вы получаете способность FIREBOOOOOOL";
            }
        }
        public int Position { get; set; }
        public int SacrificeCount { get; private set; } = 0;
        public bool Reward { get; set; } = false;
    }
}
