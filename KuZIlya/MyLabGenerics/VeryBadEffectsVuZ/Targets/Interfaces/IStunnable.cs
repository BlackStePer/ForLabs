namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// ЕГО МОЖНО ВЫРУБИТЬ
    /// </summary>
    internal interface IStunnable : ITargetable
    {
        /// <summary>
        /// Метод, оглушает объект
        /// </summary>
        /// <param name="rounds">Кол-во раундов оглушения</param>
        void SetStun(int rounds);
        /// <summary>
        /// Метод, защищает от оглушения
        /// </summary>
        /// <param name="active">Активно или нет</param>
        void SetProtectionFromStun(bool active);
        int StunRoundsCount { get; set; }
        bool IsProtectedFromStun { get; }
    }
}
