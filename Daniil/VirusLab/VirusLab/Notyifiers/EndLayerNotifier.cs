using System;
using System.Net.Http.Headers;

namespace VirusLab
{
    /// <summary>
    /// Оповещатель полного влома системы
    /// </summary>
    internal class EndLayerNotifier : IReactProtectionFall
    {
        public int LayerReactionNumber { get; private set; }
        public string Message { get; set; }

        public EndLayerNotifier(int layerReactionNumber)
        {
            LayerReactionNumber = layerReactionNumber;
        }
        public void OnProtectionFall(object skyda, ProtectionFallEventArgs args)
        {
            if (LayerReactionNumber == args.FalledProtectionNumber)
            {
                TimeSpan dif = args.System.Date -  new DateTime(1, 1, 1);
                Message = $"Система {args.System.Title} прорвана вирусом {skyda} за {dif.Days} дней";
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
