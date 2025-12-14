using System;

namespace InternshipVUZ {
    internal class Traineeship {
        private static int id = 0;
        /// <summary>
        /// ID текущей стажировки
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Список кандидатов
        /// </summary>
        public List<Student> Candidates { get; private set; }
        /// <summary>
        /// Список направлений стажировки
        /// </summary>
        public List<Department> Departments { get; private set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="students">Список студентов, готовых стать кандидатами</param>
        /// <param name="departments">Список возможных стажировок</param>
        /// <exception cref="ArgumentNullException">null вместо ссылки на объект студента</exception>
        public Traineeship(List<Student>? students = null, List<Department>? departments = null)
        {
            ID = id++;
            Candidates = new List<Student>();
            Departments = new List<Department>();
            if (students != null) 
                foreach (var student in students)
                    if (student != null)
                        Candidates.Add(student);
                    else
                        throw new ArgumentNullException("null вместо ссылки на объект студента");
            if (departments != null) 
                foreach (var department in departments)
                    if (department != null)
                        Departments.Add(department);
                    else
                        throw new ArgumentNullException("null вместо ссылки на объект департамента");
        }
        /// <summary>
        /// Метод, добавляет студентов в список желающих
        /// </summary>
        /// <param name="students">Добровольцы</param>
        /// <exception cref="ArgumentNullException">null вместо ссылки на объект студента</exception>
        public void AddNewCandidates(params List<Student> students)
        {
            foreach (var student in students)
                if (student != null)
                    Candidates.Add(student);
                else
                    throw new ArgumentNullException("null вместо ссылки на объект студента");
        }
        /// <summary>
        /// Метод, добавляет направления стажировки
        /// </summary>
        /// <param name="departments">Объект направления</param>
        /// <exception cref="ArgumentNullException">null вместо ссылки на объект студента</exception>
        public void AddNewDepartment(params List<Department> departments)
        {
            foreach (var department in departments)
                if (department != null)
                    Departments.Add(department);
                else
                    throw new ArgumentNullException("null вместо ссылки на объект департамента");
        }
    }
}
