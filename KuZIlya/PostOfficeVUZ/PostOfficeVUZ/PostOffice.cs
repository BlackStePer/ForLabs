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
        /// <summary>
        /// Список рабочих в конкретном отделе почты
        /// </summary>
        public List<Employee> Employees { get; set; } = new List<Employee>();
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
        