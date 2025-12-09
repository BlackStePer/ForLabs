using SmartphoneVuZ.FactoryClasses;
using SmartphoneVuZ.Observers;

namespace SmartphoneVuZ {
    internal class Program {
        public static void Main(string[] args)
        { 
            try
            {
                Factory factory = new Factory();
                Customer customer1 = new Customer("Вася", factory.informator);
                Customer customer2 = new Customer("Петя", factory.informator);
                Customer customer3 = new Customer("МАКС", factory.informator);
                Shop shop = new Shop("Пятёрочка", factory.informator);
                factory.CreatePhones(5);
                factory.SaleSmartphone();
                factory.CreatePhones(5);
                factory.SaleSmartphone();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                GentleSmartphone.idSerializer.Serialize(GentleSmartphone.currentID);
                Transformator.idSerializer.Serialize(Transformator.currentID);
            }

        }

    }
}




