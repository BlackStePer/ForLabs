using VeryBadEffectsVuZ.Spells;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Targets.ConcreteTargets
{
    /// <summary>
    /// Воин из магов 2
    /// </summary>
    internal class Warrior : IUnit, IPoisonable, IBurnable, IHealable
    {
        public Warrior(string name, int position, Castle castle)
        {
            Name = name;
            MyCastle = castle;
            Position = position;
            HP = MaxHP;
        }
        public int AttackRange { get; set; } = 1;
        public int HP { get; set; }
        public int MaxHP { get; private set; } = 50;
        public List<ISpellTarget<ITargetable>> Inventory { get; } = [];
        public Castle MyCastle { get; init; }
        public string Name { get; }
        public int BurnMovesCount { get; set; } = 0;
        public int PoisonedMovesCount { get; set; } = 0;
        public int PoisonPower { get; set; }
        public int BurnPower { get; set; }
        public int Damage { get; set; } = 52;
        public int Position { get; set; }
        public string Avatar => "🤴🏻";
        public void GetBurned(int rounds, int power)
        {
            BurnMovesCount = rounds;
            BurnPower = (int)(power * 2.5);
        }
        public void GetPoisoned(int rounds, int power)
        {
            PoisonedMovesCount = rounds;
            PoisonPower = (int)(power * 2.5);
        }
        public void GetBurnDamage()
        {
            HP = HP - BurnPower > 0 ? HP - BurnPower : 0;
            BurnMovesCount--;
        }
        public void GetPoisonDamage()
        {
            HP = HP - PoisonPower > 0 ? HP - PoisonPower : 0;
            PoisonedMovesCount--;
        }
        public void Heal(int amount) => HP = HP + amount > MaxHP ? MaxHP : HP + amount;
        public void TakeDamage(int amount) => HP = HP;
        public string Update()
        {
            string message = "";
            if (BurnMovesCount > 0)
            {
                GetBurnDamage();
                if (BurnMovesCount > 0)
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ПОДЖЁГА. ОГОНЬ НЕ ПОТУХНЕТ ЕЩЁ {BurnMovesCount} ХОДОВ!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
                else
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ПОДЖЁГА. И ОН ПОЛНОСТЬЮ ВОССТАНАВЛИВАЕТСЯ!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
            }
            if (PoisonedMovesCount > 0)
            {
                GetPoisonDamage();
                if (PoisonedMovesCount > 0)
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ОТРАВЛЕНИЯ. ЕГО ЖДЁТ ПОНОС ЕЩЕ В ТЕЧЕНИЕ {PoisonedMovesCount} ХОДОВ!!! ЗА ХОД ПОЛУЧЕН УРОН {PoisonPower}!!!";
                else
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ОТРАВЛЕНИЯ. И ОН ПОЛНОСТЬЮ ВОССТАНАВЛИВАЕТСЯ!!! ЗА ХОД ПОЛУЧЕН УРОН {PoisonPower}!!!";
            }
            if (message == "")
                return $"{Name} В НОРМЕ!!!";
            return message;
        }
    }
}
