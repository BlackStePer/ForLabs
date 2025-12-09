using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    internal class History : Discipline, IHavePractice, IHaveFinalControll {
        public History(string name, int practiceCount, int passingScore) : base(name)
        {
            PracticeCount = practiceCount;
            PassingScore = passingScore;

        }
        public int PracticeCount { get; set; } = 8;
        public int PassingScore { get; set; } = 70;
    }
}
