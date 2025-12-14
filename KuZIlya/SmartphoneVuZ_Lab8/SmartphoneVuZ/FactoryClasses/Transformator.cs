using SmartphoneVuZ.Serialization;
using System;
using System.Text.Json;


namespace SmartphoneVuZ.FactoryClasses {
    enum TransformatorType {
        Multiplier,
        Devider
    }
    /// <summary>
    /// Трансформатор, нужен для подбора телефона
    /// </summary>
    internal class Transformator {
        public static int currentID;
        private static string path = "TransformatorID.json";
        public static Serializer idSerializer = new Serializer(path);
        public TransformatorType TransfromType { get; private set; }
        public int SerialNumber { get; private set; }
        static Transformator()
        {
            Deserializer deserializer = new Deserializer(path);
            if (!deserializer.Deserialize(ref currentID))
                currentID = 0;
        }
        public Transformator(TransformatorType transType)
        {
            SerialNumber = currentID;
            TransfromType = transType;
            ++currentID;
        }
        public override string ToString() => $"Трансформатор{SerialNumber}";
    }
}
