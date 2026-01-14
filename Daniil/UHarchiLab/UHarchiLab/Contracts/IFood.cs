using System;

namespace UHarchiLab
{
    /// <summary>
    /// Объект является едой
    /// </summary>
    internal interface IFood : Ithing
    {
        bool Proteins { get; }
        bool Fats { get; }
        bool Carbohydrates { get; }
    }
}
