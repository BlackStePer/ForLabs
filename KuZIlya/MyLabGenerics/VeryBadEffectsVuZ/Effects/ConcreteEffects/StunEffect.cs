using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// Мощный ментальный или физический импульс, который временно разрывает связь разума с телом, погружая сознание цели в состояние полной дезориентации и неподвижности
    /// </summary>
    internal class StunEffect : IEffect<IStunnable>
    {
        public string Description => "ЗЕЛЬЕ РАЗОЧАРОВАНИЕ В СЕБЕ";
        public string Apply(IStunnable target, int power)
        {
            if (!target.IsProtectedFromStun)
            {
                target.SetStun(2);
                return $"{target.Name} РАЗОЧАРОВЫВАЕТСЯ В СЕБЕ И ОГЛУШАЕТСЯ НА {target.StunRoundsCount} ХОД(ОВ)!!!";
            }
            return $"ВЕЛИКИЙ НАШАТЫРЬ ЗАЩИТИЛ {target.Name} ОТ РАЗОЧАРОВАНИЯ!!!";
        }
    }
}
