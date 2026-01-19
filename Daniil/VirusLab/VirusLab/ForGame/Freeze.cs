using System;

namespace VirusLab.ForGame
{
    /// <summary>
    /// Собираемая звездочка заморозки
    /// </summary>
    internal class Freeze
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Freeze(int x, int y)
        {
            X = x; Y = y;
        }
    }
}
