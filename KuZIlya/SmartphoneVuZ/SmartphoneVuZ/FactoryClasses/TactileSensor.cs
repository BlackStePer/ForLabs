using System;

namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// СуперСенсер для СуперСмартфона
    /// </summary>
    internal class TactileSensor {
        public byte Sensitivity { get; private set; }

        private static Random rnd = new Random();
        public TactileSensor() => Sensitivity = (byte)rnd.Next(11, 16);
    }
}
