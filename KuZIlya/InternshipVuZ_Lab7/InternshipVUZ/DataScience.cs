using System;

namespace InternshipVUZ {
    internal class DataScience : Department {
        public DataScience(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        private static Random random = new Random();
        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                if (random.Next(2) == 0)
                    continue;
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (language.HasFlag(ProgrammingLanguage.Dart))
                    if (student.CourseNumber == 3 && (student.Achievement >= 100 || student.Skill == Skill.Senior)) 
                        if (TraineeDistribution(student))
                        {
                            selectedСandidates.Add(student);
                            candidates.Remove(student);
                        }
            }
        }
        /// <summary>
        /// Возвращает УНИКАЛЬНЫХ-ДАТАСАЙЕНС студентов-добровольцев
        /// </summary>
        /// <returns>Строка. Состоит из студентов-добровольцев</returns>
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ДАТАСАЙЕНС ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }

    }
}
