using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Targets.ConcreteTargets
{
    /// <summary>
    /// Замок
    /// </summary>
    internal class Castle : IDamageable, IBurnable
    {
        public string Avarar { get; } = "🏰";
        public string Name { get; }
        public int HP { get; private set; }
        public int BurnMovesCount { get; set; }
        public int BurnPower { get; set; }
        public int Position { get; set; }

        public Castle(int hp, int position, string name)
        {
            HP = hp;
            Name = name;
            Position = position;
        }
        public void GetBurned(int rounds, int power)
        {
            BurnMovesCount = (int)(rounds * 1.5);
            BurnPower = power;
        }
        public void TakeDamage(int amount) => HP = HP - amount > 0 ? HP - amount : 0;
        public override string ToString() => $"{Name}: Остлось {HP} едениц здоровья";

        public void GetBurnDamage()
        {
            HP = HP - BurnPower > 0 ? HP - BurnPower : 0;
            BurnMovesCount--;
        }
        public string Update()
        {
            if (BurnMovesCount > 0)
            {
                GetBurnDamage();
                if (BurnMovesCount == 0)
                    return $"{Name} УСПЕШНО ПОТУШЕН!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
                return $"{Name} БУДЕТ ГОРЕТЬ ЕЩЁ {BurnMovesCount} ХОДОВ!!! ЗА ХОД ПОЛУЧЕН УРОН {BurnPower}!!!";
            }
            return $"{Name} В НОРМЕ!!!";
        }
    }
}
