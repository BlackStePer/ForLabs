namespace PostOfficeVUZ {
    public enum Question
    {
        Name,
        WhatAreYouDoing,
        TimeOfWork,
        Payment,
        GoHome,
        GoToNext,
        Poll,
        Stat,
        BeHired,
        Code,
        Error
    }
    class Program {
        /// <summary>
        /// Задаёт вопросы человеку, чтобы выяснить, достоен ли он работать на почте России
        /// </summary>
        /// <param name="choice">Определяет список вопросов</param>
        /// <returns>true если прошёл, false если не прошёл</returns>
        public static bool Hire(int choice)
        {
            Console.WriteLine("Для найма на работу вам необходимо пройти лёёёёёгенький тест");
            string answer = "";
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1) Сколько будет 2+2?");
                    answer = Console.ReadLine();
                    if (answer == "4" || answer.Replace(" ", "").ToLower() == "почтароссии")
                    {
                        Console.WriteLine("2) Вы несли посылку массой 1кг, вам дали ещё одну посылку массой 2кг. Сколько посылок вам придётся нести?");
                        answer = Console.ReadLine();
                        if (answer == "2" || answer.Replace(" ", "").ToLower() == "почтароссии")
                        {
                            Console.WriteLine("3) Вы сегодня завтракали?");
                            answer = Console.ReadLine();
                            return true;
                        }
                    }
                    return false;
                case 2:
                    Console.WriteLine("1) Какая лучшая почта в мире?\n1. Почта России\n2. Почта России\n3. Почта России\n4. Почта России");
                    answer = Console.ReadLine();
                    if ("1234".Contains(answer) || answer.Replace(" ", "").ToLower() == "почтароссии")
                    {
                        Console.WriteLine("2) Как правильно обращаться с посылкой?\n1. Нести аккуратно, чтобы ничего не повредилось\n2. Использовать как футбольный мяч");
                        answer = Console.ReadLine();
                        if (answer == "2" || answer.Replace(" ", "").ToLower() == "почтароссии")
                        {
                            Console.WriteLine("3) Где живёт кот Матроскин?");
                            answer = Console.ReadLine();
                            if (answer == "Простоквашино" || answer.Replace(" ", "").ToLower() == "почтароссии")
                                return true;

                        }
                    }
                    return false;
                case 3:
                    Console.WriteLine("1) Решите уравнение:\nxdx+ydy=xdy-ydx/(x^2+y^2)\n1.x^2+y-arcctg(y/x)=0\n2.x^2+y^2-2*arctg(y/x)=C\n3.x+y-2*arctg(y/x)=52\n4.x+y^2-2*arcctg(y/x)= 0");
                    answer = Console.ReadLine();
                    if (answer == "2" || answer.Replace(" ", "").ToLower() == "почтароссии")
                    {
                        Console.WriteLine("2) Объём тела, ограниченного парабалоидом 7-x^2-y^2, z>=5 равен:\n1.1pi\n2.2pi\n3.3pi\n4.4pi");
                        answer = Console.ReadLine();
                        if (answer == "2" || answer.Replace(" ", "").ToLower() == "почтароссии")
                        {
                            Console.WriteLine("3) Найдите производную от функции Вайерштрасса Σ[n=0 до n = ∞](b^n*cos(a^n*pi*x)) при ab >=1 и a > 1");
                            answer = Console.ReadLine();
                            if (answer == "Идите нафиг" || answer.Replace(" ", "").ToLower() == "почтароссии" || answer == "52")
                                return true;

                        }
                    }
                    return false;
                default:
                    throw new ArgumentException("Такой команды нет!!!");
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Cashier badCashier = new Cashier() { Name = "Тамара", Salary = 66, DateOfEmployment = DateTime.MinValue };
            Operator _operator = new Operator() { Name = "Петя", Salary = 40000, DateOfEmployment = new DateTime(2020, 5, 1) };
            Postman postman  = new Postman() { Name = "АБДУЛ АДЗЫМБЕЙК ГЕЙША", Salary = 100000, DateOfEmployment = new DateTime(2023, 5, 1) };
            PostOffice post = new PostOffice();
            post.Employees.Add(postman);
            post.Employees.Add(_operator);
            post.Employees.Add(badCashier);
            
            int q = 0;
            string? password = null;
            bool end = false;
            while (!end)
            foreach (var employee in post.Employees[..])
            {
                bool localEnd = false;
                while (!localEnd)
                {
                    try
                    {
                        if (end)
                            break;
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Вы подошли к " + employee + "у");
                        if (q >= 5)
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. ОТПУСТИТЕ!!! Я ХОЧУ ДОМОЙ!!!\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату\n9. Откликнуться на заявление о поиске сотрудников\n10. Просить НЕВЕРОЯТНО искренне");
                        else if (q != 0)
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. Просить искреннее\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату\n9. Откликнуться на заявление о поиске сотрудников");
                        else
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. ОТПУСТИТЕ!!! Я ХОЧУ ДОМОЙ!!!\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату\n9. Откликнуться на заявление о поиске сотрудников");
                        Question question = int.TryParse(Console.ReadLine(), out int result) ? (Question)(result - 1) : Question.Error;
                        switch (question)
                        {
                            case Question.Name:
                                Console.WriteLine(employee.Name);
                                break;
                            case Question.WhatAreYouDoing:
                                Console.WriteLine(employee.EmployeeАction());
                                break;
                            case Question.TimeOfWork:
                                Console.WriteLine("Я работаю примерно " + Math.Round(employee.WorkExperience()) + " " + employee.daysMonthYears + "s");
                                break;
                            case Question.Payment:
                                Console.WriteLine($"Я зарабатываю {employee.Salary} рублей");
                                break;
                            case Question.GoHome:
                                ++q;
                                if (q == 666)
                                    return;
                                Console.WriteLine("Надо просить искреннее...");
                                break;
                            case Question.GoToNext:
                                localEnd = true;
                                break;
                            case Question.Poll:
                                Console.WriteLine(post.Poll());
                                break;
                            case Question.Stat:
                                Console.WriteLine($"Средняя зарплата сотрудников почтового отделения: {post.Stat()} рублей");
                                break;
                            case Question.BeHired: // Кодовое слово почтароссии
                                    Console.WriteLine("Какое у вас имя?");
                                string name = Console.ReadLine();
                                if (name == null || name == "Никита")
                                {
                                    Console.WriteLine("Вы нам не подходите");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Кем вы хотите работать?\n1. Оператором\n2. Разносчиком писем\n3. Кассиром");
                                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
                                        throw new ArgumentException("Такой команды нет!!!");
                                    if (!Hire(choice))
                                    {
                                        Console.WriteLine("К НЕВЕРОЯТНОМУ, ПРЕНЕПРИЯТНОМУ СОЖАЛЕНИЮ, ВЫ НАМ НЕ ПОХОДИТЕ!!!");
                                        break;
                                    }
                                    Console.WriteLine("ПОЗДРАВЛЯЕМ ВЫ ПРИНЯТЫ В ЛУЧШЕЕ ЗАВЕДЕНИЕ СТРАНЫ!!!");
                                    post.Hire(name, choice);
                                    Console.WriteLine("Так как вы сотрудник почты, вы можете из неё уйти, наверное...");
                                    localEnd = true;
                                    end = true;
                                    break;
                                }
                            case Question.Code when q >= 5:
                                Console.WriteLine("Введите пароль");
                                password = Console.ReadLine();
                                    if (password == "ане Ищу посылку6" || password == "анеИщу посылку6" || password == "анеИщу посылку 6" || password == "анеИщу посылку 6" || password == "почтароссии")
                                    {
                                        end = true;
                                        localEnd = true;
                                    }
                                    else
                                        Console.WriteLine("НЕПРАВИЛЬНЫЙ ПАРОЛЬ.\nБУДЬТЕ ВНИМАТЕЛЬНЕЕ!!!");
                                    break;
                            case Question.Error:
                                throw new ArgumentException("Такой команды не существует!");
                            default:
                                throw new ArgumentException("Такой команды не существует!");
                        }
                    }


                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine("НЕИЗВЕСТНАЯ ОШИБКА!!!");
                        return;
                    }
                }
            }
            Console.WriteLine("ПОЗДРАВЛЯЕМ!!! ВЫ СБЕЖАЛИ ИЗ ПОЧТЫ РОССИИ!!!\nТеперь нужно сбежать из ИКИТА...");


        }
    }

}





