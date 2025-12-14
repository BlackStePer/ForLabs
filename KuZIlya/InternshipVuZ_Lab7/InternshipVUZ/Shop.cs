using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipVUZ {
    internal class Shop : Department {
        public Shop(string title, int numberOfPositions) : base(title, numberOfPositions) { }
        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                if (student.Achievement <= 52 && student.Achievement >= 0)
                    if (TraineeDistribution(student))
                    {
                        selectedСandidates.Add(student);
                        candidates.Remove(student);
                    }
            }
        }
    }
}
