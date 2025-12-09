using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    /// <summary>
    /// Математический анализ (матан) — это раздел математики, изучающий функции, пределы, производные и интегралы, который лежит в основе многих наук, от физики до IT, позволяя моделировать изменения, оптимизировать процессы (например, в машинном обучении) и понимать сложные явления, используя такие инструменты как дифференциальное и интегральное исчисление, а также ряды. 
    /// </summary>
    internal class MathAnalize : Discipline, IHaveFinalControll {
        public MathAnalize(string name, int passingScore) : base(name, false)
        {
            PassingScore = passingScore;
        }
        public int PassingScore { get; set; }
    }
}
