using PostOffice6.Employees;
using System;

namespace PostOffice6
{
    internal class Program
    {
        /// <summary>
        /// Запрашивает данные работника, для добавления в базу данных и проверяет их на првильность, возвращая корректные значения
        /// </summary>
        /// <param name="name">Имя работника</param>
        /// <param name="salary">Зарплата работника</param>
        static void NewEmp(out string name, out int salary)
        {
            Console.Clear();
            Console.WriteLine("Введите имя сотрудника");
            name = Console.ReadLine();
        AddSalary:
            Console.Clear();
            Console.WriteLine("Введите зарплату сотрудника в рублях");
            bool correct = int.TryParse(Console.ReadLine(), out salary);
            if (!correct)
            {
                Console.Clear();
                Console.WriteLine("Зарплата должна быть целым чсилом");
                Console.ReadKey();
                goto AddSalary;
            }
            else if (salary < 0)
            {
                Console.Clear();
                Console.WriteLine("Зарплата не может быть отрицательной");
                Console.ReadKey();
                goto AddSalary;
            }
        }
        /// <summary>
        /// Вывести список работников вида: id - Имя - Зарплата - Должность
        /// </summary>
        /// <param name="office">Оффис из которого мы берём список</param>
        static void showEmployees(PostOffice office)
        {
            Console.WriteLine("id - Имя - Зарплата - Должность");
            int id = 1;
            foreach (Employee emp in office.Employees)
            {
                Console.WriteLine($"{id} - {emp.SayName()} - {emp.Salary} - {emp.JobTitle}");
                id++;
            }
            Console.WriteLine($"{id} - Отмена");
        }

        static void Main(string[] args)
        {
            PostOffice myOffice = new PostOffice();
            bool isWorking = true;

        AddEmployee:
            Console.Clear();
            Console.WriteLine("Добавим в учёт сотрудника!");
            Console.WriteLine("1 - Касир");
            Console.WriteLine("2 - Оператор");
            Console.WriteLine("3 - Доставщик");
            string newEmpName;
            int newEmpSalary;

            switch (Console.ReadLine()) 
            {
                case "1":
                    NewEmp(out newEmpName, out newEmpSalary);
                    myOffice.Employees.Add(new Cashier(newEmpName, newEmpSalary));
                    break;
                case "2":
                    NewEmp(out newEmpName, out newEmpSalary);
                    myOffice.Employees.Add(new Operator(newEmpName, newEmpSalary));
                    break;
                case "3":
                    NewEmp(out newEmpName, out newEmpSalary);
                    myOffice.Employees.Add(new Postman(newEmpName, newEmpSalary));
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого варианта нет");
                    Console.ReadKey();
                    goto AddEmployee;
            }
            Console.Clear();
            Console.WriteLine($"Поздравляем {newEmpName} нанят!");
            Console.ReadKey();

            while (isWorking) 
            {
                Console.Clear();
                Console.WriteLine("Работаем с оффисом... Что будем делать???");
                Console.WriteLine("1 - Добавить сотрудника");
                Console.WriteLine("2 - Опросить сотрудников");
                Console.WriteLine("3 - Посмотреть зарплатную ведомость");
                Console.WriteLine("4 - Уволить сотрудника");
                Console.WriteLine("5 - Изменить зарплату сотрудника");
                Console.WriteLine("6 - Посмотреть отчёт о командах");
                Console.WriteLine("7 - Выйти");
                switch (Console.ReadLine()) 
                {
                    case "1":
                        Console.Clear();
                        goto AddEmployee;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(myOffice.Poll());
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(myOffice.SalaryStat());
                        Console.ReadKey();
                        break;
                    case "4":
                    RemoveEmp:
                        Console.Clear();
                        showEmployees(myOffice);
                        Console.WriteLine("Введите id уволенного:");
                        bool corr = int.TryParse( Console.ReadLine(), out int choice);
                        if (!corr || choice > myOffice.Employees.Count + 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Такого id нет!");
                            Console.ReadKey();
                            goto RemoveEmp;
                        }
                        else if (choice >= 1 && choice < myOffice.Employees.Count + 1)
                        {
                            Console.Clear();
                            Console.WriteLine(myOffice.DismissEmp(choice));
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                    RemakeSalary:
                        Console.Clear();
                        showEmployees(myOffice);
                        Console.WriteLine("Кому меняем заплату?");
                        bool correct = int.TryParse(Console.ReadLine(), out int upper);
                        if (!correct || upper > myOffice.Employees.Count + 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Такого id нет!");
                            Console.ReadKey();
                            goto RemakeSalary;
                        }
                        else if (upper >= 1 && upper < myOffice.Employees.Count + 1)
                        {
                        NewSall:
                            Console.Clear();
                            Console.WriteLine("Введите новую зарплату:");
                            Console.WriteLine("0 - Отмена;");
                            bool cor = int.TryParse(Console.ReadLine(), out int newSall);
                            Console.Clear();
                            if (!correct || newSall < 0)
                            {
                                Console.WriteLine("Некорретная зарплата");
                                Console.ReadKey();
                                goto NewSall;
                            }
                            else if(newSall == 0)
                            {
                                goto RemakeSalary;
                            }
                            else
                            {
                                Console.WriteLine($"Вы поменяли зарплату сотруднику, теперь {myOffice.Employees[upper - 1].SayName()} зарабатывает {newSall}");
                                myOffice.Employees[upper - 1].Salary = newSall;
                            }
                            Console.ReadKey();
                        }
                        break;
                    case "6":
                        {
                            Console.Clear();
                            Console.WriteLine(myOffice.CommandStat());
                            Console.ReadKey();
                            break;
                        }
                    case "7":
                        isWorking = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Такого варианта нет");
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}
