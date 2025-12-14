using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    /// <summary>
    /// Программирование — это процесс создания компьютерных программ и приложений путем написания инструкций на специальных языках программирования, которые управляют действиями компьютера, автоматизируют задачи и решают сложные проблемы, от веб-сайтов и игр до научных расчетов и систем безопасности. Это искусство, требующее изучения алгоритмов, структур данных и постоянного обучения
    /// </summary>
    internal class Programming : Discipline, IHavePractice {
        public Programming(int practiceCount) : base("Программирование")
        {
            PracticeCount = practiceCount;
        }
        public override Exam exam { get; set; } = new Exam(52);
        public int PracticeCount { get; set; } = 15;
    }
}
