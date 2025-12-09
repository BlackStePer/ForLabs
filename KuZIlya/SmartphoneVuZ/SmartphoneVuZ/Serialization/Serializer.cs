using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace SmartphoneVuZ.Serialization {
    internal class Serializer {
        public string Path { get; init; }
        public Serializer(string path) => Path = path;
        public void Serialize<T>(T value)
        {
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, value);
            }
        }
    }
}