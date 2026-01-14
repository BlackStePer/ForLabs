using System;
using System.Collections.Generic;

namespace UHarchiLab.Contracts
{
    internal interface ICart<out T> where T : IFood
    {
        /// <summary>
        /// Создание сбалансированной корзины
        /// </summary>
        /// <param name="market">Магазин откуда брать товары</param>
        void CartBalansing(U_Market market);

        /// <summary>
        /// Возвращение списка товаров карзины
        /// </summary>
        /// <returns></returns>
        string GetGoodsList();

        /// <summary>
        /// Добавить продукт в корзину
        /// </summary>
        /// <param name="market">Маназин для товара</param>
        /// <param name="index">Айди товара</param>
        /// <returns></returns>
        string AddGood(U_Market market, int index);
    }
}
