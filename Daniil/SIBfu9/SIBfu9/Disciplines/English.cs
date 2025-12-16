using SIBfu9.IResultGetters;
using System;

namespace SIBfu9.Disciplines
{
    internal class English : Discipline, IHaveFinalControll
    {
        public override string Name { get; } = "Английский";

        public int PassingScore { get; } = 90;

        bool IHaveFinalControll.Check(int count)
        {
            return count >= PassingScore;
        }
    }
}
