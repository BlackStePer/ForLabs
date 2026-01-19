using System;
using System.Collections.Generic;
using VirusLab.ForGame;

namespace VirusLab
{
    /// <summary>
    /// Игровой уровень
    /// </summary>
    internal class Level
    {
        private int weight, height;
        public int FreezeTime { get; set; } = 0;
        public Skyda Player { get; set; }
        private Defender[] defenders;
        private Vulnerability[] vulnerabilities;
        private string[][] map;
        private Random rnd = new Random();
        private Freeze[] freezes;

        /// <summary>
        /// Заполнение данных об уровне
        /// </summary>
        /// <param name="weight">Ширина карты</param>
        /// <param name="height">Высота карты</param>
        /// <param name="levelType">Тип уровня(Влияет на спавн объектов)</param>
        /// <param name="sys">Система для взлома</param>
        /// <param name="skyda">Игрок</param>
        public Level(int weight, int height, int levelType, ProtectionSystem sys, Skyda skyda)
        {
            Player = skyda;
            this.weight = weight;
            this.height = height;

            map = new string[height + 2][];
            for(int i = 0; i < weight + 2; i++)
            {
                map[i] = new string[weight + 2];
            }
            for (int i = 0; i <= weight + 1; i++) 
            {
                map[0][i] = "0";
            }
            for(int i = 1; i <= height; i++)
            {
                map[i][0] = "0";
                for (int j = 1; j <= weight; j++)
                {
                    map[i][j] = " ";
                }
                map[i][height + 1] = "0";
            }
            for (int i = 0; i <= weight + 1; i++)
            {
                map[height + 1][i] = "0";
            }

            switch (levelType)
            {
                case 1:
                    SetPlayer(sys);
                    SetDefenders(2);
                    SetPoint(1);
                    break;
                case 2:
                    SetPlayer(sys);
                    SetDefenders(4);
                    SetPoint(2);
                    break;
                case 3:
                    SetPlayer(sys);
                    SetDefenders(3);
                    SetPoint(1);
                    SetFreeze(1);
                    break;
                case 4:
                    SetPlayer(sys);
                    SetDefenders(4);
                    SetPoint(1);
                    SetFreeze(2);
                    break;
                case 5:
                    SetPlayer(sys);
                    SetDefenders(10);
                    SetPoint(3);
                    SetFreeze(5);
                    break;
            }
        }
        
        /// <summary>
        /// Базовая установка игрока на карту
        /// </summary>
        /// <param name="sys">Система взламываемая игроком</param>
        private void SetPlayer(ProtectionSystem sys)
        {
            Player.X = rnd.Next(1, weight + 1);
            Player.Y = rnd.Next(1, height + 1);
            map[Player.Y][Player.X] = "V";
        }

