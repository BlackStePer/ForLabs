using System;

namespace SmartPhone8.Product
{
    internal class Tablet
    {
        public int SerialNumber { get; private set; }
        public Tablet(int id)
        {
            SerialNumber = id;
        }
    }
}
