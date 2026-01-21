namespace VirusVuZ.ProtectionSystemGame
{
    /// <summary>
    /// Класс, описывает системы безопасности
    /// </summary>
    internal abstract class ProtectionSystem
    {
        public string Title { get; set; }
        public abstract List<ProtectionLayer> Layers { get; }
        public DateTime Date { get; protected set; }
        public abstract int ProtectionLayerNumber { get; }
        public abstract int FalledProtectionLayerNumber { get; }
        public ProtectionSystem(string title)
        {
            Title = title;
            Date = DateTime.Now;
        }
        /// <summary>
        /// Продержалась ли система дополнительный день
        /// </summary>
        public virtual void ProtectionCheck() => Date = Date.AddDays(1);
        /// <summary>
        /// При 0 хп слоя определяет, падёт он или нет
        /// </summary>
        /// <returns></returns>
        public virtual bool GetAttack()
        {
            Random rand = new();
            bool isBreached = rand.Next(100) < 50;
            if (!isBreached)
                ProtectionCheck();
            return isBreached;
        }
        /// <summary>
        /// При 0 хп слоя его падение определяется через value
        /// </summary>
        /// <param name="value">Падёт слой или нет</param>
        /// <returns>Пал слой или нет</returns>
        public bool GetAttack(bool value)
        {
            if (!value)
                ProtectionCheck();
            return value;
        }
    }
}
