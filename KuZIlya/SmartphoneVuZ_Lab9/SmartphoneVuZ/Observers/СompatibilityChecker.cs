using SmartphoneVuZ.FactoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneVuZ.Observers {
    /// <summary>
    /// Подбирает клиенту телефон
    /// </summary>
    internal class СompatibilityChecker {
        public Customer Customer { get; private set; }
        public FactoryInformator Informator { get; private set; }
        public List<GentleSmartphone> Smartphones { get; private set; }
        public СompatibilityChecker(Customer customer, FactoryInformator informator, List<GentleSmartphone> smartphones)
        {
            Customer = customer;
            Informator = informator;
            Smartphones = smartphones;
        }
        /// <summary>
        /// Проверяет, подходит ли телефон конкретному клиенту. Если находит подходящий телефон (или подходящий телефон + трансформатор), то продаёт его
        /// </summary>
        public void Check()
        {
            foreach (var smartphone in Smartphones) // Подбор без трансформатора
                if (Customer.GentleRate / smartphone.Sensor.Sensitivity >= 1 && Customer.GentleRate / smartphone.Sensor.Sensitivity <= 1.5 ||
                        smartphone.Sensor.Sensitivity / Customer.GentleRate >= 1 && smartphone.Sensor.Sensitivity / Customer.GentleRate <= 1.5)
                {
                    Customer.Smartphone = smartphone;
                    Informator.RemoveObserver(Customer);
                    Smartphones.Remove(smartphone);
                    return;
                }
            foreach (var smartphone in Smartphones) // Подбор с трансформатором
                if (Customer.GentleRate / smartphone.Sensor.Sensitivity > 1.5 && Customer.GentleRate / smartphone.Sensor.Sensitivity <= 2)
                {
                    Customer.Smartphone = smartphone;
                    Customer.TransformModule = new Transformator(TransformatorType.Multiplier);
                    Informator.RemoveObserver(Customer);
                    Smartphones.Remove(smartphone);
                    break;
                }
                else if (smartphone.Sensor.Sensitivity / Customer.GentleRate > 1.5 && smartphone.Sensor.Sensitivity / Customer.GentleRate <= 2)
                {
                    Customer.Smartphone = smartphone;
                    Customer.TransformModule = new Transformator(TransformatorType.Devider);
                    Informator.RemoveObserver(Customer);
                    Smartphones.Remove(smartphone);
                    break;
                }
        }
    }
}
