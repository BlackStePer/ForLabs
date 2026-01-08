using VeryBadEffectsVuZ.Spells;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// Интерфейс, описывает юнита
    /// </summary>
    internal interface IUnit : IDamageable // Надо было абстрактным классом делать...
    {
        string Avatar { get; }
        int HP { get; set; }
        int MaxHP { get; }
        int Damage { get; set; }
        int AttackRange { get; set; }
        List<ISpellTarget<ITargetable>> Inventory { get; }
        Castle MyCastle { get; init; }
        /// <summary>
        /// Метод, помогает юниту восстанавливаться от дебафов
        /// </summary>
        /// <returns>Процесс восстановления объекта</returns>
        string Update();
        /// <summary>
        /// Метод, описывает атаку
        /// </summary>
        /// <param name="target">Цель атаки</param>
        /// <returns>Процесс атаки</returns>
        string Attack(IDamageable target)
        {
            int startHP = target.HP;
            target.TakeDamage(Damage);
            return $"{Name} НАНОСИТ {startHP - target.HP} УРОНА ПО {target.Name}!!!";
        }
        /// <summary>
        /// Метод, двигает объект
        /// </summary>
        /// <param name="direction">Направление; если > 0 то вперёд, иначе назад</param>
        /// <returns>Процесс движения</returns>
        string Move(int direction)
        {
            if (direction > 0)
            {
                Position++;
                return $"{Name} ДВИГАЕТСЯ ВПЕРЁД!!!";
            }
            if (direction < 0)
            {
                Position--;
                return $"{Name} ДВИГАЕТСЯ НАЗАД!!!";
            }
            return $"{Name} НЕ ДВИГАЕТСЯ!!!";
        }
    }
}
