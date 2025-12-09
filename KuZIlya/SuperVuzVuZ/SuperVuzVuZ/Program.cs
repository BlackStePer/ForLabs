

using SuperVuzVuZ.Disciplines;
using SuperVuzVuZ.Interfaces;
using System.Xml.Linq;

namespace SuperVuzVuZ {
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<Discipline> disciplines = new List<Discipline>() { new English("Английский"), new History("История",10,70),new MathAnalize("МАТАН",100), new Programming("Программировние",52), new RussianLanguage("Русский Язык")};
            Student student1 = new Student("Костя");
            Student student2 = new Student("НЕКостя1");
            Student student3 = new Student("НЕКостя2");
            Student student4 = new Student("НЕКостя");
            List<Student> students = new List<Student>() { student2 , student3 };
            List<IHaveFinalControll> disciplinesWithExam = new List<IHaveFinalControll>();
            List<IHavePractice> disciplinesWithPractice = new List<IHavePractice>();
            foreach (var discipline in disciplines)
            {
                if (discipline is IHaveFinalControll)
                    disciplinesWithExam.Add((IHaveFinalControll)discipline);
                if (discipline is IHavePractice)
                    disciplinesWithPractice.Add((IHavePractice)discipline);
            }
            students.Add(student1);
            foreach (var student in students)
                if (student != student1)
                {
                    foreach (var discipline in disciplinesWithExam)
                        student.FinalControls[discipline] = random.Next(55, 101);
                    foreach (var discipline in disciplinesWithPractice)
                        student.Practices[discipline] = random.Next(0, 2) == 0 ? discipline.PracticeCount : random.Next(0, discipline.PracticeCount);
                }
                else
                {
                    foreach (var discipline in disciplinesWithExam)
                        student.FinalControls[discipline] = random.Next(20, 50);
                    foreach (var discipline in disciplinesWithPractice)
                        student.Practices[discipline] = random.Next(0, discipline.PracticeCount%5);
                }
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var discipline in disciplines)
                {
                    if (student == student1)
                    {
                        Console.WriteLine(discipline.Passed(student, out bool result));
                        if (!result)
                        {
                            Console.WriteLine("Однако ученик не отчаивается...\n" + $"{student.Name} предлагает предподавателю взятку в размере {random.Next(5, 53)} рублей ");
                            if (random.Next(1, 8) % 5 != 0)
                                Console.WriteLine("И предподаватель сжаливается И СТАВИТ АВТОМАТ!!!");
                            else
                                Console.WriteLine("Но предподаватель не сжаливается...");
                        }
                    }
                    else
                    {
                        Console.WriteLine(discipline.Passed(student, out bool result));
                        if (!result && random.Next(0, 2) == 0)
                            Console.WriteLine(student.GiveBribe(discipline));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}




