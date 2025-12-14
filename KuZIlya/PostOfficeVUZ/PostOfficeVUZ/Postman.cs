using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    internal class Postman : Employee {
        public Postman() => daysMonthYears = DaysMonthYears.Year;
        public override string? EmployeeАction() => "Разношу почту, мешайте";
        /// <summary>
        /// Метод, показывающий, сколько работает данный работник
        /// </summary>
        /// <returns>Кол-во лет</returns>
        public override double WorkExperience() => (DateTime.Now - DateOfEmployment).TotalDays/365;
        public override string ToString() => "поствщик";
    }
}
