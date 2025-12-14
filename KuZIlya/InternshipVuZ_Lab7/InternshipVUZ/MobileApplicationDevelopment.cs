using System;

namespace InternshipVUZ {
    internal class MobileApplicationDevelopment : Department {
        public MobileApplicationDevelopment(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                if (student.Achievement >= 85 || student.Skill >= Skill.Middle)
                    if (TraineeDistribution(student))
                    {
                        selectedСandidates.Add(student);
                        candidates.Remove(student);
                    }
            }
        }
        /// <summary>
        /// Возвращает УНИКАЛЬНЫХ-ТЕЛЕФОННЫХ студентов-добровольцев
        /// </summary>
        /// <returns>Строка. Состоит из студентов-добровольцев</returns>
        public new string PrintTrainees()
        {
            string message = "СУПЕР-ДУПЕР НЕОБЫЧНЫЙ ТЕЛЕФОННЫЙ ВЫВОД СТУДЕНТОВ\n";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }

    }
}
