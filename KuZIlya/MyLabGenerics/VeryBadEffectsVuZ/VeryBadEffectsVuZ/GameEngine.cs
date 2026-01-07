using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Text;
using VeryBadEffectsVuZ.Effects;
using VeryBadEffectsVuZ.Effects.ConcreteEffects;
using VeryBadEffectsVuZ.Potion;
using VeryBadEffectsVuZ.Potions;
using VeryBadEffectsVuZ.Targets.ConcreteTargets;
using VeryBadEffectsVuZ.Targets.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace VeryBadEffectsVuZ
{
    internal class GameEngine
    {
        private static Random random = new Random();
        private int currentMove = 0;
        private MagicAltar altar = new MagicAltar(random.Next(2,9));
        private string _playerName; // костыль
        private List<ITargetable> targets;
        private List<ITargetable> enemyTargets;
        private string gameField = " 0  1  2  3  4  5  6  7  8  9  P ";
        IUnit player = null;
        IUnit enemy = null;
        private void UpdateGameField()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (Rune rune in gameField.EnumerateRunes())
            {
                if (rune != (Rune)' ')
                {
                    if (i == player.Position)
                    {
                        if (Rune.TryGetRuneAt(player.Avatar, 0, out Rune a))
                            sb.Append(a);
                    }
                    else if (i == enemy.Position)
                    {
                        if (Rune.TryGetRuneAt(enemy.Avatar, 0, out Rune a))
                            sb.Append(a);
                    }
                    else if (i == altar.Position)
                    {
                        if (Rune.TryGetRuneAt("⛩️", 0, out Rune a))
                            sb.Append(a);
                    }
                    else if (i == player.MyCastle.Position)
                    {
                        if (Rune.TryGetRuneAt(player.MyCastle.Avarar, 0, out Rune a))
                            sb.Append(a);
                    }
                    else if (i == enemy.MyCastle.Position)
                    {
                        if (Rune.TryGetRuneAt(enemy.MyCastle.Avarar, 0, out Rune a))
                            sb.Append(a);
                    }
                    else
                        sb.Append($"{i}");
                    i++;
                }
                else
                    sb.Append(" ");
            }
            gameField = sb.ToString();
        }
        public void Run()
        {
            Console.WriteLine("\t\t\t\t\tДОБРО ПОЖАЛОВАТЬ В МАГОВ 3!!!\t\t\t\t\t\n" +
                "В данной игре вам будет необходимо выбрать класс вашего героя:\n" +
                "Маги способны использовать продвинутые заклинания, однако их обычная атака слаба, дальность атаки средняя, здоровье низкое\n" +
                "Лучники способны использовать зелья базового уровня, имеют отличную дальность атаки, неуязвимы к огню и яду, наносят большой урон, однако имеют малое здоровье\n" +
                "Доспехи воина из магов 2 делают его полностью неуязвимым к обычному урону и оглушению, однако воин уязвим к ядам и огню!!! далльность атаки минимальна, высокое здоровье, высокий урон, умение пользоваться базовыми заклинаниями\n");
            Console.WriteLine("Для начала назовите вашего героя");
            string playerName = Console.ReadLine() ?? "БЕЗЫМЯННЫЙ ГЕРОЙ";
            playerName = String.IsNullOrWhiteSpace(playerName) ? "БЕЗЫМЯННЫЙ ГЕРОЙ" : playerName;
            Console.WriteLine("Как будет называться ваш замок?");
            string castleName = Console.ReadLine() ?? "БЕЗЫМЯННЫЙ ЗАМОК";
            castleName = String.IsNullOrWhiteSpace(castleName) ? "БЕЗЫМЯННЫЙ ЗАМОК" : castleName;
            Console.WriteLine("Введите ваш выбор:\n1. Маг\n2. Лучник\n3. Воин");
            _playerName = playerName;
            bool end = false;
            while (!end) 
            {
                if (int.TryParse(Console.ReadLine(), out int c))
                    switch (c)
                    {
                        case 1:
                            player = new Mage(playerName, 1, new Castle(150, 0, castleName));
                            end = true;
                            break;
                        case 2:
                            player = new Archer(playerName, 1, new Castle(150, 0, castleName));
                            end = true;
                            break;
                        case 3:
                            player = new Warrior(playerName, 1, new Castle(150, 0, castleName));
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Попробуйте ещё раз");
                            break;
                    }
                if (!end)
                    Console.WriteLine("Попробуйте ещё раз");
            }
            int r = random.Next(3);
            if (r == 0)
                enemy = new Mage("ЗЛОЙ ВОДНЫЙ МАГ", 9, new Castle(150, 10, "Королевство из магов 1"));
            else if (r == 1)
                enemy = new Archer("ГРАФИНЯ ИЗ CLASH ROYALE", 9, new Castle(150, 10, "CLASH OF CLANS"));
            else 
                enemy = new Warrior("БЕЗЫМЯННЫЙ ЗЛОДЕЙ", 9, new Castle(150, 10, "Королевство из магов 2"));
            targets = new List<ITargetable> { player, player.MyCastle, enemy, enemy.MyCastle };
            enemyTargets = new List<ITargetable> { enemy, enemy.MyCastle };
            while (player.MyCastle.HP > 0 && enemy.MyCastle.HP > 0)
            {
                UpdateGameField();
                ProcessTurn(player, enemy);
                if (enemy.MyCastle.HP <= 0) break;
                ProcessTurn(enemy, player);
                currentMove++;
            }
            
            Console.WriteLine(player.MyCastle.HP > 0 ? "ВЫ ПОБЕДИЛИ!" : "ВЫ ПРОИГРАЛИ!");
        }
        private void ProcessTurn(IUnit active, IUnit opponent)
        {
            Console.WriteLine();
            Console.WriteLine(active.Update());
            Console.WriteLine(active.MyCastle.Update());
            int count = currentMove > 5 ? 5 : currentMove+1;
            for (int i = 0; i < random.Next(1,count); i++)
                active.Inventory.Add(GenerateRandomPotion());
            if (active.HP == 0 && active.Position != 52)
            {
                Console.WriteLine($"!!! {active.Name} ПАЛ!!! ИНВЕНТАРЬ ПЕРЕХОДИТ К {opponent.Name}.");
                opponent.Inventory.AddRange(active.Inventory);
                active.Inventory.Clear();
                if (active is IStunnable stunnable)
                    stunnable.SetStun(2);
                active.Position = 52;
            }
            if (active is IStunnable && ((IStunnable)active).StunRoundsCount > 0)
            {
                Console.WriteLine($"! {active.Name} пропускает ход (Оглушение еще {((IStunnable)active).StunRoundsCount} ход/а).");
                return;
            }
            if (active.HP == 0 && (active is IStunnable && ((IStunnable)active).StunRoundsCount == 0 || !(active is IStunnable)))
            {
                if (active == player)
                    active.Position = player.MyCastle.Position + 1;
                else
                    active.Position = enemy.MyCastle.Position - 1;
                Console.WriteLine("ПРОТИВНИК ВОССТАНОВИЛСЯ И ГОТОВ ВНОВЬ ПОКИНУТЬ СВОЙ ЗАМОК!!!");
                new Spell<IHealable, IUnit>(new Panacea(), 0).Use(active);
                return;
            }
            if (active.Name == _playerName) PlayerAction(active, opponent); else AIAction(active, opponent);
        }
        private void PlayerAction(IUnit player, IUnit enemy)
        {
            while (true)
            {
                Console.WriteLine("Нажмите любую клавишу для очистки консоли");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Статус противника: {enemy.HP} | Замок HP: {enemy.MyCastle.HP}");
                Console.WriteLine($"[Статус] Маг HP: {player.HP} | Замок HP: {player.MyCastle.HP}");
                Console.WriteLine(gameField);
                Console.WriteLine("Ваш инвентарь:");
                for (int i = 0; i < player.Inventory.Count; i++)
                    Console.WriteLine($"{i}: {player.Inventory[i].Description}");
                Console.WriteLine();
                var validPotions = player.Inventory.Where(p => p.CanBeUsedBy(player)).ToList();
                Console.WriteLine("ПЕРЕДВИЖЕНИЕ ИЛИ АТАКА ЗАВЕРШАЮТ ХОД!!! Заклинаний можно использовать сколько угодно!!!");
                Console.WriteLine("Укажите a (английскую) если хотите отступить; Укажите d если хотите подойти к замку врага");
                Console.WriteLine("Укажите f, если хотите провести атаку." + (player.Position == altar.Position ? "Укажите q если хотите пожертвовать способность алтарю." : null));
                Console.WriteLine("Укажите s, если хотите пропустить ход.");
                Console.WriteLine("Укажите номер способности, которую вы хотите использовать");
                string choice = Console.ReadLine();
                if (choice == "s")
                {
                    Console.WriteLine($"И {player.Name} СТОИТ НА МЕСТЕ, ПРОВОЦИРУЯ {enemy.Name}!!!");
                    break;
                }
                else if (choice == "q" && altar.Position == player.Position)
                {
                    Console.WriteLine("Выберите способность продвинутого уровня, которую вы готовы пожертвовать");
                    if (!int.TryParse(Console.ReadLine(), out int index))
                    {
                        Console.WriteLine("ТАКОГО ЗЕЛЬЯ/СПОСОБНОСТИ НЕТ!!! ПОПРОБУЙТЕ СНОВА!!!");
                        continue;
                    }
                    var potion = player.Inventory[index];
                    if (potion is ISpellAttacker<Mage> highQualityPotion)
                    {
                        Console.WriteLine();
                        var scroll = new SpellScroll<Mage>(highQualityPotion);
                        string result = altar.Sacrifice(scroll);
                        Console.WriteLine($">> {result}");
                        player.Inventory.RemoveAt(index);
                        if (altar.Reward)
                            player.Inventory.Add(new Spell<IDamageable, IUnit>(new FireballEffect(), 25));
                        altar.Reward = false;
                    }
                    else
                        Console.WriteLine(">> Алтарь отвергает это! Нужна способность ПРОДВИНУТОГО уровня");
                }
                else if (choice == "d")
                {
                    if (player.Position + 1 != enemy.MyCastle.Position && player.Position + 1 != enemy.Position)
                    {
                        player.Move(1);
                        Console.WriteLine("ВЫ ИДЁТЁ В СТОРОНУ ВРАГА!!!");
                        break;
                    }
                    else
                        Console.WriteLine("Данный ход невозможен!!!");
                }
                else if (choice == "a")
                {
                    if (player.Position - 1 != player.MyCastle.Position)
                    {
                        player.Move(-1);
                        Console.WriteLine("ВЫ БЕЖИТЕ С ПОЛЯ БОЯ?!");
                        break;
                    }
                    else
                        Console.WriteLine("Данный ход невозможен!!!");
                }
                else if (choice == "f")
                {
                    Console.WriteLine("Выберите цель атаки:");
                    for (int i = 0; i < enemyTargets.Count; i++)
                        Console.WriteLine($"{i}: {enemyTargets[i].Name}");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < enemyTargets.Count)
                    {
                        if (enemyTargets[index] is IDamageable target)
                            if (Math.Abs(player.Position - target.Position) <= player.AttackRange)
                            {
                                Console.WriteLine(player.Attack(target));
                                break;
                            }
                            else
                                Console.WriteLine($"Атака противника не сможет достичь {target.Name}!!!");
                    }
                }
                else if (int.TryParse(choice, out int idx) && idx >= 0 && idx < player.Inventory.Count)
                {
                    var potion = player.Inventory[idx];
                    if (!validPotions.Contains(potion))
                    {
                        Console.WriteLine($"\n{player.Name} не способен использовать заклинания высшего уровня!!!\n");
                        continue;
                    }
                    var validTargets = targets.Where(t => potion.CanTarget(t)).ToList();
                    Console.WriteLine("Выберите цель:");
                    for (int j = 0; j < validTargets.Count; j++)
                        Console.WriteLine($"{j}: {validTargets[j].Name}");
                    Console.Write("Цель: ");
                    if (int.TryParse(Console.ReadLine(), out int tIdx) && tIdx >= 0 && tIdx < validTargets.Count)
                    {
                        var target = validTargets[tIdx];
                        if (Math.Abs(player.Position - target.Position) <= player.AttackRange)
                        {
                            string result = potion.Use(validTargets[tIdx]);
                            Console.WriteLine($">> {result}");
                            player.Inventory.RemoveAt(idx);
                        }
                        else
                            Console.WriteLine($"Данная способность не может достигнуть {target.Name}");
                    }
                }
                else
                    Console.WriteLine("НЕИЗВЕСТНАЯ КОМАНДА!!! ПОПРОБУЙТЕ СНОВА!!!");
            }
            Console.WriteLine();
        }
        private void AIAction(IUnit enemy, IUnit player)
        {
            while (true)
            {
                int firstSpellCount = enemy.Inventory.Count;
                int lastSpellCount = firstSpellCount;
                if (enemy.HP != enemy.MaxHP)
                {
                    var potion = enemy.Inventory.Find(p => p is ISpellTarget<IHealable>);
                    if (potion != null)
                    {
                        string result = potion.Use(enemy);
                        Console.WriteLine($">> {result}");
                        enemy.Inventory.Remove(potion);
                        lastSpellCount--;
                    }
                }
                if (Math.Abs(enemy.Position - player.Position) - 1 <= player.AttackRange && enemy is IStunnable stunnable && !stunnable.IsProtectedFromStun)
                {
                    var potion = enemy.Inventory.Find(p => p.Description == "НАШАТЫРНЫЙ СПИРТ"); // костыль
                    if (potion != null)
                    {
                        string result = potion.Use(enemy);
                        Console.WriteLine($">> {result}");
                        enemy.Inventory.Remove(potion);
                        lastSpellCount--;
                    }
                }
                if (enemy.Position == altar.Position && !(enemy is Mage))
                {
                    var potions = enemy.Inventory.FindAll(p => p is ISpellAttacker<Mage>);
                    if (potions != null)
                        foreach (var potion in potions)
                        {
                            string result = altar.Sacrifice(new SpellScroll<Mage>(potion as ISpellAttacker<Mage>));
                            Console.WriteLine($">> {result}");
                            enemy.Inventory.Remove(potion);
                            lastSpellCount--;
                            if (altar.Reward)
                                enemy.Inventory.Add(new Spell<IDamageable, IUnit>(new FireballEffect(), 25));
                            altar.Reward = false;
                        }
                }
                if (firstSpellCount == lastSpellCount)
                    break;
            }
            var validPotions = enemy.Inventory.FindAll(p => p.CanBeUsedBy(enemy) && !(p.Description == "НАШАТЫРНЫЙ СПИРТ" || p is ISpellTarget<IHealable>));
            var potentialTargets = new List<ITargetable>
            {
                player, player.MyCastle
            };
            foreach (var potion in validPotions) 
            {
                var validTargets = potentialTargets.Where(t => potion.CanTarget(t) && Math.Abs(enemy.Position - player.Position) <= enemy.AttackRange).ToList();
                if (validTargets.Count > 0)
                {
                    
                    ITargetable finalTarget = validTargets.Find(t => t == player.MyCastle) ?? player;
                    if (finalTarget == player && player.HP == 0)
                        break;
                    Console.WriteLine($"{enemy.Name} ИСПОЛЬЗУЕТ {potion.Description} ПРОТИВ {finalTarget.Name}");
                    string result = potion.Use(finalTarget);
                    Console.WriteLine($">> {result}");
                    enemy.Inventory.Remove(potion);
                }
            }
            if (Math.Abs(enemy.Position - player.MyCastle.Position) <= enemy.AttackRange)
                Console.WriteLine(enemy.Attack(player.MyCastle));
            else if (Math.Abs(enemy.Position - player.Position) <= enemy.AttackRange && player.HP > 0)
                Console.WriteLine(enemy.Attack(player));
            else
            {
                Console.WriteLine("ПРОТИВНИК ПРИБЛИЖАЕТСЯ!!!");
                enemy.Move(-1);
            }
        }












        private ISpellTarget<ITargetable> GenerateRandomPotion()
        {
            int r = random.Next(101);
            if (r < 5) return new Spell<IHealable,IUnit>(new Panacea(), 0);
            if (r < 10) return new Spell<IDamageable, Mage>(new FireballEffect() { Description = "ГОРЯЧАЯ КОРТОШЕЧКА!!!" }, 20);
            if (r < 25) return new Spell<IHealable, IUnit>(new HealthEffect(), 25);
            if (r < 40) return new Spell<IPoisonable, Mage>(new PoisonEffect(), 15);
            if (r < 55) return new Spell<IBurnable,Mage>(new FireEffect(), 20);
            if (r < 70) return new Spell<IStunnable,Mage>(new StunEffect(), 0);
            if (r < 85) return new Spell<IStunnable, IUnit>(new StunProtectionEffect(), 0);
            if (r < 100) return new Spell<IDamageable,Mage>(new RockEffect(), 25);
            if (r == 100) return new Spell<IUnit, Archer>(new MilitaryNotice(), 0);
            return new Spell<Castle, IUnit>(new FireballEffect(), 25);
        }
    }
}
