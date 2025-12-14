using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    /// <summary>
    /// Класс, описывающий среднестатистический экзамен
    /// </summary>
    internal class Exam {
        private static Random random = new Random();
        public static List<Discipline> disciplines = new List<Discipline>() { new English(), new History(10, 70), new MathAnalize(90), new Programming(52), new RussianLanguage() };
        public int RequiredPoints { get; private set; }
        public Exam(int requiredPoints) => RequiredPoints = requiredPoints;
        /// <summary>
        /// Начинает экзамен
        /// </summary>
        /// <param name="student">Текущий студент</param>
        /// <param name="discipline">Текущая дисциплина</param>
        /// <param name="success">Успешно/неуспешно</param>
        /// <returns>Строку, содержащую процесс экзамена</returns>
        public string StartExam(Student student,Discipline discipline, out bool success)
        {
            string message = "";
            success = false;
            if (student.examIsPassed[discipline])
                return message;
            int studentScore;
            if (student.isReadyForExam[discipline])
            {
                studentScore = random.Next(80, 100);
                message += $"Студент {student.Name} подготовился к экзамену!!!\n";
            }
            else
            {
                studentScore = random.Next(30, 100);
                message += $"Студент {student.Name} не счёл нужным готовиться к экзамену...\n";
            }
            if (studentScore < RequiredPoints)
            {
                message += $"И студент {student.Name} не смог сдать экзамен!!!\n";
                message += student.GiveBribe(discipline, out success);
            }
            if (studentScore >= RequiredPoints || success)
            {
                message += $"И {student.Name} СДАЁТ ЭКЗАМЕН!!!";
                success = true;
                return message;
            }
            else
                message += $"И {student.Name} ЗАБИРАЮТ В АРМИЮ!!! (Ну или просто отчисляют)";
            return message;
        }

    }
}
