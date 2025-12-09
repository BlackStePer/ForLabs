using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Interfaces {
    /// <summary>
    /// У дисциплин реализующих данный интерфейс должен быть контрольный тест
    /// </summary>
    internal interface IHaveFinalControll {
        public int PassingScore { get; set; }
        /// <summary>
        /// Сдал ли студент тест на достаточный балл
        /// </summary>
        /// <param name="count">Кол-во баллов студента</param>
        /// <returns>true если набрал, иначе false</returns>
        public bool Check(int count) => PassingScore <= count;
    }
}
