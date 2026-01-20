using VirusVuZ.ProtectionSystemGame;

namespace VirusVuZ.SkydaGame
{
    /// <summary>
    /// Класс супер опасного вируса
    /// </summary>
    internal class Skyda
    {

        public event ProtectionFallHandler ProtectionFall;
        public int KnownFalledProtectionLayerNumber { get; protected set; }
        public ProtectionSystem TargetSystem { get; set; }
        public Skyda(ProtectionSystem system)
        {
            TargetSystem = system;
            KnownFalledProtectionLayerNumber = 0;
        }
        /// <summary>
        /// Осуществляет атаку конкретного слоя
        /// </summary>
        /// <param name="layer">Конкретный слой</param>
        public virtual void Attack(ProtectionLayer layer)
        {
            bool isBreached = TargetSystem.GetAttack();
            layer.IsBreached = isBreached;
            if (isBreached && TargetSystem.FalledProtectionLayerNumber > KnownFalledProtectionLayerNumber)
            {
                KnownFalledProtectionLayerNumber = TargetSystem.FalledProtectionLayerNumber;
                OnProtectionFall(new ProtectionFallEventArgs(TargetSystem.FalledProtectionLayerNumber, TargetSystem));
            }
        }
        /// <summary>
        /// Оповещаяет о падении слоя
        /// </summary>
        /// <param name="e">Доп аргументы</param>
        protected virtual void OnProtectionFall(ProtectionFallEventArgs e) => ProtectionFall?.Invoke(this, e);
        //public virtual void NotifyProtectionFall() => OnProtectionFall(new ProtectionFallEventArgs(TargetSystem.FalledProtectionLayerNumber, TargetSystem));
    }
}
