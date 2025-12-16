using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainise10
{
    internal class School
    {
        public List<Student> students = new List<Student>();

        public (Student, Student) FindMinMaxEmployee()
        {
            students.Sort();
            Student minSt = students.First();
            Student maxSt = students.Last();
            return (minSt, maxSt);
        }

        /// <summary>
        /// Забирет еду у худшего, отдавая лучшему
        /// </summary>
        /// <param name="touple">Кортеж из двух китайцев</param>
        /// <returns>Массив с изменёнными китайцами</returns>
        public (Student, Student) Reward((Student minS, Student maxS) touple)
        {
            Student minS = touple.minS;
            Student maxS = touple.maxS;

            maxS.CountLunch += minS.CountLunch;
            minS.CountLunch = 0;

            return (minS, maxS);
        }
    }
}