        /// <summary>
        /// Базая установка защитников на карту
        /// </summary>
        /// <param name="defCount">Количество защитников</param>
        private void SetDefenders(int defCount)
        {
            defenders = new Defender[defCount];
            for (int i = 0; i < defCount; i++) 
            {
                while (true)
                {
                    int x = rnd.Next(1, weight + 1), y = rnd.Next(1, height + 1);
                    if (map[y][x] == " " && (Math.Abs(Player.X - x) > 3 || Math.Abs(Player.Y - y) > 3))
                    {
                        defenders[i] = new Defender(x, y);
                        map[y][x] = "D";
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Базовая установка уязвимостей на карту
        /// </summary>
        /// <param name="pointCount">Количество уязвимостей</param>
        private void SetPoint(int pointCount)
        {
            vulnerabilities = new Vulnerability[pointCount];
            for(int i = 0; i < pointCount; i++)
            {
                while (true)
                {
                    int x = rnd.Next(1, weight + 1), y = rnd.Next(1, height + 1);
                    if (map[y][x] == " ")
                    {
                        vulnerabilities[i] = new Vulnerability(x, y);
                        map[y][x] = "o";
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Базовая установка сфер заморозки на карту
        /// </summary>
        /// <param name="freezeCount">Количество сфер заморозки</param>
        private void SetFreeze(int freezeCount)
        {
            freezes = new Freeze[freezeCount];
            for (int i = 0; i < freezeCount; i++)
            {
                while (true)
                {
                    int x = rnd.Next(1, weight + 1), y = rnd.Next(1, height + 1);
                    if (map[y][x] == " ")
                    {
                        freezes[i] = new Freeze(x, y);
                        map[y][x] = "*";
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Смена позиций все объектов на карте
        /// </summary>
        /// <param name="key">Клавиша нажатая игроком</param>
        /// <returns>Закончилась ли игра</returns>
        public bool ChangePositions(ConsoleKey key)
        {
            int x = Player.X, y = Player.Y;
            bool end = false;
            switch (key)
            {
                case ConsoleKey.A:
                    x--;
                    break;
                case ConsoleKey.W:
                    y--;
                    break;
                case ConsoleKey.S:
                    y++;
                    break;
                case ConsoleKey.D:
                    x++;
                    break;
            }
            switch (map[y][x])
            {
                case " ":
                    map[Player.Y][Player.X] = " ";
                    map[y][x] = "V";
                    Player.X = x; Player.Y = y;
                    break;
                case "D":;
                    return true;
                case "0":
                    return end;
                case "o":
                    map[Player.Y][Player.X] = " ";
                    map[y][x] = "V";
                    Player.X = x; Player.Y = y;
                    Player.ProtectionSystem.Security += 0.3;
                    if (Player.ProtectionSystem.Security >= 1)
                        return true;
                    break;
                case "*":
                    map[Player.Y][Player.X] = " ";
                    map[y][x] = "V";
                    Player.X = x; Player.Y = y;
                    Player.FreezeTime += 3;
                    break;
            }
            if(FreezeTime == 0)
            {
                foreach (Defender def in defenders)
                {
                    string defMove;
                    if (def.X != x && def.Y != y)
                    {
                        defMove = rnd.Next(1, 3) == 2 ? "X" : "Y";
                    }
                    else if (def.X != x)
                    {
                        defMove = "X";
                    }
                    else
                    {
                        defMove = "Y";
                    }

                    int lastX = def.X, lastY = def.Y;
                    switch (defMove)
                    {
                        case "X":
                            if (def.X > x)
                                def.X--;
                            else
                                def.X++;
                            break;
                        case "Y":
                            if (def.Y > y)
                                def.Y--;
                            else
                                def.Y++;
                            break;
                    }
                    if (map[def.Y][def.X] == " ")
                    {
                        map[lastY][lastX] = " ";
                        map[def.Y][def.X] = "D";
                    }
                    else if (map[def.Y][def.X] == "V")
                    {
                        return true;
                    }
                    else
                    {
                        def.Y = lastY; def.X = lastX;
                    }
                }
            }
            else
            {
                FreezeTime--;
            }
                foreach (Vulnerability point in vulnerabilities)
                {
                    if (map[point.Y][point.X] != "o")
                    {
                        while (true)
                        {
                            point.X = rnd.Next(1, weight + 1);
                            point.Y = rnd.Next(1, height + 1);
                            if (map[point.Y][point.X] == " ")
                            {
                                map[point.Y][point.X] = "o";
                                break;
                            }
                        }
                    }
                }
            if(freezes != null)
            {
                foreach (Freeze freeze in freezes)
                {
                    if (map[freeze.Y][freeze.X] != "*")
                    {
                        while (true)
                        {
                            freeze.X = rnd.Next(1, weight + 1);
                            freeze.Y = rnd.Next(1, height + 1);
                            if (map[freeze.Y][freeze.X] == " ")
                            {
                                map[freeze.Y][freeze.X] = "*";
                                break;
                            }
                        }
                    }
                }
            }
            return end;
        }

        public override string ToString()
        {
            string temp = "";
            foreach (string[] s in map)
            {
                foreach (string s2 in s)
                {
                    temp += s2;
                }
                temp += "\n";
            }
            return temp;
        }
    }
}
