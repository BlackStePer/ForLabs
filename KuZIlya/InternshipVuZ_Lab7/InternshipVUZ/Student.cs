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
        JavaScript = 32,
    }
    public enum Skill
    {
        None,
        Junior,
        Middle,
        Senior
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
        public int CourseNumber { get; set; }
        /// <summary>
        /// Изученные студентом языки.
        /// </summary>
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        /// <summary>
        /// Успеваемость студента.
        /// </summary>
        public double Achievement { get; private set; }
        public Skill Skill { get; set; }
        public Student(string name, int courseNumber, ProgrammingLanguage programmingLanguage, double achievement, Skill skill = Skill.Junior)
        {
            Name = name ?? "default name";
            CourseNumber = courseNumber;
            ProgrammingLanguage = programmingLanguage;
            Achievement = achievement;
            Skill = skill;
        }
        /// <summary>
        /// Изменить успеваемость
        /// </summary>
        /// <param name="newAchievement">На сколько улучшить успеваемость</param>
        public void ImproveAchievement(double achievement)
        {
            Achievement += achievement;
            if (Achievement > 100)
                Achievement = 100;
        }
        /// <summary>
        /// Улучшить навык
        /// </summary>
        /// <returns>Конечный навык студента</returns>
        public Skill ImproveSkill()
        {
            if (Skill != Skill.Senior)
                Skill++;
            return Skill;
        }
        public override string ToString() => $"{Name} {CourseNumber} курс. Освоенные языки {ProgrammingLanguage}. Успеваемость: {Achievement} и скиллы {Skill}";
    }
}

