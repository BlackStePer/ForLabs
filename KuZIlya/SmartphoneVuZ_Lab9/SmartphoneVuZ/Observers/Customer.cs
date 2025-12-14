using SmartphoneVuZ.FactoryClasses;
using SmartphoneVuZ.Interfaces;
using System;

namespace SmartphoneVuZ.Observers {
    /// <summary>
    /// Клиент, способный получить один телефон и один трансформатор
    /// </summary>
    internal class Customer : IObserver {
        private static Random rnd = new Random();
        public byte GentleRate { get; private set; }
        public string FullName { get; private set; }
        private Transformator transformModule;
        public Transformator TransformModule
        {
            get => transformModule;
            set
            {
                if (transformModule == null)
                    transformModule = value;
            }
        }
        private GentleSmartphone smartphone;
        public GentleSmartphone Smartphone
        {
            get => smartphone;
            set
            {
                if (smartphone == null)
                    smartphone = value;
            }
        }
        СompatibilityChecker checker;
        public Customer(string fullName, IObservable factoryInformator)    
        {
            GentleRate = rnd.Next(0, 2) == 0 ? Convert.ToByte(rnd.Next(1, 25)) : Convert.ToByte(rnd.Next(15, 50));
            FullName = fullName;
            factoryInformator.AddObserver(this);
        }
        public void Update(FactoryInformation information)
        {
            checker = new СompatibilityChecker(this, information.Informator, information.Smartphones);
            checker.Check();
        }
        public override string ToString() 
        {
            string message = $"{FullName} c чувствительностью {GentleRate} попытался получить телефон...";
            if (Smartphone == null)
                return message + "\nОднако покупатель так и не смог найти подходящего устройства, поэтому ожидает новой поставки!!!\n";
            if (transformModule == null)
                return message + $"\nИ клиент без проблем нашёл себе новомодный смартфон: {Smartphone}\n";
            return message + $"\nНо он не смог подобрать подходящий телефон, однако супер-пупер трансформатор {transformModule} помог ему начать пользоваться новомодным смартфоном {Smartphone}\n";
        }
    }
}