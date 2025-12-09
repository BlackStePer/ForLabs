using Microsoft.VisualBasic;
using SmartphoneVuZ.Interfaces;
using System;

namespace SmartphoneVuZ.FactoryClasses {
    /// <summary>
    /// Работает с клиентами конкретного завода
    /// </summary>
    internal class FactoryInformator : IObservable {
        public List<IObserver> Observers { get; private set; } = new List<IObserver>();
        public List<GentleSmartphone> Smartphones { get; set; }
        public FactoryInformator(List<GentleSmartphone> smartphones) => Smartphones = smartphones;
        public void AddObserver(IObserver observer) => Observers.Add(observer);
        public void RemoveObserver(IObserver observer)
        {
            if (!Observers.Contains(observer))
                throw new ArgumentException("Такого человека нет в списках покупателей");
            Observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in Observers[..])
                observer.Update(new FactoryInformation(this, Smartphones));
        }
    }
}
