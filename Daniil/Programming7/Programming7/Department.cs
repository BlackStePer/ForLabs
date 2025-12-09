using System;
using System.Collections.Generic;

namespace Programming7
{
    internal class Department
    {
        public string Title { get; set; }
        public List<Student> Trainees { get; set; } = new List<Student>();
        public int NumbreOfPositions { get; set; }

        public Department(string title, int num)
        {
            Title = title;
            NumbreOfPositions = num;
        }
        /// <summary>
        /// Проверяет, соответствует ли ученик требованиям департамента,
        /// если да, тозабирает его себе, удаляя из списка кандидатов
        /// </summary>
        /// <param name="candidates">Список желающих пройти отбор</param>
        public virtual void TraineeDistribution(List<Student> candidates)
        {

            List<Student> delete = new List<Student>();
            foreach(Student student in candidates)
            {
                if (student.CourseNumber >= 2)
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
        /// <summary>
        /// Возвращает строку с отчётом о департаменте
        /// </summary>
        /// <returns>Строка - отчёт о департаменте</returns>
        public string PrintTrainees()
        {
            string report = $"{Title} - {NumbreOfPositions}:\n";
            ;
            int count = 1;
            foreach (Student student in Trainees)
            {
                report += $"{count} - {student.Name}\n";
                count++;
            }
            return report;
        }
    }
}
