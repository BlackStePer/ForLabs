using VirusVuZ.ProtectionSystemGame;

namespace VirusVuZ.SkydaGame
{
    /// <summary>
    /// Доп инфа для событий
    /// </summary>
    internal class ProtectionFallEventArgs : EventArgs
    {
        public int FalledProtectionLayersNumber { get; set; }
        public ProtectionSystem ProtectionSystem { get; set; }
        public ProtectionFallEventArgs(int falledLayers, ProtectionSystem system)
        {
            FalledProtectionLayersNumber = falledLayers;
            ProtectionSystem = system;
        }
    }
    internal delegate void ProtectionFallHandler(object sender, ProtectionFallEventArgs e);
}
