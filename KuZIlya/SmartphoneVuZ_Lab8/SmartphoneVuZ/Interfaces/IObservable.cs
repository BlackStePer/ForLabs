using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneVuZ.Interfaces {
    /// <summary>
    /// Интерфейс наблюдаемого объекта
    /// </summary>
    internal interface IObservable {
        /// <summary>
        /// Добавляет клиента в очередь за телефоном
        /// </summary>
        /// <param name="observer"></param>
        void AddObserver(IObserver observer);
        /// <summary>
        /// Удаляет конкретного клиента из очереди
        /// </summary>
        /// <param name="observer"></param>
        void RemoveObserver(IObserver observer);
        /// <summary>
        /// Оповещает всех клиентов о том, что ведётся продажа телефонов
        /// </summary>
        void NotifyObservers();
    }
}
