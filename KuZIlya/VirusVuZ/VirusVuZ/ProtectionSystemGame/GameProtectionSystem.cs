using System.Text;
using VirusVuZ.ProtectionSystemGame.Notifiers;
using VirusVuZ.SkydaGame;

namespace VirusVuZ.ProtectionSystemGame
{
    /// <summary>
    /// ProtectionSystem для игры
    /// </summary>
    internal class GameProtectionSystem : ProtectionSystem
    {
        public GameProtectionSystem(string title) : base(title)
        {
            Layers =
            [
                new ProtectionLayer("СЛОЙ ОТРИЦАНИЯ", 100, 10, new BasicLayerNotifier(0, "СЛОЙ ОТРИЦАНИЯ")),
                new ProtectionLayer("СЛОЙ ГНЕВА", 80, 5,new BasicLayerNotifier(1, "СЛОЙ ГНЕВА")),
                new ProtectionLayer("СЛОЙ ТОРГА", 100, 10, new BasicLayerNotifier(2, "СЛОЙ ТОРГА")),
                new ProtectionLayer("СЛОЙ ДЕПРЕССИИ", 80, 5,new BasicLayerNotifier(3, "СЛОЙ ДЕПРЕССИИ")),
                new ProtectionLayer("СЛОЙ ПРИНЯТИЯ", 60, 0,new EndLayerNotifier(4, "СЛОЙ ПРИНЯТИЯ"))
            ];
        }
        public override List<ProtectionLayer> Layers { get; }
        public override int ProtectionLayerNumber => Layers.Count;
        public override int FalledProtectionLayerNumber => Layers.FindAll(layer => layer.Health <= 0 && layer.IsBreached).Count;
        /// <summary>
        /// Защита от конкретной AttackInfo
        /// </summary>
        /// <param name="skyda">Объект скуды</param>
        /// <param name="stringBuilder">Информация о процессе защиты</param>
        /// <param name="attacks">Список конкретных атак</param>
        public void Defense(Skyda skyda, out StringBuilder stringBuilder, params List<AttackInfo> attacks)
        {
            stringBuilder = new();
            foreach (AttackInfo attack in attacks)
                foreach (ProtectionLayer layer in Layers)
                    if (layer.Health > 0)
                    {
                        stringBuilder.AppendLine($"SKYDA ИСПОЛЬЗУЕТ {attack} ПРОТИВ {layer.Name}");
                        layer.TakeDamage(attack.Power);
                        if (layer.Health <= 0)
                        {
                            layer.Health = 0;
                            stringBuilder.AppendLine($"И ПРОЧНОСТЬ {layer.Name} ПАДАЕТ ДО НУЛЯ!!!");
                        }
                        else
                            stringBuilder.AppendLine($"И У {layer.Name} ОСТАЕТСЯ {layer.Health} ЕДЕНИЦ ЗДОРОВЬЯ");
                        break;
                    }
                    else if (!layer.IsBreached)
                    {
                        skyda.Attack(layer);
                        stringBuilder.AppendLine($"СКУДА СОВЕРШАЕТ ОСОБУЮ АТАКУ ПРОТИВ ОСЛАБЛЕННОГО {layer.Name}");
                        if (layer.IsBreached)
                            stringBuilder.AppendLine($"И СЛОЙ УНИЧТОЖЕН!!!");
                        else
                            stringBuilder.AppendLine($"НО СЛОЮ ХОТЬ БЫ ХНЫ!!!");
                        break;
                    }
                    else
                        continue;
        }
        public override bool GetAttack()
        {
            ProtectionLayer? sub = Layers.FirstOrDefault(l => l.Health == 0 && !l.IsBreached);
            if (Layers.FirstOrDefault(l => l.Health == 0 && !l.IsBreached) != null) return base.GetAttack();
            return true;
        }
    }
}
