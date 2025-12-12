using SmartphoneVuZ.FactoryClasses;
using SmartphoneVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneVuZ.Observers {
    /// <summary>
    /// Клиент, способный приобрести до 10 смартфонов для дальнейшего экспорта. Не может приобретать трансформеры
    /// </summary>
    internal class Shop : IObserver {
        public string Name { get; private set; }
        public Shop(string name, IObservable factoryInformator) 
        { 
            Name = name;
            factoryInformator.AddObserver(this);
        }
        public List<GentleSmartphone> Smartphones { get; private set; } = new List<GentleSmartphone>();
        public void Update(FactoryInformation information)
        {
            foreach (var smartphone in information.Smartphones[..])
                if (Smartphones.Count < 10)
                {
                    Smartphones.Add(smartphone);
                    information.Smartphones.Remove(smartphone);
                }
                else
                {
                    information.Informator.RemoveObserver(this);
                    break;
                }
        }
        /// <summary>
        /// Встаёт в очередедь, если смартфонов недостаточно
        /// </summary>
        /// <param name="factoryInformator">Оповещатель</param>
        public void BuyMorePhones(IObservable factoryInformator)
        {
            if (Smartphones.Count < 10)
                factoryInformator.AddObserver(this);
        }
        public override string ToString()
        {
            string message = "";
            if (Smartphones.Count == 10)
            {
                message += $"Магазин {Name} приобрёл достаточное кол-во телефонов для распространения их по всему миру.\nКонкретный список приобретённых телефонов:\n";
                foreach (var smartphone in Smartphones)
                    message += "\n" + smartphone;
            }
            else if (Smartphones.Count == 0)
                return $"Магазин {Name} не получил ни одного телефона... {Name} ожидает новой поставки!!!\n";
            else
            {
                message += $"Магазин {Name} не смог приобрести достаточное кол-во телефонов для распространения их по всему миру, поэтому будет ожидать дальнейших поставок.\nСписок присутствующих на складе телефонов:\n";
                foreach (var smartphone in Smartphones)
                    message += "\n" + smartphone;
            }
            return message + "\n";
        }
    }
}
