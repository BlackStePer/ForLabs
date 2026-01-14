#define MyGame
using System;
using System.Collections.Generic;
using UHarchiLab.Contracts;
using UHarchiLab.ForMyGame;
using UHarchiLab.Products;
using UHarchiLab.Products.HealthFood;
using UHarchiLab.Products.SemiFifinishedFood;

namespace UHarchiLab
{
    internal class Program
    {
#if MyGame
        #region changeAbilities
        /// <summary>
        /// Смена всех способностей игрока на случайные
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <param name="rnd">Рандомайзер</param>
        static void changeAbilities(Player player, Random rnd)
        {
            int temp;
            U_Market abilities = new U_Market();
            {
                abilities.Things = new List<Ithing>()
                {
                    new ChocolateBar(),
                    new Crisps(),
                    new BalykCheese(),
                    new Chicken(),
                    new OliveOil(),
                    new Fruit(),
                    new DumplingsMeat(),
                    new Cheburek(),
                    new DumplingsBerries()
                };
            }
            player.Abilities = new Cart<IFood>();
            for (int i = 0; i < 3; i++)
            {
                temp = rnd.Next(abilities.Things.Count) + 1;
                player.Abilities.AddGood(abilities, temp);
                abilities.Things.RemoveAt(temp - 1);
            }
        }

        /// <summary>
        /// Смена способности по индексу на случайную
        /// </summary>
        /// <param name="player">Игрок</param>
        /// <param name="rnd">Рандомайзер</param>
        /// <param name="index">Индекс</param>
        static void changeAbility(Player player, Random rnd, int index)
        {
            U_Market abilities = new U_Market();
            {
                abilities.Things = new List<Ithing>()
                {
                    new ChocolateBar(),
                    new Crisps(),
                    new BalykCheese(),
                    new Chicken(),
                    new OliveOil(),
                    new Fruit(),
                    new DumplingsMeat(),
                    new Cheburek(),
                    new DumplingsBerries()
                };
            }
            player.Abilities.Foodstuffs.RemoveAt(index);
            player.Abilities.AddGood(abilities, rnd.Next(abilities.Things.Count) + 1);
        }
        #endregion
        #region EnemyChoose

