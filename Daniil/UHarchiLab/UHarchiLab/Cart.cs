using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using UHarchiLab.Contracts;

namespace UHarchiLab
{
    /// <summary>
    /// Карзина с товарами пользователя
    /// </summary>
    /// <typeparam name="T">Тип товара</typeparam>
    internal class Cart<T> : ICart<T> where T : IFood
    {
        public List<T> Foodstuffs { get; set; } = new List<T>();

        Random rnd = new Random();

        /// <summary>
        /// Добавляет продукт из магазина, если не достает БЖУ
        /// </summary>
        /// <param name="market">Магазин</param>
        public void CartBalansing(U_Market market)
        {
            int[] PFC = { 0, 0, 0 };

            foreach (T product in Foodstuffs)
            {
                if(product.Proteins)
                    PFC[0]++;
                if (product.Fats)
                    PFC[1]++;
                if (product.Carbohydrates)
                    PFC[2]++;
            }

            if (PFC[0] == 0) 
            {
                List<T> needs = market.Things.OfType<T>().Where(x => x.Proteins).ToList();
                Foodstuffs.Add(needs[rnd.Next(needs.Count)]);
            }
            if (PFC[1] == 0)
            {
                List<T> needs = market.Things.OfType<T>().Where(x => x.Fats).ToList();
                Foodstuffs.Add(needs[rnd.Next(needs.Count)]);
            }
            if (PFC[2] == 0)
            {
                List<T> needs = market.Things.OfType<T>().Where(x => x.Carbohydrates).ToList();
                Foodstuffs.Add(needs[rnd.Next(needs.Count)]);
            }
        }

        /// <summary>
        /// Возврат списка покупок
        /// </summary>
        /// <returns>Список покупок</returns>
        public string GetGoodsList()
        {
            string temp = "";
            int count = 1;
            foreach(IFood good in Foodstuffs)
            {
                temp += $"{count} - {good.Name}\n";
                count++;
            }
            return temp;
        }

        /// <summary>
        /// Добавить продукт в список
        /// </summary>
        /// <param name="market">Магазин</param>
        /// <param name="index">Индекс товара в магазине</param>
        /// <returns>Сообщение об успешности операции</returns>
        public string AddGood(U_Market market, int index)
        {
            try
            {
                if (market.Things[index - 1] is T)
                {
                    Foodstuffs.Add((T)market.Things[index - 1]);
                    return $"{market.Things[index - 1].Name} в корзине";
                }
                else
                {
                    return $"{market.Things[index - 1].Name} не подходит для вашей козины";
                }
            }
            catch (IndexOutOfRangeException)
            {
                return "Не корректный выбор";
            }
        }
    }
}
