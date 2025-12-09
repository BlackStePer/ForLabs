using System;

namespace InternshipVUZ {
    internal class DataScience : Department {
        public DataScience(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        public override void TraineeDistribution(List<Student> candidates)
        {
            List<Student> _candidates = new List<Student>(candidates);
            foreach (Student student in _candidates)
            {
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (language.HasFlag(ProgrammingLanguage.Dart))
                    if (student.CourseNumber == 3 && student.Achievement >= 90)
                        if (TraineeDistribution(student))
                            candidates.Remove(student);
            }
        }
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ДАТАСАЙЙЕНС ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }

    }
}
