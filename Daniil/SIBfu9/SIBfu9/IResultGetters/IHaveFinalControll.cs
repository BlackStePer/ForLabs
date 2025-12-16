using System;

namespace SIBfu9.IResultGetters
{
    internal interface IHaveFinalControll
    {
        int PassingScore { get; }

        /// <summary>
        /// Проверка прошёл ли ученик успешно контроль
        /// </summary>
        /// <param name="count">Результат ученика</param>
        /// <returns>Прошёл или нет</returns>
        bool Check(int count);
    }
}
