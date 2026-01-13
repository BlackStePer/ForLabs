namespace BadMarketVuZ.Food.ISemiFinishedFood.ConcreteSemiFinishedFood
{
    internal record Cheburek : ISemiFinishedFood
    {
        public int Calories => 481;

        public string Name => "ЧЕБУРЕЧЕК";

        public double Proteins => 16.2;

        public double Fats => 27.0;

        public double Carbohydrates => 43.2;

        public int Price => 150;
    }
}
