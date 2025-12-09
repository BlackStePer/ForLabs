using System;


namespace SmartPhone8
{
    internal class TactileSensor
    {
        public byte Sensivity { get; private set; }

        private static Random rnd = new Random();

        public TactileSensor()
        {
            Sensivity = Convert.ToByte(rnd.Next(11, 21));
        }
    }
}
