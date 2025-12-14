using SmartPhone8.Product;
using System;
using System.Collections.Generic;

namespace SmartPhone8
{
    internal class Factory
    {
        public List<Customer> Customers { get; set; }
        private List<GentleSmartphone> smarphones = new List<GentleSmartphone>();
        private List<Transformator> transformators = new List<Transformator>();
        private List<Tablet> tablets  = new List<Tablet>();

        public int[] minuses = { 0, 0, 0 };

        public Factory( int amountOfTransformators, int amountOfPhones, int amountOfTablets)
        {
            for (int id = 1; id <= amountOfPhones; id++)
            {
                smarphones.Add(new GentleSmartphone(id));
            }
            for (int id = 1; id <= amountOfTransformators; id += 2)
            {
                transformators.Add(new Transformator(id, TransformatorType.Multiplier));
                transformators.Add(new Transformator(id + 1, TransformatorType.Devider));
            }
            for (int id = 1; id <= amountOfTablets; id++)
            {
                tablets.Add(new Tablet(id));
            }
        }

        public Factory(List<Customer> cs, int amountOfTransformators, int amountOfPhones, int amountOfTablets)
        {
            Customers = cs;
            for (int id = 1; id <= amountOfPhones; id++)
            {
                smarphones.Add(new GentleSmartphone(id));
            }
            for (int id = 1; id <= amountOfTransformators * 2; id += 2)
            {
                transformators.Add(new Transformator(id, TransformatorType.Multiplier));
                transformators.Add(new Transformator(id + 1, TransformatorType.Devider));
            }
            for (int id = 1; id <= amountOfTablets; id++)
            {
                tablets.Add(new Tablet(id));
            }
        }

        /// <summary>
        /// Метод поочереди продаёт смартфоны покупателям, проверяя телефоны по порядку: Если чувствительность сенсора отличается от 
        /// аккуратности человека в 1.5 раза, то выдаёт человеку смартфон и удаляет устройство из списка телефонов. 
        /// Если же различие больше чем в 1.5 раза, но меньше либо равно 2, то человеку, помимо телефона выдается трансформатор (если он конечно есть на
        /// складе трансформаторов). Если же покупателю не подошёл не один телефон, даже с трансформатором, покупателю предлогают планшет, который
        /// подходит любому, но только если и они есть на складе, если и его нет то покупатель остаётся не с чем.
        /// !После обработки всех покупателей остатки телефонов и трансформаторов удаляются со склада!
        /// </summary>
        public void SaleSmartphone()
        {
            foreach (Customer customer in Customers)
            {
                foreach (GentleSmartphone phone in smarphones)
                {
                    if ((customer.GentleRate / phone.Sensor.Sensivity >= 1 && customer.GentleRate / phone.Sensor.Sensivity <= 1.5) ||
                        (phone.Sensor.Sensivity / customer.GentleRate >= 1 && phone.Sensor.Sensivity / customer.GentleRate <= 1.5))
                    {
                        customer.Smartphone = phone;
                        smarphones.Remove(phone);
                        minuses[1] -= 1;
                        break;
                    }
                    else if (customer.GentleRate / phone.Sensor.Sensivity > 1.5 && customer.GentleRate / phone.Sensor.Sensivity <= 2)
                    {
                        bool transWasFounded = false;
                        foreach (Transformator transformator in transformators)
                        {
                            if (transformator.TransfromType == TransformatorType.Multiplier)
                            {
                                customer.TransformModule = transformator;
                                customer.Smartphone = phone;
                                smarphones.Remove(phone);
                                minuses[1] -= 1;
                                transformators.Remove(transformator);
                                minuses[0] -= 1;
                                transWasFounded = true;
                                break;
                            }
                        }
                        if (transWasFounded)
                        {
                            break;
                        }
                    }
                    else if (phone.Sensor.Sensivity / customer.GentleRate > 1.5 && phone.Sensor.Sensivity / customer.GentleRate <= 2)
                    {
                        bool transWasFounded = false;
                        foreach (Transformator transformator in transformators)
                        {
                            if (transformator.TransfromType == TransformatorType.Devider)
                            {
                                customer.TransformModule = transformator;
                                customer.Smartphone = phone;
                                smarphones.Remove(phone);
                                minuses[1] -= 1;
                                transformators.Remove(transformator);
                                minuses[0] -= 1;
                                transWasFounded = true;
                                break;
                            }
                        }
                        if (transWasFounded)
                        {
                            break;
                        }
                    }

                }
                if (customer.Smartphone == null)
                {
                    foreach (Tablet tablet in tablets)
                    {
                        customer.Tablet = tablet;
                        tablets.Remove(tablet);
                        minuses[2] -= 1;
                        break;
                    }
                }
            }
            smarphones = new List<GentleSmartphone>();
            transformators = new List<Transformator>();
            tablets = new List<Tablet>();
        }
    }
}
