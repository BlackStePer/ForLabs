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
    internal abstract class Discipline {
        private static Random random = new Random();
        public string Name { get; set; }
        public bool takesBribe = random.Next(1,3)%3 != 0;
        public int Bribe { get; private set; }
        protected Discipline(string name, bool takesBribe = true)
        {
            Name = name;
            Bribe = takesBribe? random.Next(10000, 100000) : int.MaxValue;
        }
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
        private (DisciplineExamRequires, bool)? CheckRequiredConditions(Student student)
        {

            if (this is IHavePractice && this is IHaveFinalControll)
                return (DisciplineExamRequires.All, ((IHavePractice)this).Check(student.Practices[(IHavePractice)this]) && ((IHaveFinalControll)this).Check(student.FinalControls[(IHaveFinalControll)this]));
            if (this is IHavePractice)
                return (DisciplineExamRequires.Practice,((IHavePractice)this).Check(student.Practices[(IHavePractice)this]));
            if (this is IHaveFinalControll)
                return (DisciplineExamRequires.Test, ((IHaveFinalControll)this).Check(student.FinalControls[(IHaveFinalControll)this]));
            return (DisciplineExamRequires.None, true);
        }
    }
}
