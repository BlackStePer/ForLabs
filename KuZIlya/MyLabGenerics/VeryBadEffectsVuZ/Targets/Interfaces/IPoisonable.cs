namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// ОНО МОЖЕТ БОЛЕТЬ
    /// </summary>
    internal interface IPoisonable : ITargetable
    {
        /// <summary>
        /// Метод, наносит урон от болезни
        /// </summary>
        void GetPoisonDamage();
        /// <summary>
        /// Метод, помогает травануться
        /// </summary>
        /// <param name="rounds">Кол-во раундов отравления</param>
        /// <param name="power">Сила отравления</param>
        void GetPoisoned(int rounds, int power);
        int PoisonedMovesCount { get; set; }
        int PoisonPower { get; set; }
    }
}
