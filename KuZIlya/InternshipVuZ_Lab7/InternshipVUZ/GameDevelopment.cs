using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipVUZ {
    internal class GameDevelopment : Department {
        public GameDevelopment(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (language.HasFlag(ProgrammingLanguage.CSharp) || language.HasFlag(ProgrammingLanguage.Cpp))
                    if (student.CourseNumber >= 2 && (student.Achievement >= 80 || student.Skill >= Skill.Middle))
                        if (TraineeDistribution(student))
                        {
                            selectedСandidates.Add(student);
                            candidates.Remove(student);

                        }
            }
        }
        /// <summary>
        /// Возвращает УНИКАЛЬНЫХ-ИГРОМАНОВ студентов-добровольцев
        /// </summary>
        /// <returns>Строка. Состоит из студентов-добровольцев</returns>
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ГЕЙМ ДЕВЕЛОПМЕНТ ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }


    }
}
