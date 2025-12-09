using Microsoft.VisualBasic;
using SmartphoneVuZ.Serialization;
namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// Производит телефоны и удаляет их из склада
    /// </summary>
    internal class Factory {
        public readonly FactoryInformator informator;
        // Удаление всех объектов происходит при уничтожении объекта factory
        private List<GentleSmartphone> smartphones = new List<GentleSmartphone>();
        public List<GentleSmartphone> Smartphones
        {
            get 
            {
                string p = "Smartphones.json";
                new Serializer(p).Serialize(smartphones);
                List<GentleSmartphone> smartphones1 = new List<GentleSmartphone>();
                if (!new Deserializer(p).Deserialize(ref smartphones1))
                    throw new Exception("Незвестная ошибка");
                return smartphones1;
            }
            private set { smartphones = value; }
        }
        public Factory() => informator = new FactoryInformator(Smartphones);
        /// <summary>
        /// Создаёт count телефонов и добавляет их в список smartphones
        /// </summary>
        /// <param name="count"></param>
        public void CreatePhones(int count)
        {
            for (int i = 0; i < count; i++)
                smartphones.Add(new GentleSmartphone());
        }
        /// <summary>
        /// Пытается продать телефоны всем клиентам
        /// </summary>
        public void SaleSmartphone()
        {
            informator.Smartphones = Smartphones;
            informator.NotifyObservers();
            foreach (var smartphone in smartphones[..])
                if (!informator.Smartphones.Contains(smartphone))
                    smartphones.Remove(smartphone);
        }
    }
}