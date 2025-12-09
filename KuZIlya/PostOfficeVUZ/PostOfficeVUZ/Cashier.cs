using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    internal class Cashier : Employee {
        public Cashier() => daysMonthYears = DaysMonthYears.Day;
        public override string? WhatToDo() => "Пополняю  транспортные карты ";
        /// <summary>
        /// Метод, показывающий, сколько работает данный работник
        /// </summary>
        /// <returns>Кол-во дней</returns>
        public override double WorkTime() => (DateTime.Now -  DateOfEmplyment).TotalDays;
        public override string ToString() => "кассир";
    }
}
