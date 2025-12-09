using System;

namespace InternshipVUZ {
    /// <summary>
    /// Языки, которые рассматриваются при зачислении на стажировку.
    /// </summary>
    [Flags]
    public enum ProgrammingLanguage 
    {
        None = 0,
        Cpp = 1,        // C++
        CSharp = 2,     // C#
        Python = 4,
        Dart = 8,
        Java = 16,
        JavaScript = 32
    }
    /// <summary>
    /// Класс, описывающий студента, желающего стажироваться.
    /// </summary>
    internal class Student {
        /// <summary>
        /// Имя студента.
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Курс на котором находится студент.
        /// </summary>
        public int CourseNumber { get; init; }
        /// <summary>
        /// Изученные студентом языки.
        /// </summary>
        public ProgrammingLanguage ProgrammingLanguage { get; init; }
        /// <summary>
        /// Успеваемость студента.
        /// </summary>
        public double Achievement { get; private set; }
        public Student(string name, int courseNumber, ProgrammingLanguage programmingLanguage, double achievement)
        {
            Name = name ?? "default name";
            CourseNumber = courseNumber;
            ProgrammingLanguage = programmingLanguage;
            Achievement = achievement;
        }
        /// <summary>
        /// Изменить успеваемость.
        /// </summary>
        /// <param name="newAchievement">Новая успеваемость</param>
        public void ImproveAchievement(double newAchievement) => Achievement = newAchievement;
        public override string ToString() => $"{Name} {CourseNumber} курс. Освоенные языки {ProgrammingLanguage}. Успеваемость: {Achievement}";
    }
}

