using System;
using ListCheckLab.Attributes;

namespace ListCheckLab.ForTests
{
    [NotComparable]
    /// <summary>
    /// Объект для тестов (Не читаемый)
    /// </summary>
    internal class NotComparable_Object
    {
        private int field1;

        public int field2;

        public int Field3 { get; set; }
        public NotComparable_Object(int f1, int f2, int f3)
        {
            field1 = f1;
            field2 = f2;
            Field3 = f3;
        }
    }
}
