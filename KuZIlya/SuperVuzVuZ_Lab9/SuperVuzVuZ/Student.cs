using SuperVuzVuZ.Disciplines;
using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ {
    /// <summary>
    /// Класс, описывающий главного страдальца этой вселенной - обычного студента
    /// </summary>
    internal class Student {
        private static Random random = new Random();
        public string Name { get; set; }
        public Student(string name)
        {
            Name = name;
            foreach (var discipline in Exam.disciplines)
                isReadyForExam[discipline] = random.Next(2) == 1;
        }
        public Dictionary<IHavePractice, int> Practices = new();
        public Dictionary<IHaveFinalControll, int> FinalControls = new();
        public Dictionary<Discipline, bool> examIsPassed = new();
        public Dictionary<Discipline, bool> isReadyForExam = new();
        /// <summary>
        /// Дать взятку проподавателю за автомат
        /// </summary>
        /// <param name="discipline">Любая дисциплина</param>
        /// <param name="success">Возвращает true если успешно, иначе false</param>
        /// <param name="isExam">На экзамене ли студент</param>
        /// <returns>Сообщение об успешной/безуспешной попытке подкупить препода</returns>
        public string GiveBribe(Discipline discipline, out bool success, bool isExam = false)
        {
            string message = "";
            success = false;
            int bribe = random.Next(20000);
            for (int i = 0; i < 4; i++)
            {
                bribe += random.Next(20000) * (i + 1);
                message += ((i == 0)? "Однако ученик не отчаивается...\n" : null) + $"{Name} предлагает предподавателю взятку в размере {bribe} рублей ";
                if (bribe >= discipline.Bribe) {
                    message += isExam? "И ОН ПОЛУЧАЕТ АВТОМАТ!!!! " : "";
                    success = true;
                    break;
                }
                else
                {
                    message +=  "НО У НЕГО НИЧЕГО НЕ ПОЛУЧАЕТСЯ!!! ";
                    if (random.Next(0, 2) == 1)
                    {
                        if (isExam)
                            if (random.Next(0, 2) == 1) // Нужен ДОДЭЭЭП
                                break;
                        break;
                    }
                }
            }
            return message;
        }
    }
}
