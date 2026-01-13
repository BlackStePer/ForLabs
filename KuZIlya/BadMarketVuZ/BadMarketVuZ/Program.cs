

using BadMarketVuZ;
using BadMarketVuZ.Food;
using BadMarketVuZ.Food.HealthyFood;
using BadMarketVuZ.Food.ISemiFinishedFood;
using BadMarketVuZ.Food.Snacks;
using BadMarketVuZ.Work;

namespace BadMarketVuz
{
    internal enum FoodTypes
    {
        HealthyFood,
        ISemiFinishedFood,
        Snacks
    }
    internal class Program
    {
        private static readonly Random random = new();
        #region СПЁРТО У ЛЁШИ-ГЕНИЯ
        public static Scene scene;
        public const int size = 16;
        private static char[,] screen = new char[size, size];
        public static void Clear()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    screen[i, j] = ' ';
        }
        public static void Draw()
        {
            Console.Clear();
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                    Console.Write(screen[j, i]);
                Console.WriteLine();
            }
        }

        public static void RunScene(Scene newScene)
        {
            scene = newScene;
            Clear();
            scene.Update(ref screen);
            Draw();
        }


        #endregion
        public static void BuyFromShop(Human human, U_Market market, params List<IThing> products)
        {
            int res;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine($"Ваша корзина сегодня: Остаток денег {human.Money}");
                    Console.WriteLine(human.Cart);
                    Console.WriteLine("Выберите товар из списка (или -1 для завершения покупок)");
                    for (int i = 0; i < products.Count; i++)
                        Console.WriteLine($"{i + 1}. {products[i].Description}");
                    if (!int.TryParse(Console.ReadLine(), out res) || res < -1 || res > products.Count)
                    {
                        Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                        continue;
                    }
                    if (res == -1)
                        break;
                    if (human.Money - products[res - 1].Price < 0)
                    {
                        Console.WriteLine("У ВАС НЕТ БАБОК НА ЭТУ ХРЕНЬ");
                        Console.WriteLine("Нажмите любую кнопку...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    market.PutInBusket(human, products[res - 1]);
                    human.Money -= products[res - 1].Price;
                    Console.WriteLine("Нажмите любую кнопку...");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Нажмите любую кнопку...");
                Console.ReadKey();
                Console.Clear();
                while (true)
                {
                    Console.WriteLine($"Ваша корзина сегодня: Остаток денег {human.Money}");
                    Console.WriteLine(human.Cart);
                    Console.WriteLine("Хотите ли вы убрать что-либо из корзины? (1 - да, 2 - нет)");
                    if (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 2)
                    {
                        Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                        continue;
                    }
                    if (res == 1)
                    {
                        Console.WriteLine("Какой товар вы хотите убрать из корзины?");
                        for (int i = 0; i < human.Cart.cart.Count; i++)
                            Console.WriteLine($"{i + 1}. {human.Cart.cart[i].Description}");
                        if (!int.TryParse(Console.ReadLine(), out res) || res < 0 || res > products.Count)
                        {
                            Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                            break;
                        }
                        human.Money += human.Cart.cart[res - 1].Price;
                        human.Cart.cart.Remove(human.Cart.cart[res - 1]);
                    }
                    else
                        break;
                    Console.WriteLine("Нажмите любую кнопку...");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Вы уходите из магазина?(1 - да,2 - нет)");
                if (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 2)
                {
                    Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                    continue;
                }
                if (res == 1)
                    break;
            }
            foreach (IThing item in human.Cart.cart[..])
            {
                if (item is IFood food)
                    human.Fridge.Add(food);
                else
                    human.Inventory.Add(item);
                human.Cart.cart.Remove(item);

            }
        }
        public static void BuyOnSale(Human human, IFood bestProduct)
        {
            if (random.Next(2) == 0)
                while (true)
                {
                    Console.WriteLine($"U_Market предлагает приобрести {bestProduct.Description} ВСЕГО ЗА {bestProduct.Price / 2}");
                    Console.WriteLine("Введите 1 если приобретаете, иначе 2");
                    if (!int.TryParse(Console.ReadLine(), out int res) || res < 1 || res > 3)
                    {
                        Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                        continue;
                    }
                    if (res == 2)
                        break;
                    if (human.Money >= bestProduct.Price / 2)
                    {
                        Console.WriteLine("Товар приобретён успешно!!!");
                        human.Money -= bestProduct.Price / 2;
                        human.Fridge.Add(bestProduct);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("К превеликому сожалению, у вас нет денег на это...");
                        break;
                    }
                }
        }
        public static void Main(string[] args)
        {
            Human human = new();
            U_Market market = new();
            Console.WriteLine("Добро пожаловать в игру РЕАЛ ЛИВЕ!!!");
            Console.WriteLine("Тут вам придётся работать и зарабытывать деньги на еду!!!");
            Console.WriteLine("Также вам нужно следить за белками жирами и углеводами!!!");
            Console.WriteLine("Если к концу недели они будут не в норме, то вы проиграете!!!");
            Console.WriteLine("Также не стоит переедать и есть много вредной пищи!!!");
            int currentMove = 0;
            while (currentMove < 7 && human.CurrentHealthFactor > 0 && human.RateOfHappiness > 25)
            {
                Console.WriteLine($"День {currentMove}");
                Console.WriteLine("Что вы будете сегодня закупать?\n1. ТОЛЬКО ПОЛЕЗНЫЙ ХАВЧИК\n2. ТОЛЬКО ГОТОВУЮ СТРЕПНЮ\n3. ТОЛЬКО СНЭКИ");
                if (!int.TryParse(Console.ReadLine(), out int res) || res < 1 || res > 3)
                {
                    Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                    continue;
                }
                FoodTypes result = (FoodTypes)(res - 1);
                switch (result)
                {
                    case FoodTypes.HealthyFood:
                        BuyFromShop(human, market, market.ShowConcreteMarketAssortment<IHealthyFood>().ToList<IThing>());
                        BuyOnSale(human, market.GiveBestRecommendation<IHealthyFood>(human));
                        break;
                    case FoodTypes.ISemiFinishedFood:
                        BuyFromShop(human, market, market.ShowConcreteMarketAssortment<ISemiFinishedFood>().ToList<IThing>());
                        BuyOnSale(human, market.GiveBestRecommendation<ISemiFinishedFood>(human));
                        break;
                    case FoodTypes.Snacks:
                        BuyFromShop(human, market, market.ShowConcreteMarketAssortment<ISnacks>().ToList<IThing>());
                        BuyOnSale(human, market.GiveBestRecommendation<ISnacks>(human));
                        break;
                    default:
                        break;
                }
                Console.WriteLine("ХОТИТЕ ЛИ ВЫ ПОЙТИ В МАГАЗИН КОНЦЕЛЯРИИ (ЭТО НЕ U-MARKET!!!)");
                Console.WriteLine("Введите 1 если да, иначе 2");
                if (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 3)
                {
                    Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                    continue;
                }
                if (res == 1)
                {
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРЕДАЛИ СФУ!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("ВЫ ПРОИГРАЛИ!!!");
                    return;
                }
                while (true)
                {
                    Console.WriteLine("ВАШ ХОЛОДОСИК");
                    foreach (IFood item in human.Fridge)
                        Console.WriteLine(item.Name);
                    Console.WriteLine("Если хотите получить информацию о продукте, введите его название, иначе введите -1");
                    string? choice = Console.ReadLine();
                    if (choice == "-1")
                        break;
                    IFood? requiredItem = human.Fridge.Find(p => p.Name == choice);
                    if (requiredItem == null)
                    {
                        Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                        continue;
                    }
                    Console.WriteLine(requiredItem.Description);
                }
                while (true)
                {
                    Console.WriteLine(human);
                    Console.WriteLine("ВРЕМЯ КУУУУУУУУУУУУУУУУУУУУУУУУУУУУУШАТЬ!!!");
                    Console.WriteLine("Выберите продукт из списка (или -1 для завершения приёма пищи)");
                    for (int i = 0; i < human.Fridge.Count; i++)
                        Console.WriteLine($"{i + 1}. {human.Fridge[i].Name}");
                    if (!int.TryParse(Console.ReadLine(), out res) || res < -1 || res > human.Fridge.Count)
                    {
                        Console.WriteLine("ТАКОГО ВАРИАНТА ОТВЕТА НЕТУ!!!");
                        continue;
                    }
                    if (res == -1)
                        break;
                    human.EatFood(human.Fridge[res - 1]);
                    human.Fridge.Remove(human.Fridge[res - 1]);
                }
                Console.WriteLine("ВАШИ КАРМАНЫ");
                foreach (IThing item in human.Inventory)
                    Console.WriteLine(item.Name);
                Console.WriteLine("Нажмите любую кнопку...");
                Console.ReadKey();
                Console.Clear();
                #region РАБОТА
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.InputEncoding = System.Text.Encoding.Unicode;
                RunScene(new MenuScene());
                bool end = false;
                while (!end && !scene.workIsOver)
                {
                    char command = Console.ReadKey().KeyChar;
                    switch (command)
                    {
                        case 'q':
                            end = true;
                            break;
                        default:
                            scene.OnInput(command);
                            break;
                    }
                    Clear();
                    scene.Update(ref screen);
                    Draw();
                }
                Console.Clear();
                Console.WriteLine("Рабочий день успешно закончен!!!");
                Console.WriteLine($"Вы заработали {Scene.salary}");
                Console.WriteLine($"Сейчас у вас {human.Money += Scene.salary}");
                #endregion
                Console.WriteLine("ВРЕМЯ СПААААААААААААААААААТЬ");
                human.StartANewDay();
                currentMove++;
            }
            if (human.CurrentHealthFactor < 0)
                Console.WriteLine("ВЫ СДОХЛИ ОТ ГАСТРИТА!!!");
            if (human.RateOfHappiness < 25)
                Console.WriteLine("ВЫ ПСИХАНУЛИ И ВЫШЛИ ИЗ ИГРЫ!!!");
            if (human.CurrentHealthFactor > 0 && human.RateOfHappiness >= 25)
            {
                Console.WriteLine("Вы смогли пережить неделю среднестатистического грузчика!!!");
                Console.WriteLine("Но что же насчёт белков, жиров и углееводов?");
                if (human.Proteins < 0)
                    Console.WriteLine("ВЫ НАБРАЛИ ДОСТАТОЧНОЕ КОЛИЧЕСТВО БЕЛКОВ!!!");
                else
                    Console.WriteLine($"ВЫ НЕ ДОБРАЛИ {human.Proteins} БЕЛКОВ ДО НОРМЫ!!!");
                if (human.Fats < 0)
                    Console.WriteLine("ВЫ НАБРАЛИ ДОСТАТОЧНОЕ КОЛИЧЕСТВО ЖИРОВ!!!");
                else
                    Console.WriteLine($"ВЫ НЕ ДОБРАЛИ {human.Fats} ЖИРОВ ДО НОРМЫ!!!");
                if (human.Carbohydrates < 0)
                    Console.WriteLine("ВЫ НАБРАЛИ ДОСТАТОЧНОЕ КОЛИЧЕСТВО УГЛЕВОДОВ!!!");
                else
                    Console.WriteLine($"ВЫ НЕ ДОБРАЛИ {human.Carbohydrates} УГЛЕВОДОВ ДО НОРМЫ!!!");
            }




        }
    }
}



