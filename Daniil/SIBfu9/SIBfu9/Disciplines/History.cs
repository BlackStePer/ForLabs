using SIBfu9.IResultGetters;
using System;

namespace SIBfu9.Disciplines
{
    internal class History : Discipline, IHaveFinalControll, IHavePractice
    {
        public override string Name { get; } = "История";
        public int PassingScore { get; } = 50;
        public int PracticeCount { get; } = 5;

        bool IHaveFinalControll.Check(int count)
        {
            return count >= PassingScore;
        }

        bool IHavePractice.Check(int count)
        {
            return count >= PracticeCount;
        }
    }
}
