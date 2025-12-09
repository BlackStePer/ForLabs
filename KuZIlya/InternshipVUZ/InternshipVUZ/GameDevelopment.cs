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
            List<Student> _candidates = candidates[..];
            foreach (Student student in _candidates)
            {
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (language.HasFlag(ProgrammingLanguage.CSharp) || language.HasFlag(ProgrammingLanguage.Cpp))
                    if (student.CourseNumber >= 2 && student.Achievement >= 80)
                        if (TraineeDistribution(student))
                            candidates.Remove(student);
            }
        }
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ГЕЙМ ДЕВЕЛОПМЕНТ ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }


    }
}
