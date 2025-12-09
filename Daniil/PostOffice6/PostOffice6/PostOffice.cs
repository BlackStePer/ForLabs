using System;
using System.Collections.Generic;

namespace PostOffice6
{
    internal class PostOffice
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        /// <summary>
        /// Метод задаёт важные для директора вопросы работникам, и возвращает ответы ввиде отчёта
        /// </summary>
        /// <returns>Строка содержащая отчёт</returns>
        public string Poll()
        {
            string interview = "===================\n";
            foreach (Employee emp in Employees) 
            {
                interview += "- Как вас зовут?\n";
                interview += $"- {emp.Say()}\n";
                interview += "- А чем вы занимаетесь?\n";
                interview += $"- {emp.WhatYouDo()}\n";
                interview += "- Сколько вы работете?\n";
                interview += $"- {emp.WorkTime()}\n";
                interview += "===================\n";

            }
            return interview;
        }

        /// <summary>
        /// Возвращает отчёт о зарплатах всех работников оффиса
        /// </summary>
        /// <returns>Строка содержащая отчёт</returns>
        public string Stat()
        {
            string statistic = "Статистика зарплат:\n";
            foreach (Employee emp in Employees) 
            {
                statistic += $"{emp.Name} - {emp.Salary}\n";
            }
            return statistic;
        }

        /// <summary>
        /// Увольнение сотрудника по id
        /// </summary>
        /// <param name="id">id удаляемого(На 1 больше id в списке)</param>
        /// <returns>Сообщение об увольнении или ошибке</returns>
        public string DismissEmp(int id)
        {
            if (Employees.Count == 1)
            {
                return "Нельзя увольнять последнего сотрудника!";
            }
            else
            {
                string mes = $"{Employees[id - 1].Say()} - уволен.";
                Employees.RemoveAt(id - 1);
                return mes;
            }
        }
    }
}
