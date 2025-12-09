using System;

namespace PostOffice6.Employees
{
    internal class Operator : Employee
    {
        public override string JobTitle { get; } = "Оператор";
        public Operator(string name, int salary) : base(name, salary)
        {
        }
        public override int WorkTime()
        {
            return DateOfEmployment.Month;
        }
        public override string WhatYouDo()
        {
            return "Ищу посылку!";
        }
    }
}
