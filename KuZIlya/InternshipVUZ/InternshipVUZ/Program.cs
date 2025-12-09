


#define MyStudents
namespace InternshipVUZ {

    internal class Program
    {
        public static void Main(string[] args)
        {
            #region Students
#if MyStudents
            Student student1 = new Student("БОБ1", 2, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.Dart, 100);
            Student student2 = new Student("БОБ2", 3, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.Dart, 50);
            Student student3 = new Student("БОБ3", 4, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.Dart, 80);
            Student student4 = new Student("БОБ4", 3, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python, 85);
            Student student5 = new Student("БОБ5", 3, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.Dart, 90);
            Student student6 = new Student("БОБ6", 3, ProgrammingLanguage.Python, 99);
            Student denchik = new Student("Даниил", 1, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.CSharp, 0);
            List<Student> students = new List<Student>() { student1 , student2 , student3 , student4, student5, student6 };
#endif
#endregion

            var dataScience = new DataScience("ДАТА САЙЕНС",2);
            var gameDev = new GameDevelopment("ГЕЙМ ДЕВЕЛОПМЕНТ",2);
            var mobila = new MobileApplicationDevelopment("что-то про телефоны",1);
            try
            {
                //dataScience.TraineeDistribution(students);
                //gameDev.TraineeDistribution(students);
                //mobila.TraineeDistribution(students);
                //dataScience.TraineeDistribution(students);
                //gameDev.TraineeDistribution(students);
                //mobila.TraineeDistribution(students);
                Traineeship traineeship = new Traineeship(students);
                traineeship.AddNewCandidates(denchik);
                traineeship.AddNewDepartment(dataScience, gameDev, mobila);
                foreach (var department in traineeship.Departments)
                {
                    department.TraineeDistribution(traineeship.Candidates);
                    Console.WriteLine(department);
                }
            }
            catch (ArgumentNullException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("НЕИЗВЕСТНАЯ ОШИБКА");
                return;
            }



        }



    }


}







