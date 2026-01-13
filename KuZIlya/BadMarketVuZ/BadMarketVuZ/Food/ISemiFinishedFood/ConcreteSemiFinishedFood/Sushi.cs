namespace BadMarketVuZ.Food.ISemiFinishedFood.ConcreteSemiFinishedFood
{
    internal record Sushi : ISemiFinishedFood
    {
        public int Calories => 1032;
        public string Name => "СЕТ СУШЕЙ";
        public double Proteins => 35.0;
        public double Fats => 28.0;
        public double Carbohydrates => 160.0;
        public int Price => 1500;
    }
}
