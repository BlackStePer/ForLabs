namespace BadMarketVuZ.Food.ISemiFinishedFood.ConcreteSemiFinishedFood
{
    internal record Dumplings : ISemiFinishedFood
    {
        public int Calories => 1800;

        public string Name => "ПАЧКА ПЕЛЬМЕШЕК";

        public double Proteins => 72.0;

        public double Fats => 96.0;

        public double Carbohydrates => 160.0;

        public int Price => 600;
    }
}
