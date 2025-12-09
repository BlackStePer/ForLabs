using SmartphoneVuZ.Serialization;
using System;
using System.Numerics;
using System.Text.Json;

namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// СуперСмартфон
    /// </summary>
    internal class GentleSmartphone
    {
        public static int currentID;
        private static string path = "GentleSmartphoneID.json";
        public static Serializer idSerializer = new Serializer(path);
        public TactileSensor Sensor { get; } = new TactileSensor();
        public int SerialNumber { get; private set; }
        static GentleSmartphone() // Получает данные о текущем currentID 
        {
            Deserializer deserializer = new Deserializer(path);
            if (!deserializer.Deserialize(ref currentID))
                currentID = 0;
        }
        public GentleSmartphone()
        {
            SerialNumber = currentID;
            ++currentID;
        }
    }
}