using System;

namespace VirusLab
{
    /// <summary>
    /// Я реагирую на взлом
    /// </summary>
    internal interface IReactProtectionFall
    {
        int LayerReactionNumber { get; }
        string Message { get; set; }

        // <summary>
        /// Подписка на событые оповещения о взломе
        /// </summary>
        /// <param name="skyda">Вирус</param>
        void Subscribe(Skyda skyda);

        /// <summary>
        /// Вывод оповещения о взломе
        /// </summary>
        /// <param name="skyda">Вирус</param>
        /// <param name="args">Параметры взлома</param>
        void OnProtectionFall(object skyda, ProtectionFallEventArgs args);

    }
}
