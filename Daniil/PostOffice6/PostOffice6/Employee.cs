using System;

namespace PostOffice6
{
    internal abstract class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int Salary { get; set; }

        public abstract string JobTitle { get; }

        public Employee(string name, int salary) 
        { 
            Random rnd = new Random();
            Name = name;
            DateOfEmployment = new DateTime(rnd.Next(0, 51), rnd.Next(1, 12), rnd.Next(1, 29));
            Salary = salary;
        }

        /// <summary>
        /// Возвращает имя работник
        /// </summary>
        /// <returns>Строка с именем работника</returns>
        public string SayName()
        {
            return Name;
        }

        /// <summary>
        /// Возвращает время работы человека в компании: Для касира в днях, для оператора в месяцах, для доставщика в годах
        /// </summary>
        /// <returns>Время работы в виде целого числа</returns>
        public virtual int WorkTimeInCompany()
        {
            return 0;
        }

        /// <summary>
        /// Возвращает коментарий от работника(Чем он занимается)
        /// </summary>
        /// <returns>Строка с коментарием от работника</returns>
        public virtual string WhatYouDo()
        {
            return "";
        }
    }
}
