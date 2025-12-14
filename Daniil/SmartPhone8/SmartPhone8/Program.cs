using System;
using System.Collections.Generic;

namespace SmartPhone8
{
    internal class Program
    {
        /// <summary>
        /// Метод возвращает строку вида: Имя покупателя - Девайсы
        /// </summary>
        /// <param name="customer">Покупатель у которого проверяются девайсы</param>
        /// <returns>Строка вида: Имя покупателя - Девайсы</returns>
        static string ShowDevice(Customer customer)
        {
            return $"{customer.FullName} - " +
                $"{(customer.Smartphone != null ? "Телефон " + customer.Smartphone.SerialNumber.ToString() + (customer.TransformModule != null ? " и Трансформатор " + customer.TransformModule.SerialNumber.ToString() : "") : (customer.Tablet != null ? "Планшет " + customer.Tablet.SerialNumber.ToString() : "Нет ничего =("))}";
        }

        static void Main(string[] args)
        {
            string questNum = "";
            //Предисловие
            Console.WriteLine(GameHepler.info);
            Console.ReadKey();
            //Основная сцена
        GameBase:
            Console.Clear();
            Console.WriteLine($"| Score - {GameHepler.score} | Lvl - {GameHepler.mylvl} | Customers - {GameHepler.nameToLvl[GameHepler.mylvl].Count} | " +
                $"Tr:Ph:Tt - {GameHepler.tsp[0]}:{GameHepler.tsp[1]}:{GameHepler.tsp[2]} |");
            Console.WriteLine("=====================================================================");
            Console.WriteLine("1 - Заработать очки");
            Console.WriteLine("2 - Купить девайсы");
            Console.WriteLine("3 - Запустить клиентов");
            switch (Console.ReadLine())
            {
                case "1":
                ChageLevel:
                    Console.Clear();
                    // Выводим список заданий, доступных на нашем уровне
                    foreach (string s in GameHepler.questsToLvl[GameHepler.mylvl])
                    {
                        Console.WriteLine(s + " " + Convert.ToInt32(GameHepler.countMoneyTryes[GameHepler.mylvl.ToString() + s[0]][1]) + " шт");
                        questNum = s[0].ToString();
                    }
                    Console.WriteLine($"{Convert.ToInt32(questNum) + 1} - Отмена:");
                    //Проверка на оставшееся количество задач
                    string choice = Console.ReadLine();
                    if (Convert.ToInt32(choice) == Convert.ToInt32(questNum) + 1)
                    {
                        goto GameBase;
                    }
                        if (GameHepler.countMoneyTryes[GameHepler.mylvl.ToString() + choice][1] == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Этих задач не осталось =(");
                        Console.ReadKey();
                        goto ChageLevel;
                    }
                    GameHepler.lvl(GameHepler.mylvl.ToString(), choice, out int ans, out string eq);
                    //Правильно или неправильно решено
                    if(eq == "-52")
                    {
                        Console.Clear();
                        Console.WriteLine("ВВОДИ ВАРИАНТ КОТОРЫЙ ЕСТЬ!!!!!!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(eq);
                        GameHepler.countMoneyTryes[GameHepler.mylvl.ToString() + choice][1] -= 1;
                        if (Console.ReadLine() == ans.ToString())
                        {
                            Console.Clear();
                            GameHepler.score += GameHepler.countMoneyTryes[GameHepler.mylvl.ToString() + choice][0];
                            Console.WriteLine("Молодец, ответ верный =)");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ответ неверный =(");
                            Console.ReadKey();
                        }
                    }
                    goto GameBase;
                case "2":
                Buying:
                    Console.Clear();
                    Console.WriteLine("1 - Трансформатор (2 очка за шт)");
                    Console.WriteLine("2 - Телефон (10 очков за шт)");
                    Console.WriteLine("3 - Планшет (30 очков за шт)");
                    Console.WriteLine("4 - Назад");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            if(GameHepler.score < 2)
                            {
                                Console.WriteLine("Недостаточно очков =(");
                                Console.ReadKey();
                                goto Buying;
                            }
                            else
                            {
                                Console.WriteLine("Покупка успешна");
                                GameHepler.tsp[0] += 1;
                                GameHepler.score -= 2;
                                Console.ReadKey();
                                goto Buying;
                            }
                        case "2":
                            Console.Clear();
                            if (GameHepler.score < 10)
                            {
                                Console.WriteLine("Недостаточно очков =(");
                                Console.ReadKey();
                                goto Buying;
                            }
                            else
                            {
                                Console.WriteLine("Покупка успешна");
                                GameHepler.tsp[1] += 1;
                                GameHepler.score -= 10;
                                Console.ReadKey();
                                goto Buying;
                            }
                            break;
                        case "3":
                            Console.Clear();
                            if (GameHepler.score < 30)
                            {
                                Console.WriteLine("Недостаточно очков =(");
                                Console.ReadKey();
                                goto Buying;
                            }
                            else
                            {
                                Console.WriteLine("Покупка успешна");
                                GameHepler.tsp[2] += 1;
                                GameHepler.score -= 30;
                                Console.ReadKey();
                                goto Buying;
                            }
                            break;
                        case "4":
                            goto GameBase;
                            break;
                        default:
                            goto Buying;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Factory wave = new Factory(GameHepler.nameToLvl[GameHepler.mylvl], GameHepler.tsp[0], GameHepler.tsp[1], GameHepler.tsp[2]);
                    wave.SaleSmartphone();

                    GameHepler.tsp[0] += wave.minuses[0];
                    GameHepler.tsp[1] += wave.minuses[1];
                    GameHepler.tsp[2] += wave.minuses[2];

                    foreach (Customer customer in GameHepler.nameToLvl[GameHepler.mylvl])
                    {
                        string customerDevice = ShowDevice(customer);
                        if (customerDevice.Contains("=("))
                        {
                            GameHepler.game = false;
                        }
                        Console.WriteLine(customerDevice);
                    }

                    Console.ReadKey();
                    if (GameHepler.game && GameHepler.mylvl != 4)
                    {
                        GameHepler.mylvl += 1;
                        goto GameBase;
                    }
                    else if(GameHepler.game && GameHepler.mylvl == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Поздравляю чемпион, ты смог продать все смартфоны, теперь ты готов к великим делам!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Увы ты проиграл =(");
                        Console.ReadKey();
                    }
                        break;
                default:
                    {
                        goto GameBase;
                    }
            }

        }
    }
}
