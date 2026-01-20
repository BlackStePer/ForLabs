using VirusVuZ.SkydaGame;

namespace VirusVuZ.ProtectionSystemGame.Notifiers
{
    /// <summary>
    /// Неконечный слой
    /// </summary>
    internal class BasicLayerNotifier : IReactProtectionFall
    {
        public string Message { get; set; }
        public int LayerReactorNumber { get; set; }
        public string Name { get; }

        public BasicLayerNotifier(int layerReactorNumber, string name)
        {
            LayerReactorNumber = layerReactorNumber;
            Name = name;
        }
        public void OnProtectionFall(object sender, ProtectionFallEventArgs e)
        {
            if (e.FalledProtectionLayersNumber - 1 == LayerReactorNumber)
                Message = $"[{e.ProtectionSystem.Date:yyyy-MM-dd}] {Name} ПАЛ!!!";
        }
    }
}
