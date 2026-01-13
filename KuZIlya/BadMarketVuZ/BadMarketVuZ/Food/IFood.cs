namespace BadMarketVuZ.Food
{
    internal interface IFood : IThing
    {
        int Calories { get; }
        double Proteins { get; }
        double Fats { get; }
        double Carbohydrates { get; }
        string IThing.Description => $"{Name} за {Price} рублей:\nКалории: {Calories}\nБелки: {Proteins}\nЖиры: {Fats}\nУглеводы: {Carbohydrates}";
    }
}
