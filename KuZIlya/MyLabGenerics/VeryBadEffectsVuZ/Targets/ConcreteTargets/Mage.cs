using VeryBadEffectsVuZ.Spells;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Targets.ConcreteTargets
{
    /// <summary>
    /// Маг из магов 1
    /// </summary>
    internal class Mage : IUnit, IDamageable, IStunnable, IPoisonable, IBurnable, IHealable
    {
        public Mage(string name, int position, Castle castle)
        {
            Name = name;
            MyCastle = castle;
            Position = position;
            HP = MaxHP;
        }
        public int AttackRange { get; set; } = 3;
        public int HP { get; set; }
        public int MaxHP { get; private set; } = 50;
        public List<ISpellTarget<ITargetable>> Inventory { get; } = [];
        public Castle MyCastle { get; init; }
        public string Name { get; }
        public int BurnMovesCount { get; set; } = 0;
        public int StunRoundsCount { get; set; } = 0;
        public bool IsProtectedFromStun { get; private set; } = false;
        public int PoisonedMovesCount { get; set; } = 0;
        public int PoisonPower { get; set; }
        public int BurnPower { get; set; }
        public int Damage { get; set; } = 10;
        public int Position { get; set; }
        public string Avatar => "🧙";
        public void GetBurned(int rounds, int power)
        {
            BurnMovesCount = rounds;
            BurnPower = power;
        }
        public void GetPoisoned(int rounds, int power)
        {
            PoisonedMovesCount = rounds;
            PoisonPower = power;
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
        public void SetProtectionFromStun(bool active) => IsProtectedFromStun = active;
        public void SetStun(int amount) => StunRoundsCount = amount;
        public void TakeDamage(int amount) => HP = HP - amount > 0 ? HP - amount : 0;
        public string Update()
        {
            if (IsProtectedFromStun)
                IsProtectedFromStun = false;
            string message = "";
            if (StunRoundsCount > 0)
            {
                StunRoundsCount--;
                if (StunRoundsCount > 0)
                    message += $"{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ОГЛУШЕНИЯ. ОГЛУШЕНИЕ ПРОДЛИТСЯ ЕЩЁ {StunRoundsCount} ХОДОВ!!!";
                else
                    message += $"{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ОГЛУШЕНИЯ. И ОН ПОЛНОСТЬЮ ВОССТАНАВЛИВАЕТСЯ!!!";
            }
            if (BurnMovesCount > 0 && HP != 0)
            {
                GetBurnDamage();
                if (BurnMovesCount > 0)
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ПОДЖЁГА. ОГОНЬ НЕ ПОТУХНЕТ ЕЩЁ {BurnMovesCount} ХОДОВ!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
                else
                    message += $"\n{Name} СТАНОВИТСЯ ЛУЧШЕ ПОСЛЕ ПОДЖЁГА. И ОН ПОЛНОСТЬЮ ВОССТАНАВЛИВАЕТСЯ!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
            }
            if (PoisonedMovesCount > 0 && HP != 0)
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
