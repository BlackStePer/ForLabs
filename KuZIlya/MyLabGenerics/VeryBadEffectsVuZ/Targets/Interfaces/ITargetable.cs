namespace VeryBadEffectsVuZ.Targets.Interfaces
{
    /// <summary>
    /// Интефейс, описывает восприимчивого к чему-либо человека
    /// </summary>
    internal interface ITargetable
    {
        string Name { get; }
        int Position { get; set; }
    }
}
