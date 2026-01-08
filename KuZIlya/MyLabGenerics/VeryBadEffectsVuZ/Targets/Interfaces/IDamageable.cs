namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// ОНО МОЖЕТ ПОСТРАДАТЬ
    /// </summary>
    internal interface IDamageable : ITargetable
    {
        /// <summary>
        /// Метод, причиняет страдания объекту...
        /// </summary>
        /// <param name="amount">Кол-во получаемого урона</param>
        void TakeDamage(int amount);
        int HP { get; }
    }
}
