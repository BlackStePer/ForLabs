

namespace InternshipVUZ {

    internal class Program
    {
        enum Departments {
            Game,
            Mobile,
            Data,
            Shop,
            School,
            SVO
        }
        public static Random random = new Random();
        public static Student Kostya = new Student("Костя", 1, ProgrammingLanguage.None, int.MinValue, Skill.None);
        public static List<Student> subStudents = new List<Student>();
        /// <summary>
        /// Тренирует студента
        /// </summary>
        /// <param name="student">Студент</param>
        /// <param name="students">Список студентов</param>
        /// <param name="stopLoop">Костыль для улучшения навыков всем студентам</param>
        /// <exception cref="ArgumentException">Такой команды нет!!!</exception>
        public static void TrainStudent(Student student,List<Student> students, out bool stopLoop)
        {
            Console.WriteLine($"Что вы хотите улучшить в студенте {student}");
            Console.WriteLine("1. Заставить учиться\n2. Заставить перейти на следующий курс\n3. Заставить выучить новые языки\n4. Улучшить его навыки разработчика\n5. Заставить всех улучшать навыки");
            while (true)
            {
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int result) || result <= 0 || result > 5)
                        throw new ArgumentException("Такой команды нет!!!");
                    if (student == Kostya)
                    {
                        Console.WriteLine($"И у {student.Name} опять ничего не получилось...");
                        stopLoop = false;
                        return;
                    }
                    switch (result)
                    {
                        case 1:
                            double firstAchivement = student.Achievement;
                            student.ImproveAchievement(random.Next(50));
                            Console.WriteLine($"Успеваемость студента улучшена!!! Успеваемость до: {firstAchivement}; Успеваемость после: {student.Achievement}");
                            break;
                        case 2:
                            if (random.Next(3) % 3 == 0)
                            {
                                ++student.CourseNumber;
                                Console.WriteLine($"Курс {student.Name} успешно повышен до {student.CourseNumber}");
                            }
                            else
                                Console.WriteLine($"{student.Name} всё равно ленится и не переходит на следующий курс!");
                            break;
                        case 3:
                            Console.WriteLine($"Вы заставляете {student.Name} учить новые языки, при этом он может забыть старые из-за слишком интенсивной программы...");
                            var lastProgrammingLanguage = student.ProgrammingLanguage;
                            student.ProgrammingLanguage = (ProgrammingLanguage)random.Next(64);
                            Console.WriteLine($"{student.Name} забыл следующие языки {lastProgrammingLanguage}, однако смог выучить следующие {student.ProgrammingLanguage}");
                            break;
                        case 4:
                            if (random.Next(2) == 0)
                                Console.WriteLine($"Благодаря вашему усердию, {student.Name} стал {student.ImproveSkill()}");
                            else
                                Console.WriteLine($"Но лентяй {student.Name} не смог поумнеть");
                                break;
                        case 5:
                            foreach (var _student in subStudents)
                                if (random.Next(2) == 0 && _student != Kostya)
                                    Console.WriteLine($"Благодаря вашему усердию, {_student.Name} стал {_student.ImproveSkill()}");
                                else
                                    Console.WriteLine($"Но лентяй {_student.Name} не смог поумнеть");
                            stopLoop = true;
                            return;
                        default:
                            break;
                    }
                    subStudents = subStudents[1..];
                    stopLoop = false;
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
        /// <summary>
        /// Отбирает кандидатов на интернатуру
        /// </summary>
        /// <param name="students">Список студентов</param>
        /// <param name="traineeship">Интернатура</param>
        /// <exception cref="ArgumentException">Такой команды нет!!!</exception>
        public static void ChooseCandidates(List<Student> students,Traineeship traineeship)
        {
            int result = 52;
            while (result != 0)
            {
                try
                {
                    Console.WriteLine("Ваши студентики:");
                    for (int i = 1; i <= students.Count; i++)
                        Console.WriteLine(i + ". " + students[i - 1]);
                    Console.WriteLine("Вы можете отправить на отбор столько студентов, сколько захотите, однако вы не сможете их тренировать на следующем ходу!");
                    Console.WriteLine("Напишите номер студента, которого вы хотите отправить на отбор. 0 = выход");
                    if (!int.TryParse(Console.ReadLine(), out result) || result < 0 || result > students.Count)
                        throw new ArgumentException("Такой команды нет!!!");
                    if (result == 0)
                        break;
                    traineeship.AddNewCandidates(students[result - 1]);
                    students.RemoveAt(result - 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            Console.Clear();
        }



        public static void Main(string[] args)
        {
            List<string> maleNames = new List<string>
            {
                "Саша", "Серёжа", "Дима", "Андрюха", "Лёха", "Женя", "Миша", "Ваня",
                "Макс", "Вова", "Денис", "Паша", "Тёма", "Антоха", "Коля", "Олег",
                "Витя", "Жора", "Рома", "Игорёк", "Кирюха", "Стас", "Слава", "Гена",
                "Толя", "Юра", "Петя", "Вася", "Федя", "Гоша", "Даня", "Егор",
                "Илья", "Лёня", "Матвей", "Никита", "Семён", "Тима", "Эдик", "Ярик"
            };
            List<string> femaleNames = new List<string>
            {
                "Лена", "Наташа", "Таня", "Ира", "Оля", "Катя", "Аня", "Света",
                "Маша", "Юля"
            };


            List<Student> students = new List<Student>(15);
            Console.WriteLine("Выберите сложность по шкале от 1 до 3 (3 = легко; 2 = средне; 1 = сложно (На деле всё на рандом =)))");
            if (!int.TryParse(Console.ReadLine(), out int difficulty) || difficulty < 1 || difficulty > 3)
                throw new ArgumentException("Такой команды нет!!!");
            difficulty += 4;
            Console.WriteLine($"Добро пожаловать в игру-недоигру. Она будет состоять из {difficulty} волн.");
            Console.WriteLine("До начала каждой волны будет необходимо будет потренировать студентов");
            Console.WriteLine("Каждому студенту можно улучшить успеваемость, научить новому языку, без палева перевести на следующий курс, улучшить навык (там Джун, Мидддл и Сениоре)");
            Console.WriteLine("Вам будет выдано 15 студентов, ваша задача, как любого хорошего руководителя, избавиться от них всех");
            Console.WriteLine("Учтите, что у каждой компании собственные запросы, которые могут быть весьма странными...");
            Console.WriteLine();
            Console.WriteLine();
            Student student1 = new Student("Лёха-Сигма", 52, ProgrammingLanguage.CSharp, 100, Skill.Senior);
            Student student2 = new Student("Лёха-Гений", 1, (ProgrammingLanguage)63, 52 ,Skill.Senior);
            Student student3 = new Student("Лёха-Тупой", 2, ProgrammingLanguage.CSharp | ProgrammingLanguage.Python, 80);
            Student student4 = new Student("Халтурин", 52, ProgrammingLanguage.Cpp, int.MaxValue ,Skill.Senior);
            Student student5 = new Student("Тот самый магистр", 5, ProgrammingLanguage.Python, 99);
            Student student7 = new Student("Роман Сакутин", 52, ProgrammingLanguage.Cpp | ProgrammingLanguage.CSharp, 99,Skill.Senior);
            Student randomStudent = new Student("Даниил", 1, ProgrammingLanguage.Cpp | ProgrammingLanguage.Python | ProgrammingLanguage.CSharp, 0);
            students.AddRange(student1, student2, student3, student4, student5, Kostya, student7, randomStudent);
            for (int i = 0; i < 7; i++)
            {
                var gender = random.Next(2) == 0? maleNames : femaleNames;
                string name;
                if (gender == maleNames)
                    name = maleNames[random.Next(40)];
                else
                    name = femaleNames[random.Next(10)];
                students.Add(new Student(name, random.Next(1, 5), (ProgrammingLanguage)random.Next(64), random.Next(100),(Skill)random.Next(1,4)));
            }
            foreach (Student student in students)
                Console.WriteLine(student);
            DataScience dataScience = new DataScience("Техподдержка MAX", 5);
            GameDevelopment gameDev = new GameDevelopment("Разработчик Смуты 2", 5);
            MobileApplicationDevelopment mobila = new MobileApplicationDevelopment("Придумыватели новых карт в Clash Royale", 3);
            Soldier svo = new Soldier("БОМБОРДИРОВЩИК", 1);
            Shop shop = new Shop("Пятёрочка", 6);
            School school = new School("ФМШ", 4);
            List<Department> departmentList = new List<Department>() { gameDev, mobila, dataScience, shop, school, svo };
            List<Student> candidates = new List<Student>();
            List<Departments> departments = new List<Departments>() {Departments.Game, Departments.Mobile, Departments.Data, Departments.Shop,Departments.School, Departments.SVO };
            for (int i = 0; i < difficulty; i++)
            {
                subStudents = students[..];
                try
                {
               
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    Departments currentDepartment;
                    Department department;
                    currentDepartment = departments[random.Next(departments.Count)];
                    department = departmentList[(int)currentDepartment];
                    foreach (var student in students)
                    {
                        TrainStudent(student,students, out bool stop);
                        if (stop)
                            break;
                    }


                    students.AddRange(candidates);
                    Traineeship traineeship = new Traineeship();
                    switch (currentDepartment)
                    {
                        case Departments.Game:
                            Console.WriteLine($"Компании Cyberia Nova необходимы разработчики ({department.NumberOfPositions}) для Смуты 2.\nЧеловеку нужна хорошая успеваемость или замечательные навыки, студент должен быть не первокурсником и знать языки, необходимые при разработке, чтобы не запороть вторую часть");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        case Departments.Mobile:
                            Console.WriteLine($"Компании Supercell необходим придумывальщики ({department.NumberOfPositions}) карт в Clash Royale. Уже несколько лет они не могут придумать ничего нормального, поэтому они рассчитывают, что вы сможете найти образованного человека для столь сложного дела. Языки не важны");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        case Departments.Data:
                            Console.WriteLine($"Чтобы Великий MAX работал студенты ({department.NumberOfPositions}) должны быть гетеросексуалом с пророссийскими взглядами(Таких людей не так уж и много...). Студент должен обладать превосходными знаниями, уметь играть в дартс, быть третьекурсником и не быть Никитой");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        case Departments.Shop:
                            Console.WriteLine($"В пятёрочке не хватает программистов ({department.NumberOfPositions})! Им нужен глупый необразованный (главное чтоб не Костя) студент, ведь такая рабочая сила самая дешёвая, ведь глупых студентов можно легко развести на деньги!!! Знания языков абсолютно не важно");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        case Departments.School:
                            Console.WriteLine($"В 3 школу в городе Козельск требуются программисты ({department.NumberOfPositions}). Программист в данной школе должен показывать хороший пример школьникам, поэтому начальство школы смотрит только на успеваемость!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        case Departments.SVO:
                            Console.WriteLine($"Компании Армия РФ срочно требуются запускальщики дронов!!! НИКАКИЕ ХАРАКТЕРИСТИКИ НЕ ВАЖНЫ!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            ChooseCandidates(students, traineeship);
                            department.TraineeDistribution(traineeship.Candidates);
                            candidates = traineeship.Candidates;
                            Console.WriteLine(department);
                            department.selectedСandidates.Clear();
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentNullException ex) 
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            if (students.Count != 0)
                Console.WriteLine("Вы проиграли!!! Из вас получился отвратительный руководитель!!!");
            else
                Console.WriteLine("ВЫ САМЫЙ ЛУЧШИЙ ЧЕЛОВЕК НА СВЕТЕ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");



        }



    }


}







