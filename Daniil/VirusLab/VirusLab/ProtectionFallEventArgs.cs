using System;

namespace VirusLab
{
    /// <summary>
    /// Компоненты взлома
    /// </summary>
    internal class ProtectionFallEventArgs : EventArgs
    {
        public int FalledProtectionNumber { get; set; }
        public ProtectionSystem System { get; set; }

        public ProtectionFallEventArgs(int num, ProtectionSystem sys)
        {
            FalledProtectionNumber = num;
            System = sys;
        }
    }
}
