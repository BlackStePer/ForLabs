using SuperVuzVuZ.Disciplines;
using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ {
    internal class Student {
        private static Random random = new Random();
        public string Name { get; set; }
        public Student(string name) => Name = name;
        public Dictionary<IHavePractice, int> Practices = new();
        public Dictionary<IHaveFinalControll, int> FinalControls = new();
        public string GiveBribe(Discipline discipline)
        {
            string message = "";
            int bribe = random.Next(20000);
            for (int i = 0; i < 4; i++)
            {
                bribe += random.Next(20000) * (i + 1);
                message += ((i == 0)? "Однако ученик не отчаивается...\n" : null) + $"{Name} предлагает предподавателю взятку в размере {bribe} рублей ";
                if (bribe >= discipline.Bribe) {
                    message += "И ОН ПОЛУЧАЕТ АВТОМАТ!!!! ";
                    break;
                }
                else
                {
                    message += "НО У НЕГО НИЧЕГО НЕ ПОЛУЧАЕТСЯ!!! ";
                    if (random.Next(0, 2) == 1)
                        break;
                }
            }
            return message;
        }
    }
}
