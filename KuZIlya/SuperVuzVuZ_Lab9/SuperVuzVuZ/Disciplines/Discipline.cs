using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    [Flags]
    enum DisciplineExamRequires {
        None = 0,
        Practice = 1,
        Test = 2,
        All = Practice | Test
    }
    /// <summary>
    /// Абстрактный класс, описывает поля дисциплин для сдачи
    /// </summary>
    internal abstract class Discipline {
        private static Random random = new Random();
        public abstract Exam exam { get; set; }
        public string Name { get; set; }
        public int Bribe { get; private set; }
        protected Discipline(string name, bool takesBribe = true)
        {
            if (takesBribe)
                takesBribe = random.Next(1, 3) % 3 != 0;
            Name = name;
            Bribe = takesBribe? random.Next(10000, 100000) : int.MaxValue;
        }
        protected void SetBribe(int bribe) => Bribe = bribe;
        /// <summary>
        /// Процесс и результат попытки получить автомат
        /// </summary>
        /// <param name="student">Рассматриваемый студент</param>
        /// <param name="success">Возвращает true, если атвомат получен, иначе false</param>
        /// <returns>Строку, содержащую информацию об успехе/неудаче студента</returns>
        public string Passed(Student student,out bool success)
        {
            success = false;
            if (this is IHaveAngryTeacher)
                return "Злой учитель ухмыляется и ждёт ученика на экзамене" + " - " + Name;
            (DisciplineExamRequires TypeOfRequirement, bool success)? passed = CheckRequiredConditions(student);
            success = passed.Value.success;
            if (passed.Value.TypeOfRequirement == DisciplineExamRequires.None)
                return "ХАЛЯВА ПРИШЛАААААААААААААААА!!!!!!!!!!!!!!!!!!!!" + " - " + Name;
            else if (passed.Value.TypeOfRequirement.HasFlag(DisciplineExamRequires.All))
                return (passed.Value.success ? "Студент сдал все практические работы и превосходно сдал тест. ПОЭТОМУ ОН ПОЛУЧИЛ ААААААААВТОМАТ" : "Студент не справился с работами и ожидает худшего...") + " - " + Name;
            else if (passed.Value.TypeOfRequirement.HasFlag(DisciplineExamRequires.Practice))
                return (passed.Value.success ? "Студент сдал все практические работы И ПОЛУЧИЛ ААААААААВТОМАТ" : "Студент не справился с работами и ожидает худшего...") + " - " + Name;
            else
                return (passed.Value.success ? "Студент превосходно сдал финальный тест И ПОЛУЧИЛ ААААААААВТОМАТ" : "Студент не справился с работами и ожидает худшего...") + " - " + Name;
        }
        private (DisciplineExamRequires, bool) CheckRequiredConditions(Student student)
        {
            if (this is IHavePractice havePractice && this is IHaveFinalControll haveFinalControll)
                return (DisciplineExamRequires.All, havePractice.Check(student.Practices[havePractice]) && haveFinalControll.Check(student.FinalControls[haveFinalControll]));
            else if (this is IHavePractice _havePractice)
                return (DisciplineExamRequires.Practice, _havePractice.Check(student.Practices[_havePractice]));
            else if (this is IHaveFinalControll _haveFinalControll)
                return (DisciplineExamRequires.Test, _haveFinalControll.Check(student.FinalControls[_haveFinalControll]));
            return (DisciplineExamRequires.None, true);
        }
    }
}
