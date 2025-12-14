using System;

namespace Programming7
{
    internal class Student
    {
        public string Name { get; }
        public int CourseNumber { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public double Achievement { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Переопределённый метод ToString, для более приятного вывода
        /// </summary>
        /// <returns>Строка с данными о человеке</returns>
        public override string ToString()
        {
            return $"{Name} | Курс: {CourseNumber} | Язык программирования: {ProgrammingLanguage} | Успеваемость: {Achievement}";
        }
    }
}
