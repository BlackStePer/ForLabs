using VeryBadEffectsVuZ.Targets.ConcreteTargets;

namespace VeryBadEffectsVuZ.Altar
{
    /// <summary>
    /// Алтарь, помогает избавиться от мусора
    /// </summary>
    internal class MagicAltar
    {
        private static readonly Random random = new();
        private static int requiredSacrificeCount = random.Next(3, 6);
        public MagicAltar(int position) => Position = position;
        /// <summary>
        /// Пожертвовать продвинутое заклинание
        /// </summary>
        /// <param name="scroll">Ссылка на штуку для инвариантности</param>
        /// <returns>Процесс жертвования заклинания</returns>
        public string Sacrifice(SpellScroll<Mage> scroll)
        {
            SacrificeCount++;
            if (SacrificeCount != requiredSacrificeCount)
                return $"Алтарь поглотил {scroll.Spell.Description}";
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
