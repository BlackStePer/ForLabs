using System;

namespace SmartPhone8
{
    internal class GentleSmartphone
    {
        public TactileSensor Sensor { get; } = new TactileSensor();
        public int SerialNumber { get; private set; }
        public GentleSmartphone(int id)
        {
            SerialNumber = id;
        }
    }
}
