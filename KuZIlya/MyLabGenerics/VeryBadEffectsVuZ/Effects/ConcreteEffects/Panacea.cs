using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// В мифологии и алхимии, панацея — это универсальное средство, способное вылечить все травмы и болезни
    /// </summary>
    internal class Panacea : IEffect<IHealable>
    {
        public string Description => "ПАНАЦЕЯ";
        public string Apply(IHealable target, int power)
        {
            target.Heal(1000);
            if (target is IStunnable stunTarget)
            {
                stunTarget.SetProtectionFromStun(true);
                stunTarget.StunRoundsCount = 0;
            }
            if (target is IPoisonable poisonTarget)
                poisonTarget.PoisonedMovesCount = 0;
            if (target is IBurnable burnTarget)
                burnTarget.BurnMovesCount = 0;
            return $"ПАНАЦЕЯ ПОЛНОСТЬЮ ИЗЛЕЧИВАЕТ {target.Name} И СНИМАЕТ ВСЕ ЕГО НЕГАТИВНЫЕ ЭФФЕКТЫ!!!";
        }
    }
}
