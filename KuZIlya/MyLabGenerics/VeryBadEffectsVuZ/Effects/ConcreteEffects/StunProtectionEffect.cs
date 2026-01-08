using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Effects.ConcreteEffects
{
    /// <summary>
    /// Несокрушимый ментальный барьер или физическая закалка, которые делают сознание и тело невосприимчивыми к любым попыткам прервать их контроль и дезориентировать существо
    /// </summary>
    internal class StunProtectionEffect : IEffect<IStunnable>
    {
        public string Description => "НАШАТЫРНЫЙ СПИРТ";
        public string Apply(IStunnable target, int power)
        {
            target.SetProtectionFromStun(true);
            return $"НАШАТЫРЬ ЗАЩИЩАЕТ {target.Name} ОТ ЛЮБОГО ВИДА ОГЛУШЕНИЯ!!!";
        }
    }
}
