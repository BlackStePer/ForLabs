using System;

namespace VirusLab
{
    internal delegate void ProtetctionFallHandler(object sender, ProtectionFallEventArgs args);
    internal class Skyda
    {
        public string Title { get; private set; }
        public int KnownFalledProtectionLayerNumber { get; private set; } = 0;
        public ProtectionSystem ProtectionSystem { get; private set; }
        public event ProtetctionFallHandler ProtectionFall;

        public Skyda(string title, ProtectionSystem sys)
        {
            Title = title;
            ProtectionSystem = sys;
        }
        public virtual void Attack()
        {
            ProtectionSystem.GetAttack();
        }
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
