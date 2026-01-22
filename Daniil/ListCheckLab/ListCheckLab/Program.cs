#define Test5
using ListCheckLab.Attributes;
using ListCheckLab.ForTests;
using System;
using System.Collections.Generic;

namespace ListCheckLab
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            List<object> oldList = new List<object>()
            {
                new TestObject(1, 1, 1),
                new TestObject(1, 1, 1),
                new TestObject(1, 1, 1)
            };
            List<object> newList = new List<object>()
            {
                new TestObject(1, 1, 1),
                new TestObject(1, 1, 1)
            };
#if Test2
            newList.Add(new TestObject(1, 2, 1));
#elif Test3
            newList.Add(new AnotherType(1, 1, 1));
#elif Test4
            newList.Add(new NotComparable_Object(1, 1, 1));
#elif Test5
            newList.Add(new TestObject(1, 1, 1));
#endif
            ListChecker c = new ListChecker(oldList);
            Console.WriteLine(c.СompareLists(newList));
        }
    }
}
