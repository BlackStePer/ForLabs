using BadMarketVuZ.Food;
using BadMarketVuZ.Food.HealthyFood;
using BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood;
using BadMarketVuZ.Food.ISemiFinishedFood;
using BadMarketVuZ.Food.Snacks;

namespace BadMarketVuZ
{
    internal class Human
    {
        public Cart Cart { get; private set; } = new();
        public List<IFood> Fridge { get; set; } = [];
        public List<IThing> Inventory { get; set; } = [];
        public int CurrentHealthFactor { get; set; } = 5;
        public int Money { get; set; } = 1000;
        public int CaloriesPerDay { get; private set; } = 2500;
        public const int requiredCaloriesPerDay = 2500;
        public double Proteins { get; private set; } = 800;
        public double Fats { get; private set; } = 600;
        public double Carbohydrates { get; private set; } = 2400;
        public int RateOfHappiness { get; private set; } = 100;
        public void ChangeRateOfHappiness(int amount)
        {
            RateOfHappiness += amount;
            if (RateOfHappiness > 100)
                RateOfHappiness = 100;
            if (RateOfHappiness < 0)
                RateOfHappiness = 0;
        }
        public void StartANewDay()
        {
            if (CaloriesPerDay > 0)
            {
                RateOfHappiness -= CaloriesPerDay / 100;
                CurrentHealthFactor -= CaloriesPerDay / 1000;
            }
            CaloriesPerDay = requiredCaloriesPerDay;
        }
        public void EatFood(IFood food)
        {
            CaloriesPerDay = CaloriesPerDay - food.Calories > 0 ? CaloriesPerDay - food.Calories : 0;
            Proteins -= food.Proteins;
            Fats -= food.Fats;
            Carbohydrates -= food.Carbohydrates;
            if (food is ISnacks snack)
            {
                CurrentHealthFactor -= snack.HarmFactor;
                ChangeRateOfHappiness(10);
            }
            if (food is IHealthyFood healthyfood)
            {
                CurrentHealthFactor += healthyfood.BenefitFactor;
                if (healthyfood is OliveOil)
                    ChangeRateOfHappiness(-100);
                else
                    ChangeRateOfHappiness(-10);
            }
            if (food is ISemiFinishedFood)
                ChangeRateOfHappiness(15);
        }
        public string BuyProduct(IThing thing)
        {
            if (thing == null || thing.Price > Money)
                return "Неудача";
            Cart.cart.Add(thing);
            return $"Процесс приобретения {thing.Name} успешен!!!";
        }
        public override string ToString() => $"Вам нужно скушать еще {CaloriesPerDay} ккал еды...";
    }
}
