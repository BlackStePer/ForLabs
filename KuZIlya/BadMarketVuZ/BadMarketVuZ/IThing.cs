using BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood;
using BadMarketVuZ.Food.ISemiFinishedFood.ConcreteSemiFinishedFood;
using BadMarketVuZ.Food.Snacks.ConcreteSnacks;
using System.Text.Json.Serialization;

namespace BadMarketVuZ
{
    [JsonDerivedType(typeof(Apple), 1)]
    [JsonDerivedType(typeof(Chicken), 2)]
    [JsonDerivedType(typeof(OliveOil), 3)]
    [JsonDerivedType(typeof(Cheburek), 4)]
    [JsonDerivedType(typeof(Dumplings), 5)]
    [JsonDerivedType(typeof(Sushi), 6)]
    [JsonDerivedType(typeof(BalykCheeze), 7)]
    [JsonDerivedType(typeof(Chips), 8)]
    [JsonDerivedType(typeof(ChocolateBar), 9)]
    internal interface IThing
    {
        string Name { get; }
        int Price { get; }
        string Description { get; }
    }
}
