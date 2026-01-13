using BadMarketVuZ.Food;
using BadMarketVuZ.Food.HealthyFood;
using BadMarketVuZ.Food.Snacks;

namespace BadMarketVuZ.Trash
{
    internal class Cart
    {
        public List<IThing> CartInventory { get; set; } = [];
        /// <summary>
        /// Показывает информацию о всём питательном в корзине
        /// </summary>
        /// <param name="message">Возвращает сообщение о всём питательном в корзине</param>
        /// <returns>Кортеж с базовой информацией</returns>
        public (int price, int calories, double proteins, double fats, double carbohydrates) ShowBasicFoodInfo(out string message)
        {
            int calories = 0;
            double proteins = 0;
            double fats = 0;
            double carbohydrates = 0;
            int price = 0;
            foreach (IFood item in ShowConcreteCartItems<IFood>())
            {
                calories += item.Calories;
                proteins += item.Proteins;
                fats += item.Fats;
                carbohydrates += item.Carbohydrates;
                price += item.Price;
            }
            message = $"За {price} рублей у вас собралась корзина:\nКалории: {calories}\nБелки: {proteins}\nЖиры: {fats}\nУглеводы: {carbohydrates}";
            return (price, calories, proteins, fats, carbohydrates);
        }
        public List<TProduct> ShowConcreteCartItems<TProduct>() where TProduct : IThing
        {
            List<TProduct> products = [];
            foreach (IThing item in CartInventory)
                if (item is TProduct concreteProduct)
                    products.Add(concreteProduct);
            return products;
        }
        public int ShowFoodFactor(IFood food)
        {
            int factor = 0;
            if (food is ISnacks snack)
                factor -= snack.HarmFactor;
            if (food is IHealthyFood healthyFood)
                factor += healthyFood.BenefitFactor;
            return factor;
        }
        public override string ToString()
        {
            string message = "";
            foreach (IThing item in CartInventory)
                message += item + "\n";
            return message;

        }
    }
}
