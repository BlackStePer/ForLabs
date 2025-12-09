using System;

namespace InternshipVUZ {
    internal class MobileApplicationDevelopment : Department {
        public MobileApplicationDevelopment(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        public override void TraineeDistribution(List<Student> candidates)
        {
            List<Student> _candidates = [.. candidates];
            foreach (Student student in _candidates)
            {
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (language.HasFlag(ProgrammingLanguage.Python))
                    if (student.Achievement >= 85)
                        if (TraineeDistribution(student))
                            candidates.Remove(student);
            }
        }
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ТЕЛЕФОННЫЙ ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }

    }
}
