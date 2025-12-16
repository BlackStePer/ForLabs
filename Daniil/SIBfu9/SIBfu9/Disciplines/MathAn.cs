using SIBfu9.IResultGetters;
using System;

namespace SIBfu9.Disciplines
{
    internal class MathAn : Discipline, IHaveFinalControll
    {
        public override string Name { get; } = "Мат. анализ";
        public int PassingScore { get; } = 70;
        public bool Check(int count)
        {
            return count >= PassingScore;
        }
    }
}
