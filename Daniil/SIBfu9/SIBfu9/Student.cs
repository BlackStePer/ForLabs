using SIBfu9.IResultGetters;
using System;
using System.Collections.Generic;

namespace SIBfu9
{
    internal class Student
    {
        public readonly string _name;

        public Dictionary<Discipline, int> FinalControll = new Dictionary<Discipline, int>();

        public Dictionary<Discipline, int> Practice = new Dictionary<Discipline, int>();

        public Student(string name)
        {
            _name = name;
        }
        /// <summary>
        /// Возвращает отчёт ученика по дисциплине
        /// </summary>
        /// <param name="discipline">Диспциплина</param>
        /// <param name="haveautomate">Получил ли автомат ученик</param>
        /// <returns>Отчёт</returns>
        public string Check(Discipline discipline, out bool haveautomate)
        {
            string stat = $"{discipline.Name}\n\nЧто нужно для автомата:\n\n";
            haveautomate = false;
            if(discipline is IHaveAngryTeacher)
            {
                stat += "А ничего не нужно! Автомата не будет! Иди на экзамен!\n";
                stat += "===========================================================";
                return stat;
            }
            else if(discipline is IHaveFinalControll &&  discipline is IHavePractice)
            {
                IHavePractice havePractice = (IHavePractice)discipline;
                IHaveFinalControll haveFinalControll = (IHaveFinalControll)discipline;
                stat += $"Посщения: {havePractice.PracticeCount}\n";
                stat += $"Минимальный бал за контроль: {haveFinalControll.PassingScore}\n\n";
                stat += "============================================\n";
                stat += "Мои результаты:\n\n";
                stat += $"Посщения: {Practice[discipline]}\n";
                stat += $"Бал за контроль: {FinalControll[discipline]}\n=>\n";
                haveautomate = haveFinalControll.Check(FinalControll[discipline]) && havePractice.Check(Practice[discipline]);
                if (haveautomate) 
                {
                    stat += "Автомат: Есть)\n";
                }
                else
                {
                    stat += "Автомат: Нету(\n";
                }
                stat += "===========================================================";
                return stat;
            }
            else if(discipline is IHaveFinalControll)
            {
                IHaveFinalControll haveFinalControll = (IHaveFinalControll)discipline;
                stat += $"Минимальный бал за контроль: {haveFinalControll.PassingScore}\n\n";
                stat += "============================================\n";
                stat += "Мой результат:\n\n";
                stat += $"Бал за контроль: {FinalControll[discipline]}\n=>\n";
                haveautomate = haveFinalControll.Check(FinalControll[discipline]);
                if (haveautomate)
                {
                    stat += "Автомат: Есть)\n";
                }
                else
                {
                    stat += "Автомат: Нету(\n";
                }
                stat += "===========================================================";
                return stat;
            }
            else if(discipline is IHavePractice)
            {
                IHavePractice havePractice = (IHavePractice)discipline;
                stat += $"Посщения: {havePractice.PracticeCount}\n";
                stat += "============================================\n";
                stat += "Мой результат:\n\n";
                stat += $"Посщения: {Practice[discipline]}\n";
                haveautomate = havePractice.Check(Practice[discipline]);
                if (haveautomate)
                {
                    stat += "Автомат: Есть)\n";
                }
                else
                {
                    stat += "Автомат: Нету(\n";
                }
                stat += "===========================================================";
                return stat;
            }
            else
            {
                haveautomate = true;
                stat += "А ничего не нужно! Автомат на халявку! Иди чиль!\n";
                stat += "===========================================================";
                return stat;
            }
            
        }
    }
}
