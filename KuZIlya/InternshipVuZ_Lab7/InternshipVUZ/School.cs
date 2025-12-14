using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipVUZ {
    internal class School : Department {
        public School(string title, int numberOfPositions) : base(title, numberOfPositions) { }

        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                ProgrammingLanguage language = student.ProgrammingLanguage;
                if (student.Achievement >= 85)
                    if (TraineeDistribution(student))
                    {
                        selectedСandidates.Add(student);
                        candidates.Remove(student);
                    }
            }
        }
    }
}
