using PostOffice6.Employees;
using System;
using System.Collections.Generic;
using System.Data;

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
                interview += $"- {emp.SayName()}\n";
                interview += "- А чем вы занимаетесь?\n";
                interview += $"- {emp.WhatYouDo()}\n";
                interview += "- Сколько вы работете?\n";
                interview += $"- {emp.WorkTimeInCompany()}\n";
                interview += "===================\n";

            }
            return interview;
        }

        /// <summary>
        /// Возвращает отчёт о зарплатах всех работников оффиса
        /// </summary>
        /// <returns>Строка содержащая отчёт</returns>
        public string SalaryStat()
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
                string mes = $"{Employees[id - 1].SayName()} - уволен.";
                Employees.RemoveAt(id - 1);
                return mes;
            }
        }

        /// <summary>
        /// Распределяет работников по командам, и возвращает отчёт
        /// </summary>
        /// <returns>Строка отчёт</returns>
        public string CommandStat()
        {
            string stat = "Команд нет(\n========================================================================\n";
            int id = 0, nonCommandSalary = 0;
            List<Cashier> cashiers = new List<Cashier>();
            List<Operator> operators = new List<Operator>();
            List<Postman> postmans = new List<Postman>();

            foreach (Employee emp in Employees)
            {
                if (emp is Cashier)
                {
                    cashiers.Add(emp as Cashier);
                }
                else if (emp is Operator) 
                {
                    operators.Add(emp as Operator);
                }
                else
                {
                    postmans.Add(emp as Postman);
                }
            }

            while (id < cashiers.Count && id < operators.Count && id < postmans.Count) 
            {
                if(id == 0)
                {
                    stat = "";
                }
                stat += $"Команда {id + 1}\n\n";
                stat += $"Касир: {cashiers[id].SayName()}\n";
                stat += $"Оператор: {operators[id].SayName()}\n";
                stat += $"Доставщик: {postmans[id].SayName()}\n\n";
                stat += $"Сумарная зарплата: {cashiers[id].Salary + operators[id].Salary + postmans[id].Salary}\n";
                stat += "========================================================================\n";
                id++;
            }

            stat += "Люди без команд:\n\n";
            for(int i = id; i < cashiers.Count; i++)
            {
                stat += $"Касир: {cashiers[id].SayName()}\n";
                nonCommandSalary += cashiers[id].Salary;
                if(i == cashiers.Count - 1)
                {
                    stat += "\n";
                }
            }

            for(int i = id; i < operators.Count; i++)
            {
                stat += $"Оператор: {operators[id].SayName()}\n";
                nonCommandSalary += operators[id].Salary;
                if (i == operators.Count - 1)
                {
                    stat += "\n";
                }
            }

            for (int i = id; i < postmans.Count; i++)
            {
                stat += $"Доставщик: {postmans[id].SayName()}\n";
                nonCommandSalary += postmans[id].Salary;
                if (i == postmans.Count - 1)
                {
                    stat += "\n";
                }
            }
            stat += $"Суммарная зарплата безкомандных: {nonCommandSalary}";

            return stat;
        }
    }
}
