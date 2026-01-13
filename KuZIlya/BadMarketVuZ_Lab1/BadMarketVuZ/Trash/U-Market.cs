using BadMarketVuZ.Food;
using BadMarketVuZ.Food.HealthyFood.ConcreteHealthyFood;
using BadMarketVuZ.Food.ISemiFinishedFood.ConcreteSemiFinishedFood;
using BadMarketVuZ.Food.Snacks.ConcreteSnacks;
using System.Reflection;
using System.Text.Json;

namespace BadMarketVuZ.Trash
{
    /// <summary>
    /// Магазин, принадлежит сфу, стрёмное место...
    /// </summary>
    internal class U_Market
    {
        private static readonly string[] Nutrients = { "Proteins", "Fats", "Carbohydrates" };
        private static List<IThing> assortment = [new ChocolateBar(), new Chips(), new BalykCheeze(), new Apple(), new Chicken(), new OliveOil(), new Sushi(), new Cheburek(), new Dumplings()];
        public static List<IThing> Assortment => JsonSerializer.Deserialize<List<IThing>>(JsonSerializer.Serialize(assortment));
        /// <summary>
        /// Кладёт конкретные товары в корзину конкретного человека
        /// </summary>
        /// <param name="human">Конкретный человек</param>
        /// <param name="things">Конкретные товары</param>
        public void PutInBusket(Human human, params List<IThing> things) => human.Cart.CartInventory.AddRange(things);
        /// <summary>
        /// Показывает ассортимент магазина в кокретной области (снэки, норм еда, не норм еда)
        /// </summary>
        /// <typeparam name="TProduct">Конкретная область</typeparam>
        /// <returns>Список, содержащий ассортимент</returns>
        public List<TProduct> ShowConcreteMarketAssortment<TProduct>() where TProduct : IThing
        {
            List<TProduct> products = [];
            foreach (IThing item in Assortment)
                if (item is TProduct concreteProduct)
                    products.Add(concreteProduct);
            return products;
        }
        /// <summary>
        /// Даёт человеку товар, который максимально помогает с балансированием белков, жиров и углеводов
        /// </summary>
        /// <typeparam name="TProduct">Из какой категории выбирается нужный товар</typeparam>
        /// <param name="human">Объект человека, которому предлагается еда</param>
        /// <returns>Интерфейсная ссылка на объект еды</returns>
        public IFood GiveBestRecommendation<TProduct>(Human human) where TProduct : IFood
        {
            assortment = assortment; // Чтобы CodeCleanup не убрал
            Dictionary<string, double> deficiency = [];
            (int price, int calories, double proteins, double fats, double carbohydrates) = human.Cart.ShowBasicFoodInfo(out _);
            int lastPrice = price;
            deficiency["Proteins"] = human.Proteins - proteins;
            deficiency["Fats"] = human.Fats - fats;
            deficiency["Carbohydrates"] = human.Carbohydrates - carbohydrates;
            IFood bestProduct = null;
            double minScore = double.MaxValue;
            foreach (TProduct product in ShowConcreteMarketAssortment<TProduct>())
            {
                IFood food = product;
                double currentScore = 0;
                Type type = typeof(IFood);
                foreach (string nutrient in Nutrients)
                {
                    PropertyInfo prop = type.GetProperty(nutrient);
                    double productValue = (double)prop.GetValue(food);
                    double neededValue = deficiency[nutrient];
                    currentScore += Math.Pow(neededValue - productValue, 2); // Евклидово расстояние
                }
                if (currentScore < minScore)
                {
                    minScore = currentScore;
                    bestProduct = food;
                }
            }
            return bestProduct;
        }
    }
}
