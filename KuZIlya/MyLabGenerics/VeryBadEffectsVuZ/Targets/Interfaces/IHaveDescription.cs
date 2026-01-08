namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// Интерфейс, говорит что об объекте есть что рассказать...
    /// </summary>
    internal interface IHaveDescription
    {
        /// <summary>
        /// Описание чего-либо
        /// </summary>
        string Description { get; }
    }
}
