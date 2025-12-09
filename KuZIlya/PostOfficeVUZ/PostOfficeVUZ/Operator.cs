using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    internal class Operator : Employee {
        public Operator() => daysMonthYears = DaysMonthYears.Month;
        public override string? WhatToDo() => "Ищу посылку Ищу посылку";
        /// <summary>
        /// Метод, показывающий, сколько работает данный работник
        /// </summary>
        /// <returns>Кол-во месяцев</returns>
        public override double WorkTime() => (DateTime.Now - DateOfEmplyment).TotalDays / 30;
        public override string ToString() => "оператор";

    }
}
