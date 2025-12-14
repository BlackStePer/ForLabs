using SmartphoneVuZ.Serialization;
using System;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// СуперСмартфон
    /// </summary>
    internal class GentleSmartphone
    {
        public static int currentID;
        private static string path = "GentleSmartphoneID.json";
        public static Serializer idSerializer = new Serializer(path);
        public TactileSensor Sensor { get; private set; } = new TactileSensor();
        public int SerialNumber { get; private set; }
        [JsonConstructor]
        private GentleSmartphone(int serialNumber, TactileSensor sensor)
        {
            SerialNumber = serialNumber;
            Sensor = sensor;
        }
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
        // Тут я пытался заставить работать List<>.Contains(), как обычно, не получилось

        //public override int GetHashCode() => SerialNumber;
        //public bool Equals(GentleSmartphone smartphone)
        //{
        //    if (smartphone == null) return false;
        //    return SerialNumber == smartphone.SerialNumber && Sensor.Sensitivity == smartphone.Sensor.Sensitivity;
        //}
        //public static bool operator== (GentleSmartphone smartphone1, GentleSmartphone smartphone2)
        //{
        //    if (ReferenceEquals(smartphone1, null) || ReferenceEquals(smartphone2, null))
        //        return false;
        //    return smartphone1.SerialNumber == smartphone2.SerialNumber && smartphone1.Sensor.Sensitivity == smartphone2.Sensor.Sensitivity;
        //}
        //public static bool operator!= (GentleSmartphone smartphone1, GentleSmartphone smartphone2)
        //{
        //    if (ReferenceEquals(smartphone1, null) || ReferenceEquals(smartphone2, null))
        //        return false;
        //    return smartphone1.SerialNumber != smartphone2.SerialNumber && smartphone1.Sensor.Sensitivity != smartphone2.Sensor.Sensitivity;
        //}
        public override string ToString() => $"Суперсмартфон{SerialNumber} с чувствительность {Sensor.Sensitivity}";
    }
}