        /// <summary>
        /// Ход врага
        /// </summary>
        /// <param name="me">Игрок</param>
        /// <param name="enemy">Враг</param>
        /// <param name="rnd">Рандомайзер</param>
        /// <param name="ending">Закончилась ли игра</param>
        static void EnemyChoose(Player me, Player enemy, Random rnd, out bool ending)
        {
            int choose = rnd.Next(5);
            int choose2 = rnd.Next(2);
            bool end = false;
            if(choose <= 2)
            {
                if(choose2 == 0)
                {
                    Console.WriteLine(enemy.UseAbility(enemy.Abilities.Foodstuffs[choose], out end));
                    changeAbility(enemy, rnd, choose);
                    Console.ReadKey();
                    ending = end;
                    if (end)
                    {
                        Console.Clear();
                        Console.WriteLine("ПОЗДРАВЛЯЮ С ПОБЕДОЙ");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(me.UseAbility(enemy.Abilities.Foodstuffs[choose], out end));
                    changeAbility(enemy, rnd, Convert.ToInt32(choose));
                    Console.ReadKey();
                    ending = end;
                    if (end)
                    {
                        Console.Clear();
                        Console.WriteLine("Ты проиграл");
                        Console.ReadKey();
                    }
                }
            }
            else if(choose == 3)
            {
                changeAbilities(enemy, rnd);
                ending = end;
                Console.WriteLine("Враг сменил себе способности!");
                Console.ReadKey();
            }
            else
            {
                changeAbilities(me, rnd);
                ending = end;
                Console.WriteLine("Враг сменил вам способности!");
                Console.ReadKey();
            }
        }
        #endregion
#endif
        static void Main(string[] args)
        {
#if MainLab
            #region MainTask
            U_Market myMarket = new U_Market();
            {
                myMarket.Things = new List<Ithing>()
                {
                    new ChocolateBar(),
                    new Crisps(),
                    new BalykCheese(),
                    new Chicken(),
                    new OliveOil(),
                    new Fruit(),
                    new DumplingsMeat(),
                    new Cheburek(),
                    new DumplingsBerries()
                };
            }
            ICart<IFood> mycart;

        ChooseCart:
            Console.WriteLine("Какую карзину создаём?");
            Console.WriteLine("1 - Карзина снэков");
            Console.WriteLine("2 - Карзина полезностей");
            Console.WriteLine("3 - Карзина полуфобриктов");
            Console.WriteLine("4 - Карзина общая");
            Console.WriteLine("5 - Никакую!! ЧАО");
        
            string choice = Console.ReadLine();
            Console.Clear();

            if (choice == "1")
            {
                mycart = new Cart<Isnacks>();
                Console.WriteLine("Карзина снэков создана");
            }
            else if (choice == "2")
            {
                mycart = new Cart<IHealthyFood>();
                Console.WriteLine("Карзина полезностей создана");
            }
            else if (choice == "3")
            {
                mycart = new Cart<ISemiFifinishedFood>();
                Console.WriteLine("Карзина полуфобриктов создана");
            }
            else if (choice == "4")
            {
                mycart = new Cart<IHealthyFood>();
                Console.WriteLine("Карзина общая создана");
            }
            else if (choice == "5") 
            {
                return;
            }
            else
            {
                goto ChooseCart;
            }

            Console.ReadKey();

         ChooseMotion:
            Console.Clear();
            Console.WriteLine("Что делаем?");
            Console.WriteLine("1 - Добавить элемент в карзину");
            Console.WriteLine("2 - Сделать сбалансированную карзину");
            Console.WriteLine("3 - Показать конечную карзину");
            Console.WriteLine("4 - Выйти");

            choice = Console.ReadLine();
            Console.Clear();

            if (choice == "1")
            {
                foreach(Ithing thing in myMarket.Things)
                {
                    Console.WriteLine($"{myMarket.Things.IndexOf(thing) + 1} - {thing.Name}");
                }
                try
                {
                    Console.WriteLine(mycart.AddGood(myMarket, Convert.ToInt32(Console.ReadLine())));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не корректные данные");
                }
                Console.ReadKey();
            }
            else if (choice == "2")
            {
                mycart.CartBalansing(myMarket);
                Console.WriteLine("Карзина сбалансирована");
                Console.ReadKey();
            }
            else if (choice == "3")
            {
                Console.WriteLine(mycart.GetGoodsList());
                Console.ReadKey();
            }
            else if (choice == "4")
            {
                return;
            }
            goto ChooseMotion;
            #endregion
#elif MyGame
            List<string> enemies = new List<string>() 
            {
                "Упырыш",
                "Хачок",
                "Гандопляс",
                "Витёк",
                "Гавгонг",
                "Русичка",
                "Перловка",
                "Подпупник",
                "Generic"
            };
            bool end;
            List<int> stats = new List<int>() {1, 2, 3};
            Random rnd = new Random();

            int myHeal = stats[rnd.Next(stats.Count)];
            stats.Remove(myHeal);

            int enemyHeal = stats[rnd.Next(stats.Count)];
            stats.Remove(enemyHeal);

            Console.WriteLine("Привет игрок! Введи свой ник:");

            Player me = new Player(myHeal, enemyHeal, Console.ReadLine()), enemy = new Player(enemyHeal, myHeal, enemies[rnd.Next(enemies.Count)]);
            changeAbilities(me, rnd);
            changeAbilities(enemy, rnd);

        ChooseAbility:
            Console.Clear();
            Console.WriteLine(me.GetStat());
            Console.WriteLine(enemy.GetStat());
            Console.Write("Выбирай способность: ");

            string abilityChoose = Console.ReadLine();
            if (abilityChoose == "1" || abilityChoose == "2" || abilityChoose == "3")
            {
                Console.Clear();
                Console.WriteLine("На кого используешь???");
                Console.WriteLine("1 - На себя");
                Console.WriteLine("2 - На врага");
                Console.WriteLine("Другая кнопка - Отмена");
                Console.Write("И твой выбор: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(me.UseAbility(me.Abilities.Foodstuffs[Convert.ToInt32(abilityChoose) - 1], out end));
                        changeAbility(me, rnd, Convert.ToInt32(abilityChoose) - 1);
                        Console.ReadKey();
                        if (end)
                        {
                            Console.Clear();
                            Console.WriteLine("Ты проиграл");
                            return;
                        }

                        Console.Clear();
                        Console.WriteLine("Ход врага!!!");
                        Console.ReadKey();
                        Console.Clear();
                        EnemyChoose(me, enemy, rnd, out end);
                        if (end)
                        {
                            return;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(enemy.UseAbility(me.Abilities.Foodstuffs[Convert.ToInt32(abilityChoose) - 1], out end));
                        changeAbility(me, rnd, Convert.ToInt32(abilityChoose) - 1);
                        Console.ReadKey();
                        if (end)
                        {
                            Console.Clear();
                            Console.WriteLine("ПОЗДРАВЛЯЮ С ПОБЕДОЙ");
                            return;
                        }

                        Console.Clear();
                        Console.WriteLine("Ход врага!!!");
                        Console.ReadKey();
                        Console.Clear();
                        EnemyChoose(me, enemy, rnd, out end);
                        if (end)
                        {
                            return;
                        }
                        break;
                }
                goto ChooseAbility;
            }
            else if(abilityChoose == "4")
            {
                changeAbilities(me, rnd);
                Console.Clear();
                Console.WriteLine("Ход врага!!!");
                Console.ReadKey();
                Console.Clear();
                EnemyChoose(me, enemy, rnd, out end);
                if (end)
                {
                    return;
                }
            }
            else if(abilityChoose == "5")
            {
                changeAbilities(enemy, rnd);
                Console.Clear();
                Console.WriteLine("Ход врага!!!");
                Console.ReadKey();
                Console.Clear();
                EnemyChoose(me, enemy, rnd, out end);
                if (end)
                {
                    return;
                }
            }
            goto ChooseAbility;
#endif
        }
    }
}
