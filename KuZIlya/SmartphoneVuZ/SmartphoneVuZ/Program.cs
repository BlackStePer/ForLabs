#define Test1
#define Test2
using SmartphoneVuZ.FactoryClasses;
using SmartphoneVuZ.Observers;
namespace SmartphoneVuZ {

    internal class Program {
        public static void Main(string[] args)
        { 
            try
            {
                #region Test1 (Кол-во смартфонов > Кол-во людей)
#if Test1
                Factory factory1 = new Factory();
                Customer customer1 = new Customer("Вася", factory1.informator);
                Customer customer2 = new Customer("Петя", factory1.informator);
                Customer customer3 = new Customer("МАКС", factory1.informator);
                Shop shop1 = new Shop("Пятёрочка", factory1.informator);
                factory1.CreatePhones(15);
                factory1.SaleSmartphone();
                shop1.Smartphones.Clear(); // Типо все смартфоны продали
                shop1.BuyMorePhones(factory1.informator); // Если закоментировать эту строку, магазин не будет добирать телефоны, так как у него их уже было 10 и подписка на рекламщика телефонов исчезла
                factory1.CreatePhones(7);
                factory1.SaleSmartphone(); // На складе остаётся минимум 2 смартфона с первой распродажи, при добавлении 7 у магазина получается от 9 телефонов
                Console.WriteLine(customer1);
                Console.WriteLine(customer2);
                Console.WriteLine(customer3);
                Console.WriteLine(shop1); 
                // По идее, список смартфонов и сами смартфоны хранятся в factory1 полностью композиционно, так что при очистке factory1 сборщиком мусора весь список должен уничтожаться сам. Я попробовал раз 5 вызвать деструктор (сборщиком мусора, реализацией Dispose()), однако у меня так и не получилось =(
#endif
                #endregion
                Console.WriteLine();
                Console.WriteLine();
                #region Test2 (Кол-во смартфонов < Кол-во людей)
#if Test2
                Factory factory = new Factory();
                
                Customer customer4 = new Customer("Вася", factory.informator);
                Customer customer5 = new Customer("Петя", factory.informator);
                Customer customer6 = new Customer("МАКС", factory.informator);
                Shop shop2 = new Shop("Пятёрочка", factory.informator);
                factory.CreatePhones(5);
                factory.SaleSmartphone();
                factory.CreatePhones(5); 
                factory.SaleSmartphone();
                Console.WriteLine(customer4);
                Console.WriteLine(customer5);
                Console.WriteLine(customer6);
                Console.WriteLine(shop2);
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
#endif
                #endregion

        }

    }
}




