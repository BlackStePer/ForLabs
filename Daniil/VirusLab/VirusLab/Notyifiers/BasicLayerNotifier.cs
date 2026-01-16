using System;

namespace VirusLab
{
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
                Message = $"В системе {args.System.Title} прорва уровень защиты {LayerReactionNumber} вирусом {skyda}";
                Console.WriteLine(Message);
            }
        }
        public void Subscribe(Skyda skyda)
        {
            skyda.ProtectionFall += OnProtectionFall;
        }
    }
}
