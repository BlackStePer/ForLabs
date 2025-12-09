




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
        Code,
        Error
    }
    class Program {
        static void Main(string[] args)
        {
            Cashier badCashier = new Cashier() { Name = "Тамара", Salary = 66, DateOfEmplyment = DateTime.MinValue };
            Operator _operator = new Operator() { Name = "Петя", Salary = 40000, DateOfEmplyment = new DateTime(2020, 5, 1) };
            Postman postman  = new Postman() { Name = "АБДУЛ АДЗЫМБЕЙК ГЕЙША", Salary = 100000, DateOfEmplyment = new DateTime(2023, 5, 1) };
            PostOffice post = new PostOffice();
            post.Employees.Add(postman);
            post.Employees.Add(_operator);
            post.Employees.Add(badCashier);
            
            int q = 0;
            string? password = null;
            bool end = false;
            while (!end)
            foreach (var employee in post.Employees)
            {
                bool localEnd = false;
                while (!localEnd)
                {
                    try
                    {
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Вы подошли к " + employee + "у");
                        if (q >= 5)
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. ОТПУСТИТЕ!!! Я ХОЧУ ДОМОЙ!!!\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату\n9. Просить НЕВЕРОЯТНО искренне");
                        else if (q != 0)
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. Просить искреннее\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату");
                        else
                            Console.WriteLine("Введите вопрос:\n1. А вас как зовут?\n2. А что вы делаете?\n3. И давно вы тут работаете?\n4. Сколько вы получаете?\n5. ОТПУСТИТЕ!!! Я ХОЧУ ДОМОЙ!!!\n6. Подойти к следующему сотруднику\n7. Задать все вопросы всем сотрудникам\n8. Узнать среднюю зарплату");
                        Question question = int.TryParse(Console.ReadLine(), out int result) ? (Question)(result - 1) : Question.Error;
                        switch (question)
                        {
                            case Question.Name:
                                Console.WriteLine(employee.Name);
                                break;
                            case Question.WhatAreYouDoing:
                                Console.WriteLine(employee.WhatToDo());
                                break;
                            case Question.TimeOfWork:
                                Console.WriteLine("Я работаю примерно " + Math.Round(employee.WorkTime()) + " " + employee.daysMonthYears + "s");
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
                            case Question.Code when q >= 5:
                                Console.WriteLine("Введите пароль");
                                password = Console.ReadLine();
                                    if (password == "ане Ищу посылку6" || password == "анеИщу посылку6" || password == "анеИщу посылку 6" || password == "анеИщу посылку 6")
                                    {
                                        end = true;
                                        localEnd = true;
                                    }
                                    else
                                        Console.WriteLine("НЕПРАВИЛЬНЫЙ ПАРОЛЬ.\nБУДЬТЕ ВНИМАТЕЛЬНЕЕ!!!");
                                    break;
                            case Question.Poll:
                                Console.WriteLine(post.Poll());
                                break;
                            case Question.Stat:
                                Console.WriteLine($"Средняя зарплата сотрудников почтового отделения: {post.Stat()} рублей");
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





