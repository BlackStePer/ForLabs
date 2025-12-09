using SmartPhone8.Product;
using System;

namespace SmartPhone8
{
    internal class Customer
    {
        public byte GentleRate { get; private set; }
        public string FullName { get; private set; }
        public Transformator TransformModule { get; set; }
        public GentleSmartphone Smartphone { get; set; }
        public Tablet Tablet { get; set; }

        private static Random rnd = new Random();

        public Customer(string name)
        {
            GentleRate = rnd.Next(0, 2) == 0 ? Convert.ToByte(rnd.Next(1, 11)) : Convert.ToByte(rnd.Next(30, 41));
            FullName = name;
        }
    }
}
