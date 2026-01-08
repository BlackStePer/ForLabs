using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// Большой быстропадающий камень
    /// </summary>
    internal class RockEffect : IEffect<IDamageable>
    {
        public string Description => "МАААААААААААААААААААААААААААЛЕНЬКИЙ КИРПИЧЕК";
        public string Apply(IDamageable target, int power)
        {
            string message = "";
            int startHP = target.HP;
            target.TakeDamage(power);
            message += $"{Description} ПАДАЕТ НА ГОЛОВУ {target.Name} И НАНОСИТ ЕМУ {startHP - target.HP} ЕДЕНИЦ УРОНА!!!\n";
            if (target is IStunnable stunTarget)
            {
                if (!stunTarget.IsProtectedFromStun)
                {
                    stunTarget.SetStun(2);
                    message += $"+ ОГЛУШАЕТ ЕГО НА {stunTarget.StunRoundsCount} ХОД(ОВ)";
                }
                else
                    message += $"ОДНАКО НАШАТЫРЬ ЗАЩИЩАЕТ {target.Name} ОТ ОГЛУШЕНИЯ!!!";
            }
            return message;
        }
    }
}
