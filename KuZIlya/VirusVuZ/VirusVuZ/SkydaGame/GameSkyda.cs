using VirusVuZ.ProtectionSystemGame;

namespace VirusVuZ.SkydaGame
{
    /// <summary>
    /// Скуда для игры
    /// </summary>
    internal class GameSkyda : Skyda
    {
        private static readonly Random random = new();
        public List<AttackInfo> Attacks { get; set; }
        public GameSkyda(ProtectionSystem system) : base(system)
        {
            Attacks =
            [
                new AttackInfo("DDoS", random.Next(20, 40)){ ResourceCost = 25},
                new AttackInfo("Virus", random.Next(52, 53)) {ResourceCost = 52 },
                new AttackInfo("Phishing", random.Next(10, 25)) { ResourceCost = 10 },
                new AttackInfo("Miner", random.Next(25, 40)) { ResourceCost = 25 },
                new AttackInfo("KILLER Bunny", random.Next(50, 152)) { ResourceCost = 100 }
            ];
        }
        public override void Attack(ProtectionLayer layer)
        {
            bool isBreached = TargetSystem.GetAttack(true);
            layer.IsBreached = isBreached;
            if (isBreached && TargetSystem.FalledProtectionLayerNumber > KnownFalledProtectionLayerNumber)
            {
                KnownFalledProtectionLayerNumber = TargetSystem.FalledProtectionLayerNumber;
                OnProtectionFall(new ProtectionFallEventArgs(TargetSystem.FalledProtectionLayerNumber, TargetSystem));
            }
        }
    }
}
