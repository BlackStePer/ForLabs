using System;
using System.Collections.Generic;

namespace Programming7.Departments
{
    internal class MobileApplicationDevelopment : Department
    {
        public MobileApplicationDevelopment(string title, int num) : base(title, num)
        {
        }
        public override void TraineeDistribution(List<Student> candidates)
        {
            List<Student> delete = new List<Student>();
            foreach (Student student in candidates)
            {
                if (student.ProgrammingLanguage == ProgrammingLanguage.Dart && student.CourseNumber == 3
                    && student.Achievement >= 0.9)
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
                report += $"{count} - {student.Name} | {student.ProgrammingLanguage} | Курс: {student.CourseNumber}\n";
                count++;
            }
            return report;
        }
    }
}
