using VirusVuZ.SkydaGame;

namespace VirusVuZ.ProtectionSystemGame.Notifiers
{
    internal interface IReactProtectionFall
    {
        /// <summary>
        /// Подписка на оповещение
        /// </summary>
        /// <param name="skyda">Объект скуды</param>
        void Subscribe(Skyda skyda) => skyda.ProtectionFall += OnProtectionFall;
        /// <summary>
        /// Оповещение о падении слоя
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Доп информация</param>
        void OnProtectionFall(object sender, ProtectionFallEventArgs e);
        string Message { get; set; }
        int LayerReactorNumber { get; set; }
        string Name { get; }
    }
}
