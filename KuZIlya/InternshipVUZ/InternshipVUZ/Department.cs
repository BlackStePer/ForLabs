using System;

namespace InternshipVUZ {
    /// <summary>
    /// Класс, описывающий направление стажировки
    /// </summary>
    internal abstract class Department {
        /// <summary>
        /// Название направления
        /// </summary>
        public string Title { get; init; }
        /// <summary>
        /// Список стажирующихся
        /// </summary>
        public List<Student> Trainees { get; private set; }
        /// <summary>
        /// Количество мест на стажировку
        /// </summary>
        public int NumberOfPositions { get; init; }
        protected Department(string title,int numberOfPositions)
        {
            Title = title;
            NumberOfPositions = numberOfPositions;
            Trainees = new List<Student>();
        }
        /// <summary>
        /// Метод, проверяющий, готовы ли кандидаты к стажировке
        /// </summary>
        /// <param name="candidates">Список кандидатов</param>
        /// <param name="canBeTrainee"></param>
        public virtual void TraineeDistribution(List<Student> candidates)
        {
            List<Student> _candidates = new List<Student>(candidates);
            foreach (Student student in _candidates)
                if (student.CourseNumber >= 2)
                {
                    if (TraineeDistribution(student))
                        candidates.Remove(student);
                }
        }
        /// <summary>
        /// Метод. Проверяет, готов ли студент к стажировке. В случае готовности, добавляет его в список стажирующихся
        /// </summary>
        /// <param name="student">Объект студента</param>
        /// <returns>true если прошёл, иначе false</returns>
        /// <exception cref="ArgumentOutOfRangeException">Бросается, если кол-во стажирующихся больше, чем мест на стажировку</exception>
        protected bool TraineeDistribution(Student student)
        {
            if (Trainees.Count > NumberOfPositions)
                //throw new ArgumentOutOfRangeException("Кол-во стажирующихся больше, чем мест на стажировку");
                return false;
            Trainees.Add(student);
            return true;
        }
        /// <summary>
        /// Возвращает всех студентов-добровольцев
        /// </summary>
        /// <returns>Строка. Состоит из студентов-добровольцев</returns>
        public string PrintTrainees()
        {
            string message = "";
            foreach (var trainee in Trainees)
                message += trainee.ToString() + "\n";
            return message;
        }
        public override string ToString() {
            string message = "";
            message += $"На направление {Title} желают следующие обучающиеся:\n";
            foreach (var trainee in Trainees)
            {
                message += trainee.ToString() + "\n";
            }
            return message;

        }
    }
}
