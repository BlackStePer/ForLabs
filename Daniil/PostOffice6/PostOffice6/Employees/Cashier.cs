using System;

namespace PostOffice6.Employees
{
    internal class Cashier : Employee
    {
        public override string JobTitle { get; } = "Касир";
        public Cashier(string name, int salary) : base(name, salary)
        {
        }
        public override int WorkTimeInCompany()
        {
            return DateOfEmployment.Day;
        }
        public override string WhatYouDo()
        {
            return "Пополняю транспортные карты!";
        }
    }
}
