using SmartphoneVuZ.FactoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneVuZ.Interfaces {
    /// <summary>
    /// Интерфейс наблюдателя
    /// </summary>
    internal interface IObserver {
        /// <summary>
        /// Реакция на информацию о продаже телефона
        /// </summary>
        /// <param name="information"></param>
        void Update(FactoryInformation information);
    }
}
