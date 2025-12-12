using System;
using System.Text.Json.Serialization;

namespace SmartphoneVuZ.FactoryClasses {
    
    
    
    // <summary>
    /// СуперСенсер для СуперСмартфона
    /// </summary>
    internal class TactileSensor {
        [JsonInclude]
        public byte Sensitivity { get; private set; }

        private static Random rnd = new Random();
        public TactileSensor() => Sensitivity = (byte)rnd.Next(11, 16);
    }
}
