using System;

namespace VirusLab
{
    internal interface IReactProtectionFall
    {
        int LayerReactionNumber { get; }
        string Message { get; set; }

        void Subscribe(Skyda skyda);
        void OnProtectionFall(object skyda, ProtectionFallEventArgs args);

    }
}
