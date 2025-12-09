using Programming7.Departments;
using Programming7.Deportments;
using System;
using System.Collections.Generic;

namespace Programming7
{
    internal class Traineeship
    {
        public List<Student> Candidates { get; set; }
        public List<Department> Departaments { get; set; }

        /// <summary>
        /// Метод создаёт отчёт о том, как распределятся ученики по департамента,
        /// при этом департаменты остаются пустыми, а список поданый в метод изменяется,
        /// поэтому нужно передавать копию
        /// </summary>
        /// <returns>Отчёт о распределении учеников</returns>
        public string Distribute()
        {
            string report = "";
            foreach (Department department in Departaments)
            {
                if (department is DataScience)
                {
                    DataScience dataScience = (DataScience)department;
                    dataScience.TraineeDistribution(Candidates);
                    report += dataScience.PrintTrainees() + "======================\n";

                }
                else if (department is GameDevelopment)
                {
                    GameDevelopment gameDevelopment = (GameDevelopment)department;
                    gameDevelopment.TraineeDistribution(Candidates);
                    report += gameDevelopment.PrintTrainees() + "======================\n";
                }
                else if (department is MobileApplicationDevelopment)
                {
                    MobileApplicationDevelopment mobileApplicationdDevelopment = (MobileApplicationDevelopment)department;
                    mobileApplicationdDevelopment.TraineeDistribution(Candidates);
                    report += mobileApplicationdDevelopment.PrintTrainees() + "======================\n";
                }
                else
                {
                    department.TraineeDistribution(Candidates);
                    report += department.PrintTrainees() + "======================\n";
                }
            }
            if (Candidates.Count > 0) 
            {
                report += "Остатки:\n";
                foreach (Student student in Candidates)
                {
                    report += student.ToString() + "\n";
                }
            }
            return report;
        }
    }
}
