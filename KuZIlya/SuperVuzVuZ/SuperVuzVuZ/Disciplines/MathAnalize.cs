using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    internal class MathAnalize : Discipline, IHaveFinalControll {
        public MathAnalize(string name, int passingScore) : base(name, false)
        {
            PassingScore = passingScore;
        }
        public int PassingScore { get; set; }
    }
}
