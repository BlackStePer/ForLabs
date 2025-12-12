using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    /// <summary>
    /// Класс, описывающий отдел почты
    /// </summary>
    internal class PostOffice {
        private static Random random = new Random();
        /// <summary>
        /// Список рабочих в конкретном отделе почты
        /// </summary>
        public List<Employee> Employees { get; set; } = new List<Employee>();
    /// <summary>
    /// Нанимает сотрудника на работу
    /// </summary>
    /// <param name="name">Имя сотрудника</param>
    /// <param name="choice">Номер желаемой профессии</param>
        public void Hire(string name, int choice)
        {
            if (choice == 1)
                Employees.Add(new Operator() { Name = name, DateOfEmplyment = DateTime.Now, Salary = random.Next(30000,52000)});
            else if(choice == 2)
                Employees.Add(new Postman() { Name = name, DateOfEmplyment = DateTime.Now, Salary = random.Next(52000,69000)});
            else
                Employees.Add(new Cashier() { Name = name, DateOfEmplyment = DateTime.Now, Salary = random.Next(69000,152000)});
        }
        /// <summary>
        /// Задаёт все вопросы всем сотрудникам
        /// </summary>
        /// <returns>Строку с ответами на вопросы</returns>
        public string Poll()
        {
            string message = "";
            foreach (var employee in Employees)
            {
                message += employee.Say() + "\n";
                message += employee.WhatToDo() + "\n";
                message += "Я работаю примерно " + Math.Round(employee.WorkTime()) + " " + employee.daysMonthYears + "s" + "\n\n";
            }
            return message;
        }
        /// <summary>
        /// Возвращает среднюю зарплату сотрудников
        /// </summary>
        /// <returns>Средння зарплата сотрудников</returns>
        public int Stat()
        {
            decimal sum = 0;
            foreach (var employee in Employees)
                sum += employee.Salary;
            return (int)sum/Employees.Count;
        }
        
    }
}
        