using System;

namespace VirusLab
{
    /// <summary>
    /// Вирус
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    internal delegate void ProtetctionFallHandler(object sender, ProtectionFallEventArgs args);
    internal class Skyda
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int FreezeTime { get; set; }
        public string Title { get; private set; }
        public int KnownFalledProtectionLayerNumber { get; private set; } = 0;
        public ProtectionSystem ProtectionSystem { get; private set; }
        public event ProtetctionFallHandler ProtectionFall;
        
        public Skyda(string title, int x, int y, ProtectionSystem sys)
        {
            Title = title;
            X = x; Y = y;
            ProtectionSystem = sys;
        }
        /// <summary>
        /// Атака на систему
        /// </summary>
        public virtual void Attack()
        {
            ProtectionSystem.GetAttack();
        }

        /// <summary>
        /// Проверка уровня взлома
        /// </summary>
        public virtual void NotifyProtectionFall()
        {
            if(ProtectionSystem.ProtectionCheck())
            {
                KnownFalledProtectionLayerNumber += 1;
                ProtectionFall.Invoke(this, new ProtectionFallEventArgs(KnownFalledProtectionLayerNumber, ProtectionSystem));
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
