using System;

namespace PostOffice6.Employees
{
    internal class Postman : Employee
    {
        public override string JobTitle { get; } = "Доставщик";
        public Postman(string name, int salary) : base(name, salary)
        {
        }
        public override int WorkTimeInCompany()
        {
            return DateOfEmployment.Year;
        }
        public override string WhatYouDo()
        {
            return "Разношу почту, не мешайте!";
        }
    }
}
