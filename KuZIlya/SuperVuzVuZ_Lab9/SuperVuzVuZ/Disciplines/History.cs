using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    /// <summary>
    /// История — это наука, изучающая прошлое человечества, а также сами события прошлого и память о них, включая сбор и анализ информации; это общий термин, охватывающий как гуманитарную науку, так и записи событий, а также историю вашего браузера или поиска в Google. Историческая наука исследует, как события развивались, а также используется для понимания современности через призму прошлого;
    /// </summary>
    internal class History : Discipline, IHavePractice, IHaveFinalControll {
        public History(int practiceCount, int passingScore) : base("История")
        {
            PracticeCount = practiceCount;
            PassingScore = passingScore;
        }
        public override Exam exam { get; set; } = new Exam(80);
        public int PracticeCount { get; set; } = 8;
        public int PassingScore { get; set; } = 70;
    }
}
