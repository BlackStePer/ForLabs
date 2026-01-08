using VeryBadEffectsVuZ.Targets.Interfaces;

namespace VeryBadEffectsVuZ.Spells
{
    /// <summary>
    /// Интерфейс, хранит инфорацию об атакующем кого-либо юните
    /// </summary>
    /// <typeparam name="TAttacker">Тип нападающего (ковариантно)</typeparam>
    internal interface ISpellAttacker<out TAttacker> : IHaveDescription where TAttacker : IUnit
    {
    }
}
