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
        public MathAnalize(int passingScore) : base("Матааааан", false)
        {
            PassingScore = passingScore;
        }
        public override Exam exam { get; set; } = new Exam(85);
        public int PassingScore { get; set; }
    }
}
