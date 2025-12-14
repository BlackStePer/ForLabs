using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// Доп информация о заводе (необходима для приобретения и продажи телефонов)
    /// </summary>
    internal class FactoryInformation {
        public FactoryInformator Informator { get; private set; }
        public List<GentleSmartphone> Smartphones { get; private set; }
        public FactoryInformation(FactoryInformator informator, List<GentleSmartphone> smartphones)
        {
            Informator = informator;
            Smartphones = smartphones;
        }
    }
}
