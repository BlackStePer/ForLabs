using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    internal class Cashier : Employee {
        public Cashier() => daysMonthYears = DaysMonthYears.Day;
        public override string? EmployeeАction() => "Пополняю  транспортные карты ";
        /// <summary>
        /// Метод, показывающий, сколько работает данный работник
        /// </summary>
        /// <returns>Кол-во дней</returns>
        public override double WorkExperience() => (DateTime.Now -  DateOfEmployment).TotalDays;
        public override string ToString() => "кассир";
    }
}
