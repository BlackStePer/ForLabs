using System;
using System.Collections.Generic;

namespace Chainise10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime st = DateTime.Now;
            School school = new School();
            List<Student> students = new List<Student>();
            for(int i = 0; i < 50000000; i++)
            {
                students.Add(new Student() { CountLunch = 1, CountPhone = 1, Number = i + 1 });
            }
            school.students = students;
            var (smin, smax) = school.FindMinMaxEmployee();
            DateTime e = DateTime.Now;
            Console.WriteLine((e - st).TotalSeconds);
            Console.ReadKey();
        }
    }
}
