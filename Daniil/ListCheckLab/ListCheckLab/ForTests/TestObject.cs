using System;

namespace ListCheckLab.ForTests
{
    /// <summary>
    /// Объект для тестов
    /// </summary>
    internal class TestObject
    {
        private int field1;
        
        public int field2;

        public int Field3 { get; set; }
        public TestObject(int f1, int f2, int f3) 
        { 
            field1 = f1;
            field2 = f2;
            Field3 = f3;
        }
    }
}
