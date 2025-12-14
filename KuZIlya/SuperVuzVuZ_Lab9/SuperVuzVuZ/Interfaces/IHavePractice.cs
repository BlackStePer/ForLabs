using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Interfaces {
    /// <summary>
    /// У дисциплин реализующих данный интерфейс должны оцениваться практические задания
    /// </summary>
    internal interface IHavePractice {
        public int PracticeCount { get; set; }
        /// <summary>
        /// Выполнил ли студент все практические занятия
        /// </summary>
        /// <param name="count">Кол-во выполненных практических заданий</param>
        /// <returns>true если посетил, иначе false</returns>
        public bool Check(int count) => PracticeCount == count;
    }
}
