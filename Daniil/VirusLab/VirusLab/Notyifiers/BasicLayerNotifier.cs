using System;

namespace VirusLab
{
    /// <summary>
    /// Оповещатель влома уровня защиты системы
    /// </summary>
    internal class BasicLayerNotifier : IReactProtectionFall
    {
        public int LayerReactionNumber { get; private set; }
        public string Message { get; set; }

        public BasicLayerNotifier(int layerReactionNumber)
        {
            LayerReactionNumber = layerReactionNumber; 
        }
        
        public void OnProtectionFall(object skyda, ProtectionFallEventArgs args)
        {
            if(LayerReactionNumber == args.FalledProtectionNumber)
            {
                Message = $"В системе {args.System.Title} прорван уровень защиты {LayerReactionNumber} вирусом {skyda}";
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (char c in Message)
                {
                    Console.Write(c);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Subscribe(Skyda skyda)
        {
            skyda.ProtectionFall += OnProtectionFall;
        }
    }
}
