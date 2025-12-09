using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartphoneVuZ.Serialization {
    internal class Deserializer {
        public string Path { get; init; }
        public Deserializer(string path) => Path = path;
        public bool Deserialize<T>(ref T value)
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    value = JsonSerializer.Deserialize<T>(fs);
                    return true;
                }
                return false;
            }
        }
    }
}
