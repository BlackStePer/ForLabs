using System;
using System.Collections.Generic;
using System.Threading;

namespace VirusLab
{
    internal class Program
    {
        /// <summary>
        /// Показ начальной заставка
        /// </summary>
        /// <param name="animate">С анимацией/без</param>
        static void ShowIntro(bool animate)
        {
            int wordDelay, frameDelay;
            if (animate)
                wordDelay = 500;
            else
                wordDelay = 0;
            frameDelay = wordDelay / 50;

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char temp in "=======================================")
            {
                Console.Write(temp);
                Thread.Sleep(frameDelay);
            }
            Console.Write("\n             ");

            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string s in new List<string>() {"VIRUS", "GAME"})
            {
                Console.Write($"{s} ");
                Thread.Sleep(wordDelay);
            }
            Console.Write("\n");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char temp in "=======================================")
            {
                Console.Write(temp);
                Thread.Sleep(frameDelay);
            }
            Console.Write("\n      1 - START");
            Thread.Sleep(wordDelay);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("     2 - EXIT\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Отрисока игровой карты
        /// </summary>
        /// <param name="map">Карта</param>
        static void DrawMap(Level map)
        {
            foreach(char temp in map.ToString())
            {
                switch (temp)
                {
                    case '0':
                    case 'V':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(temp);
                        break;
                    case 'D':
                        if(map.FreezeTime != 0)
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(temp);
                        break;
                    case 'o':
                    case '*':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(temp);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(temp);
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Шанс взлома защиты: {map.Player.ProtectionSystem.Security * 100}% | " +
                $"Доступно заморозок : {map.Player.FreezeTime / 3}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Показ информации об игре
        /// </summary>
        /// <param name="virusName">Имя вируса</param>
        /// <param name="sysName">Название системы для взлома</param>
        /// <param name="anymate">С анимацией/без</param>
        static void ShowInfo(string virusName, string sysName, bool anymate)
        {
            int D = 0;
            bool color = false;
            string info = 
                $"Взламываемая программа - {sysName}\n" +
                $"Имя вируса - {virusName}\n" +
                $"====================================\n" +
                $"Цель - Играя за вирус, вам пердстоит пройти 5 уровней защиты приложения.\n" +
                $"Остерегайтесь защитников системы(defenders) и собирайте её уязвимости.\n" +
                $"====================================\n" +
                $"Управление:\n" +
                $"W A S D - управление\n" +
                $"SPACE - использовать заморозку\n" +
                $"====================================\n" +
                $"Объекты:\n" +
                $"D - Защитники системы (Избегайте их)\n" +
                $"V - Вирус (Ваш игровой персонаж)\n" +
                $"o - Системаня ошибка (Собирайте их чтобы повысить вероятность взлома уровня защиты)\n" +
                $"* - Замораживающий компонент (Позволяет заморозить защитников на 3 хода)";
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char c in info)
            {
                if(c == '=')
                    color = true;
                if (color && "WASoPCE*".Contains(c.ToString()))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(c);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if(color && c == 'D')
                {
                    if(D == 0)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    D++;
                    Console.Write(c);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.Write(c);
                }
                if(anymate)
                    Thread.Sleep(1);
            }
        }
        static void Main(string[] args)
        {
            bool animateIntro = true, animateInfo = true;
            List<string> sisi = new List<string>() 
            {
                "Онлайн кошелёк Зайцева",
                "Windows 11",
                "MacOs",
                "Linux",
                "Android",
                "IOS"
            };
            List<string> virururururu = new List<string>()
            {
                "Злой вирус",
                "Мохнатка",
                "Cs2",
                "Витёк",
                "Кибер хаос",
                "Ублюдка",
                "Гапак",
                "Семён1488",
                "Адольф",
            };

        Restart:
            string os = sisi[new Random().Next(0, sisi.Count)],
                virus = virururururu[new Random().Next(0, virururururu.Count)];
            ProtectionSystem sys = new ProtectionSystem(os, 5, 0.1);
            Skyda player = new Skyda(virus, 1, 1, sys);
            int levelInd = 1;

            List<IReactProtectionFall> nots = new List<IReactProtectionFall>();
            for (int i = 1; i <= 5; i++)
            {
                if (i == 5)
                {
                    EndLayerNotifier enot = new EndLayerNotifier(i);
                    enot.Subscribe(player);
                    nots.Add(enot);
                    break;
                }
                BasicLayerNotifier not = new BasicLayerNotifier(i);
                not.Subscribe(player);
                nots.Add(not);
            }

        Intro:
            Console.Clear();
            ShowIntro(animateIntro);
            switch (((ConsoleKeyInfo)Console.ReadKey(true)).Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    return;
                default:
                    animateIntro = false;
                    goto Intro;
            }
            animateIntro = false;
            Console.Clear();
            ShowInfo(virus, os, animateInfo);
            animateInfo = false;
            Console.ReadKey();
        ChangeLevel:
            sys.Security = 0.1;
            Level level = new Level(10, 10, levelInd, sys, player);

        Move:
            Console.Clear();
            DrawMap(level);
            ConsoleKey key = ((ConsoleKeyInfo)Console.ReadKey(true)).Key;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.W:
                case ConsoleKey.D:
                case ConsoleKey.S:
                    Console.Clear();
                    bool end = level.ChangePositions(key);
                    if (end)
                    {
                        goto EndLevel;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if(player.FreezeTime > 0)
                    {
                        level.FreezeTime += 3;
                        player.FreezeTime -= 3;
                    }
                    break;
            }
            goto Move;


        EndLevel:
            Console.Clear();
            player.Attack();
            player.NotifyProtectionFall();

            if (player.KnownFalledProtectionLayerNumber == levelInd)
            {
                Console.ReadKey();
                if (levelInd == 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(1000);
                    Console.Write("YOU ");
                    Thread.Sleep(1000);
                    Console.Write("WIN");
                    return;
                }
                levelInd += 1;
                goto ChangeLevel;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach(char c in "Вирус Не Выполнил Задачу")
                {
                    Console.Write(c);
                    Thread.Sleep(5);
                }
                Console.ReadKey();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(200);
                Console.Write("GAME ");
                Thread.Sleep(200);
                Console.Write("OVER");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                goto Restart;
            }
        }
    }
}