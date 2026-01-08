using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects
{
    /// <summary>
    /// Класс, описывает эффект для заклинания
    /// </summary>
    /// <typeparam name="T">Тип цели (контрвариантно)</typeparam>
    internal interface IEffect<in T> : IHaveDescription where T : ITargetable
    {
        /// <summary>
        /// Метод, применяет эффект
        /// </summary>
        /// <param name="target">На кого применяется эффект</param>
        /// <param name="power">Сила эффекта</param>
        /// <returns></returns>
        string Apply(T target, int power);
    }
}
