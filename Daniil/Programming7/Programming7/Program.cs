using Programming7.Departments;
using Programming7.Deportments;
using System;
using System.Collections.Generic;

namespace Programming7
{
    enum ProgrammingLanguage
    {
        Cpp,
        Cs,
        Python,
        Dart,
        Java,
        JavaScript
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() 
            { new Student("Боб", 2, ProgrammingLanguage.Cs, 0.5),
            new Student("Роб", 3, ProgrammingLanguage.Cs, 0.9),
            new Student("Лоб", 3, ProgrammingLanguage.Cpp, 0.91),
            new Student("Соб", 3, ProgrammingLanguage.Dart, 0.92),
            new Student("Тоб", 3, ProgrammingLanguage.Python, 0.93),
            new Student("Доб", 1, ProgrammingLanguage.Cpp, 0.1)
            },
            studentsCopy = new List<Student>();

            foreach (Student student in students) 
            {
                studentsCopy.Add(student);
            }


            DataScience dataScience = new DataScience("Базеры", 52);
            GameDevelopment gameDevelopment = new GameDevelopment("Геймеры", 69);
            MobileApplicationDevelopment mobileApplicationDevelopment = new MobileApplicationDevelopment("Мобильщики", 666);
            Department department = new Department("Пустышки", 228);

            Traineeship traineeship = new Traineeship();
            traineeship.Candidates = studentsCopy;
            traineeship.Departaments = new List<Department> { mobileApplicationDevelopment, dataScience, gameDevelopment, department };

            Console.WriteLine(traineeship.Distribute());

        }
    }
}
