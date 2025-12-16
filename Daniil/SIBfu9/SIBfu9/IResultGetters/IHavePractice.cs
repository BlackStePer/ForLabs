using System;

namespace SIBfu9.IResultGetters
{
    internal interface IHavePractice
    {
        int PracticeCount { get; }

        /// <summary>
        /// Проверка посетил ли ученик достаточно занятий
        /// </summary>
        /// <param name="count">Посещения ученика</param>
        /// <returns>Достаточно или нет</returns>
        bool Check(int count);
    }
}
