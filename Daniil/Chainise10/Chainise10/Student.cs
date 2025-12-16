using System;

namespace Chainise10
{
    enum Position 
    {
        Preschooler,
        PrimarySchoolStudent,
        HighSchoolStudent
    }

    internal struct Student : IComparable<Student>
    {
        public int Number, CountPhone, CountLunch;
        public Position Position;

        /// <summary>
        /// Переопределение метода сравнения
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int CompareTo(Student student)
        {
            int result = this.CountPhone.CompareTo(student.CountPhone);
            if (result == 0)
            {
                return this.Position.CompareTo(student.Position);
            }
            return result;
        }

    }
}
