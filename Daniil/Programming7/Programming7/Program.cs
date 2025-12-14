using Programming7.Departments;
using Programming7.Deportments;
using System;
using System.Collections.Generic;
using System.Linq;

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
            bool work = true, savelist = false;
            int id;
            string newName;
            List<Student> students = new List<Student>();
            Traineeship traineeship = new Traineeship();

            DataScience dataScience = new DataScience("Базеры", 52);
            GameDevelopment gameDevelopment = new GameDevelopment("Геймеры", 69);
            MobileApplicationDevelopment mobileApplicationDevelopment = new MobileApplicationDevelopment("Мобильщики", 666);
            Department department = new Department("Обычный офисный клерк", 228);

            traineeship.Departaments = new List<Department> { mobileApplicationDevelopment, dataScience, gameDevelopment, department };

            Console.WriteLine("Привет пользователь! Это простое приложение даст тебе предсказание о будущем твоих друзей в айти!\n");
            Console.WriteLine("Добавляй друзей и разом получи предсказание о каждом из них!");
            Console.WriteLine("\nУдачи!!!");
            Console.ReadKey();

            while (work)
            {
                Console.Clear();
                Console.WriteLine("Что делаем????");

                Console.WriteLine("1 - Добавить человека, для предсказания");
                Console.WriteLine("2 - Получить предсказание о друзьях");
                Console.WriteLine("3 - Удалить человека из списка");
                Console.WriteLine("4 - Выйти");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Введите имя друга:");
                        newName = Console.ReadLine(); 
                        students.Add(new Student(newName));

                        Console.Clear();
                        Console.WriteLine($"{newName} теперь в списке на предсказание)");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        traineeship.Candidates = students.ToList();
                        traineeship.Study();

                        Console.WriteLine(traineeship.Distribute());
                        Console.ReadKey();

                        if(students.Count > 0)
                        {
                            savelist = true;
                        }

                        foreach (Department dep in traineeship.Departaments)
                        {
                            dep.Trainees.Clear();
                        }


                        while (savelist)
                        {
                            Console.Clear();
                            Console.WriteLine("Оставляем список друзей, или нет?");

                            Console.WriteLine("1 - Удалить старый список");
                            Console.WriteLine("2 - Сохранить старый список");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    students.Clear();

                                    Console.Clear();
                                    Console.WriteLine("Список очищен!");
                                    Console.ReadKey();

                                    savelist = false;
                                    break;

                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Список сохранён!");
                                    Console.ReadKey();

                                    savelist = false;
                                    break;
                            }
                        }
                        break;
                    case "3":
                        while (true)
                        {
                            Console.Clear();
                        Console.WriteLine("Кого удаляем???");
                        Console.WriteLine("===============");

                        id = 0;
                        foreach(Student student in students)
                        {
                            Console.WriteLine($"{id + 1} - {students[id].Name}");
                            id++;
                        }
                        Console.WriteLine($"{id + 1} - Отмена");

                            if (int.TryParse(Console.ReadLine(), out int delId))
                            {
                                if(delId - 1 >= 0 && delId - 1 < id)
                                {
                                    students.RemoveAt(delId - 1);

                                    Console.Clear();
                                    Console.WriteLine("Лишка удалена!");
                                    Console.ReadKey();
                                    break;
                                }
                                else if(delId - 1 == id)
                                {
                                    break;
                                }
                            }
                        }
                        break;

                    case "4":
                        work = false;
                        break;
                }
            }
        }
    }
}
