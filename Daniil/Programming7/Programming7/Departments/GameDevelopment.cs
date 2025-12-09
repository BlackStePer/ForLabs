using System;
using System.Collections.Generic;

namespace Programming7.Deportments
{
    internal class GameDevelopment : Department
    {
        public GameDevelopment(string title, int num) : base(title, num)
        {

        }
        public override void TraineeDistribution(List<Student> candidates)
        {
            List<Student> delete = new List<Student>();
            foreach (Student student in candidates)
            {
                if ((student.ProgrammingLanguage == ProgrammingLanguage.Cpp || student.ProgrammingLanguage == ProgrammingLanguage.Cs)
                    && student.CourseNumber >= 2 && student.Achievement >= 0.8)
                {
                    Trainees.Add(student);
                    delete.Add(student);
                }
            }
            while (delete.Count > 0)
            {
                candidates.Remove(delete[0]);
                delete.RemoveAt(0);
            }
        }
        public new string PrintTrainees()
        {
            string report = $"{Title} - {NumbreOfPositions}:\n";
            int count = 1;
            foreach (Student student in Trainees)
            {
                report += $"{count} - {student.Name} | {student.Achievement}\n";
                count++;
            }
            return report;
        }
    }
}
