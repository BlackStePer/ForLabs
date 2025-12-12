using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOfficeVUZ {
    public enum DaysMonthYears {
        Day,
        Month,
        Year
    }
    /// <summary>
    /// Абстрактный класс, для описания свойств и методов рабочих почты
    /// </summary>
    internal abstract class Employee {
        /// <summary>
        /// Поле, в котором содержится информация о том, в чём (в днях, месяцах или годах) работник говорит свой стаж
        /// </summary>
        public DaysMonthYears daysMonthYears;
        /// <summary>
        /// Свойство, хранящее имя рабочего
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// Свойство, хранящее зарплату рабочего
        /// </summary>
        public required decimal Salary { get; set; }
        /// <summary>
        /// Свойство, хранящее дату найма рабочего
        /// </summary>
        public required DateTime DateOfEmployment { get; init; }
        /// <summary>
        /// Метод, возвращающий имя рабочего
        /// </summary>
        /// <returns>Имя рабочего</returns>
        public string EmployeeName() => Name;
        public virtual double WorkExperience() => 0;
        /// <summary>
        /// Метод, показывающий, что делает рабочий
        /// </summary>
        /// <returns>Действие, которым занят рабочий в данный момент</returns>
        public virtual string? EmployeeАction() => null;
    }
}
