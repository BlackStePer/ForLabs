using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipVUZ {
    internal class Soldier : Department {
        public Soldier(string title, int numberOfPositions) : base(title, numberOfPositions) { }

        public override void TraineeDistribution(List<Student> candidates)
        {
            foreach (Student student in candidates[..])
            {
                if (true)
                    if (TraineeDistribution(student))
                    {
                        selectedСandidates.Add(student);
                        candidates.Remove(student);
                    }
            }
        }

    }
}
