using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Spells
{
    /// <summary>
    /// Интерфейс, хранит информацию о цели заклинания
    /// </summary>
    /// <typeparam name="TTarget">Тип цели атаки (ковариантно)</typeparam>
    internal interface ISpellTarget<out TTarget> : IHaveDescription where TTarget : ITargetable
    {
        /// <summary>
        /// Может быть целью атаки
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true если может, иначе false</returns>
        bool CanTarget(ITargetable user);
        /// <summary>
        /// Может использовать атаку
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns>true если может, иначе false</returns>
        bool CanBeUsedBy(IUnit attacker);
        /// <summary>
        /// Метод, описывает использование заклинания
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Процесс использования заклинания</returns>
        string Use(ITargetable target);
    }
}
