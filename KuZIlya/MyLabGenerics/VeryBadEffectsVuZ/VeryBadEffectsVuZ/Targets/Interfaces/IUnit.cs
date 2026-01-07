using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using VeryBadEffectsVuZ.Potion;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;

namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    internal interface IUnit : IDamageable // Надо было абстрактным классом делать...
    {
        public string Avatar { get; }
        public int HP { get; set; }
        public int MaxHP { get; }
        public int Damage { get; set; }
        public int AttackRange { get; set; }
        public List<ISpellTarget<ITargetable>> Inventory { get; }
        public Castle MyCastle { get; init; }
        public string Update();
        public string Attack(IDamageable target)
        {
            int startHP = target.HP;
            target.TakeDamage(Damage);
            return $"{Name} НАНОСИТ {startHP - target.HP} УРОНА ПО {target.Name}!!!";
        }
        public string Move(int direction)
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
