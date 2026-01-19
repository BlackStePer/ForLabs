using System;

namespace VirusLab
{
    /// <summary>
    /// Защитник системы
    /// </summary>
    internal class Defender
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Defender(int x, int y) 
        {
            X = x; Y = y;
        }
    }
}
