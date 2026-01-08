namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// ОНО ГОРИТ
    /// </summary>
    internal interface IBurnable : ITargetable
    {
        int BurnMovesCount { get; set; }
        int BurnPower { get; set; }
        /// <summary>
        /// Метод, пожигает цель
        /// </summary>
        /// <param name="rounds">Продолжительность горения</param>
        /// <param name="power">Сила горения</param>
        void GetBurned(int rounds, int power);
        /// <summary>
        /// Метод, наносит урон огнём
        /// </summary>
        void GetBurnDamage();
    }
}
