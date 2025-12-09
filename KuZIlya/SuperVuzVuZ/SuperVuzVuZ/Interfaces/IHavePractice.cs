using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Interfaces {
    internal interface IHavePractice {
        public int PracticeCount { get; set; }
        public bool Check(int count) => PracticeCount == count;
    }
}
