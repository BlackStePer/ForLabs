using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    internal class Programming : Discipline, IHavePractice {
        public Programming(string name, int practiceCount) : base(name)
        {
            PracticeCount = practiceCount;
        }
        public int PracticeCount { get; set; } = 15;
    }
}
