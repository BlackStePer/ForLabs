namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// ОНО МОЖЕТ ЛЕЧИТЬСЯ
    /// </summary>
    internal interface IHealable : ITargetable
    {
        /// <summary>
        /// Метод, лечит
        /// </summary>
        /// <param name="amount">Кол-во восстановленных хп</param>
        void Heal(int amount);
    }
}
