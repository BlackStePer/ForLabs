using System.Diagnostics;
using System.Text;
using VirusVuZ.ProtectionSystemGame;
using VirusVuZ.SkydaGame;

namespace VirusVuZ
{
    internal class GameEngine
    {
        private static readonly Random random = new();
        /// <summary>
        /// Начать игру
        /// </summary>
        public void Run()
        {

            Console.WriteLine("Добро пожаловать в игру-недоигру СКУДА ПРОТИ НЕСКУДЫ!!!");
            Console.WriteLine("Вам необходимо выбрать сторону!!!");
            while (true)
            {
                Console.WriteLine("1 если за НЕСКУДУ. 2 если за СКУДУ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (choice == '1')
                {
                    GameAsProtectionSystem();
                    break;
                }
                else if (choice == '2')
                {
                    GameAsSkyda();
                    break;
                }
                else
                    Console.WriteLine("Такой команды нет!!! Попробуйте снова!!!");
            }
        }
        #region ProtectionSystem
        /// <summary>
        /// Играть за систему защиты
        /// </summary>
        public void GameAsProtectionSystem()
        {
            Console.WriteLine("Как называется ваша система?");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) title = "НЕСКУУУУУУУДА";
            GameProtectionSystem protectionSystem = new(title);
            int resources = 100;
            Console.WriteLine("Начинаем защиту системы!");
            Skyda skyda = new(protectionSystem);
            foreach (ProtectionLayer layer in protectionSystem.Layers)
                layer.Notifier.Subscribe(skyda);
            while (protectionSystem.FalledProtectionLayerNumber < protectionSystem.ProtectionLayerNumber)
            {
                Console.WriteLine($"Введите количество ресурсов для активации улучшения защиты (от 0 до 50): У вас {resources} едениц ресурсов на данный момент");
                if (int.TryParse(Console.ReadLine(), out int allocation) && allocation >= 0 && allocation <= 50 && resources >= allocation)
                {
                    resources -= allocation;
                    foreach (ProtectionLayer layer in protectionSystem.Layers)
                        if (!layer.IsBreached && random.Next(allocation * 2) > 35)
                        {
                            layer.Upgrade();
                            Console.WriteLine($"{layer.Name} улучшен! Уровень: {layer.Level}, Здоровье: {layer.Health}, Сопротивляемость: {layer.Resistance}");
                        }
                }
                else
                    Console.WriteLine("Недостаточно ресурсов или неверный ввод.");
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("ВРЕМЯ АТАКИ СКУДЫ!!!");
                List<AttackInfo> incomingAttacks = GenerateIncomingAttacks(protectionSystem);
                int firstLayerCount = protectionSystem.Layers.FindAll(l => !l.IsBreached).Count();
                protectionSystem.Defense(skyda, out StringBuilder sb, incomingAttacks);
                int lastLayerCount = protectionSystem.Layers.FindAll(l => !l.IsBreached).Count();
                if (firstLayerCount == lastLayerCount)
                    protectionSystem.ProtectionCheck();
                Console.WriteLine(sb);
                Console.WriteLine($"Система: {protectionSystem.Title} | Прорвано: {protectionSystem.FalledProtectionLayerNumber}/{protectionSystem.ProtectionLayerNumber} | Дата: {protectionSystem.Date:yyyy-MM-dd}");
                foreach (ProtectionLayer layer in protectionSystem.Layers)
                    if (!string.IsNullOrWhiteSpace(layer.Notifier.Message))
                        Console.WriteLine(layer.Notifier.Message);
                if (protectionSystem.FalledProtectionLayerNumber == protectionSystem.ProtectionLayerNumber)
                    break;
                Console.WriteLine("ВРЕМЯ ЗАРАБАТЫВАТЬ РЕСУРСЫ!!!");
                resources += RandomClickerGame();
            }
            Console.WriteLine("Все слои защиты пробиты... Вы держались достойно...");
        }
        /// <summary>
        /// Генератор атак скуды
        /// </summary>
        /// <param name="protectionSystem">Система защиты</param>
        /// <returns>Список атак</returns>
        private List<AttackInfo> GenerateIncomingAttacks(ProtectionSystem protectionSystem)
        {
            Random rand = new();
            List<AttackInfo> allPossibleAttacks =
            [
                new AttackInfo("DDoS", rand.Next(20, 40)),
                new AttackInfo("Virus", rand.Next(52, 53)),
                new AttackInfo("Phishing", rand.Next(10, 25)),
                new AttackInfo("Miner", rand.Next(25, 40)),
                new AttackInfo("KILLER Bunny", rand.Next(50, 152)),
            ];
            if ((protectionSystem.Date - DateTime.Now).Days + 1 < 5)
                return allPossibleAttacks.OrderBy(x => rand.Next()).Take(rand.Next(1, 5)).ToList();
            return allPossibleAttacks.OrderBy(x => rand.Next()).Take(rand.Next(3, 6)).ToList();
        }
        /// <summary>
        /// Миниигра найди букву на клавиатуре
        /// </summary>
        /// <returns></returns>
        private int RandomClickerGame()
        {
            Console.WriteLine("=== СЛУЧАЙНЫЙ КЛИКЕР ===");
            Console.WriteLine("Нажимайте клавиши, которые появляются на экране!");
            Console.WriteLine("Нажмите любую клавишу для старта...");
            Console.ReadKey(true);
            int score = 0;
            int secondsToClick = 10;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Stopwatch sw = Stopwatch.StartNew();
            char targetChar = chars[random.Next(chars.Length)];
            Console.WriteLine($"\nБЫСТРЕЕ! Жми: {targetChar}");

            while (sw.Elapsed.TotalSeconds < secondsToClick)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.KeyChar.ToString().ToUpper() == targetChar.ToString().ToUpper())
                    {
                        score++;
                        targetChar = chars[random.Next(chars.Length)];
                        Console.WriteLine($"Верно! Следующая: {targetChar} (Всего: {score})");
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("\n--- ВРЕМЯ ВЫШЛО! ---");
            Console.WriteLine($"Твой результат: {score * 4} за 5 секунд.");
            return score * 4;
        }
        #endregion
        #region Skyda
        /// <summary>
        /// Играть за скуду
        /// </summary>
        public void GameAsSkyda()
        {
            GameProtectionSystem targetSystem = new("Сайт сфу");
            GameSkyda skyda = new(targetSystem);
            int resources = 100;
            int dayIncome = 25;
            while (targetSystem.FalledProtectionLayerNumber < targetSystem.ProtectionLayerNumber)
            {
                Console.WriteLine("Начинаем защиту системы!");
                UpgradeLayers(targetSystem);
                Console.WriteLine("ВРЕМЯ АТАКИ СКУДЫ!!!");
                List<AttackInfo> attacks = skyda.Attacks.OrderBy(x => random.Next()).Take(random.Next(3, 6)).ToList();
                List<AttackInfo> chosenAttacks = [];
                bool canUpgrade = true;
                while (true)
                {
                    Console.WriteLine($"Выберите атаки: У вас {resources} едениц ресурсов");
                    for (int i = 0; i < attacks.Count; i++)
                        Console.WriteLine($"{i + 1}. {attacks[i].Name} (Сила: {attacks[i].Power}, Стоимость: {attacks[i].ResourceCost})");
                    Console.WriteLine("0. Позволить улучшить двневную выработку ресурсов");
                    Console.WriteLine("-1. Конец хода");
                    Console.WriteLine("Введите номер атаки:");
                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out int attackIndex) && attackIndex >= -1 && attackIndex <= attacks.Count)
                    {
                        if (attackIndex == -1)
                        {
                            int firstLayerCount = targetSystem.Layers.FindAll(l => !l.IsBreached).Count();
                            targetSystem.Defense(skyda, out StringBuilder sb, chosenAttacks);
                            int lastLayerCount = targetSystem.Layers.FindAll(l => !l.IsBreached).Count();
                            if (firstLayerCount == lastLayerCount)
                                targetSystem.ProtectionCheck();
                            Console.WriteLine(sb);
                            break;
                        }
                        if (attackIndex == 0)
                        {
                            if (canUpgrade)
                            {
                                Console.WriteLine("Введите количество ресурсов для улучшения системы взлома (от 0 до 50):\n Учтите, что ресурсы могут быть потрачены зря!!!");
                                if (int.TryParse(Console.ReadLine(), out int upgradeCost) && upgradeCost >= 0 && upgradeCost <= 50 && resources >= upgradeCost)
                                {
                                    resources -= upgradeCost;
                                    dayIncome += random.Next(2) == 0 ? upgradeCost / 2 : upgradeCost / 25;
                                    Console.WriteLine($"ТЕПЕРЬ ВАША ДНЕВНАЯ ВЫДАЧА = {dayIncome}");
                                    canUpgrade = false;
                                }
                                else
                                    Console.WriteLine("Недостаточно ресурсов или неверный ввод.");
                                continue;
                            }
                            else
                                continue;
                        }
                        chosenAttacks.Add(attacks[attackIndex - 1]);
                        if (resources >= attacks[attackIndex - 1].ResourceCost)
                        {
                            resources -= attacks[attackIndex - 1].ResourceCost;
                            attacks.Remove(attacks[attackIndex - 1]);
                        }
                        else
                            Console.WriteLine("Недостаточно ресурсов для этой атаки.");
                    }
                    else
                        Console.WriteLine("Неверный выбор.");
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine($"Система: {targetSystem.Title} | Прорвано: {targetSystem.FalledProtectionLayerNumber}/{targetSystem.ProtectionLayerNumber} | Дата: {targetSystem.Date:yyyy-MM-dd}");
                foreach (ProtectionLayer layer in targetSystem.Layers)
                    if (!string.IsNullOrWhiteSpace(layer.Notifier.Message))
                        Console.WriteLine(layer.Notifier.Message);
                if (targetSystem.FalledProtectionLayerNumber == targetSystem.ProtectionLayerNumber)
                    break;
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                resources += dayIncome + RandomWordGame();
            }
            Console.WriteLine("Все слои защиты пробиты! Поздравляем!");
        }
        /// <summary>
        /// Миниигра. Писать слова на время
        /// </summary>
        /// <returns></returns>
        private int RandomWordGame()
        {
            Random rand = new();
            string[] wordsPool = {
            "abstract", "argument", "array", "async", "await", "binary", "boolean", "class",
            "collection", "compiler", "constructor", "delegate", "dependency", "dictionary",
            "encapsulation", "enum", "event", "exception", "framework", "function", "generic",
            "heritage", "immutable", "index", "inheritance", "instance", "interface", "iteration",
            "lambda", "library", "linq", "list", "loop", "method", "namespace", "nullable",
            "object", "operator", "overload", "override", "parameter", "polymorphism", "property",
            "recursion", "reflection", "runtime", "stack", "static", "string", "struct",
            "thread", "tuple", "variable", "virtual"
        };
            List<string> gameWords = wordsPool.OrderBy(x => rand.Next()).ToList();

            Console.WriteLine("=== C# SPEED TYPING TEST (50+ WORDS) ===");
            Console.WriteLine("У вас есть 20 секунд. Пишите слова максимально быстро!");
            Console.WriteLine("Нажмите ENTER для старта...");
            Console.ReadLine();

            int score = 0;
            int timeLimit = 20;
            int wordIndex = 0;
            Stopwatch sw = Stopwatch.StartNew();

            while (sw.Elapsed.TotalSeconds < timeLimit && wordIndex < gameWords.Count)
            {
                string targetWord = gameWords[wordIndex];
                int timeLeft = Math.Max(0, timeLimit - (int)sw.Elapsed.TotalSeconds);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n[{timeLeft} сек] Слово: {targetWord}");
                Console.ResetColor();
                Console.Write("Ввод: ");

                string input = Console.ReadLine();

                // Проверка времени после того, как пользователь закончил ввод
                if (sw.Elapsed.TotalSeconds >= timeLimit) break;

                if (input?.Trim().ToLower() == targetWord.ToLower())
                {
                    score++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ОК!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка!");
                }

                Console.ResetColor();
                wordIndex++;

                // Если слова закончились, перемешиваем заново
                if (wordIndex >= gameWords.Count)
                {
                    gameWords = wordsPool.OrderBy(x => rand.Next()).ToList();
                    wordIndex = 0;
                }
            }

            sw.Stop();
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("ВРЕМЯ ВЫШЛО!");
            Console.WriteLine($"Ваш результат: {score} слов");
            Console.WriteLine($"Вы заработали {score * 10} едениц ресурсов");
            return score * 10;
        }
        /// <summary>
        /// Процесс улучшения targetSystem
        /// </summary>
        /// <param name="targetSystem">Объект GameProtectionSystem</param>
        private void UpgradeLayers(GameProtectionSystem targetSystem)
        {
            foreach (ProtectionLayer layer in targetSystem.Layers)
                if (random.Next(3) == 0)
                {
                    layer.Upgrade();
                    Console.WriteLine($"{layer.Name} улучшен! Уровень: {layer.Level}, Здоровье: {layer.Health}, Сопротивляемость: {layer.Resistance}");
                }
        }
        #endregion
    }
}
