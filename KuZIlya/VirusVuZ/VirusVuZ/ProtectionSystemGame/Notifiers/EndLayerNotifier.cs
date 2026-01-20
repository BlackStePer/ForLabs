using VirusVuZ.SkydaGame;

namespace VirusVuZ.ProtectionSystemGame.Notifiers
{
    /// <summary>
    /// Конечный слой
    /// </summary>
    internal class EndLayerNotifier : IReactProtectionFall
    {
        public DateTime AttackStartDay { get; private set; }
        public string Message { get; set; }
        public int LayerReactorNumber { get; set; }
        public string Name { get; }
        public EndLayerNotifier(int lastLayerNumber, string name)
        {
            AttackStartDay = DateTime.Now.Date;
            LayerReactorNumber = lastLayerNumber;
            Name = name;
        }
        public void OnProtectionFall(object sender, ProtectionFallEventArgs e)
        {
            if (e.FalledProtectionLayersNumber - 1 == LayerReactorNumber)
                Message += $" Атака продлилась {(e.ProtectionSystem.Date - DateTime.Now).Days + 1} дней... {Name.ToLower()} пал... Система пала...";
        }
    }
}
