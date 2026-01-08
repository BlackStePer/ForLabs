using VeryBadEffectsVuZ.Spells;
using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Targets.ConcreteTargets
{
    /// <summary>
    /// Какой-то ноунейм
    /// </summary>
    internal class Archer : IUnit, IHealable, IDamageable, IStunnable
    {
        public Archer(string name, int position, Castle castle)
        {
            Name = name;
            MyCastle = castle;
            Position = position;
            HP = MaxHP;
        }
        public int AttackRange { get; set; } = 5;
        public int HP { get; set; }
        public int MaxHP { get; private set; } = 50;
        public List<ISpellTarget<ITargetable>> Inventory { get; } = [];
        public Castle MyCastle { get; init; }
        public string Name { get; }
        public int StunRoundsCount { get; set; } = 0;
        public bool IsProtectedFromStun { get; private set; } = false;
        public int Damage { get; set; } = 20;
        public int Position { get; set; }
        public string Avatar => "🧝";
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
            if (message == "")
                return $"{Name} В НОРМЕ!!!";
            return message;
        }
    }
}
