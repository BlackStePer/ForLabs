

using SuperVuzVuZ.Disciplines;
using SuperVuzVuZ.Interfaces;

namespace SuperVuzVuZ {
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<Discipline> disciplines = Exam.disciplines[..];
            Student Kostya = new Student("Костя");
            Student student2 = new Student("НЕКостя1");
            Student student3 = new Student("НЕКостя2");
            Student student4 = new Student("НЕКостя3");
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
            students.Add(Kostya);
            foreach (var student in students)
                if (student != Kostya)
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
                    if (student == Kostya)
                    {
                        Console.WriteLine(discipline.Passed(student, out bool result));
                        if (!result)
                        {
                            Console.WriteLine("Однако ученик не отчаивается...\n" + $"{student.Name} предлагает предподавателю взятку в размере {random.Next(5, 53)} рублей ");
                            if (random.Next(1, 10) % 5 != 0)
                            {
                                Console.WriteLine("И предподаватель сжаливается И СТАВИТ АВТОМАТ!!!");
                                student.examIsPassed[discipline] = true;
                            }
                            else
                            {
                                Console.WriteLine("Но предподаватель не сжаливается...");
                                student.examIsPassed[discipline] = false;
                            }
                        }
                        else
                            student.examIsPassed[discipline] = result;
                    }
                    else
                    {
                        bool success = false;
                        Console.WriteLine(discipline.Passed(student, out bool result));
                        if (!result && random.Next(0, 2) == 0)
                            Console.WriteLine(student.GiveBribe(discipline, out success));
                        student.examIsPassed[discipline] = success || result;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Время экзаменов...");
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            foreach (var discipline in disciplines)
            {
                Console.WriteLine("ВРЕМЯ ЭКЗАМЕНОВ!!! - " + discipline.Name);
                foreach (var student in students[..])
                    if (!student.examIsPassed[discipline])
                    {
                        Console.WriteLine(discipline.exam.StartExam(student, discipline, out bool success));
                        if (!success)
                            students.Remove(student);
                    }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}




