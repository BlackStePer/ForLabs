using SIBfu9.Disciplines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIBfu9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Discipline> disciplines = new List<Discipline>() { new English(), new History(), new MathAn(), new Programming(), new PE()};
            Random rand = new Random();
            bool automate;

            Console.WriteLine("Почувствуй себя студентом и попробуй закрыть все предметы на автоматы, удачи!!!");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Введите ваше имя:");
            Student player = new Student(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("=Английский=");
            Console.WriteLine("Введите английсикий алфавит заглавными буквами без пробелов:");
            
            string alf = Console.ReadLine(), corrAlf = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int corr = 0;
            for (int i = 0; i < Math.Min(corrAlf.Length, alf.Length); i++)
            {
                if (alf[i] == corrAlf[i])
                {
                    corr++;
                }
            }

            player.FinalControll[disciplines[0]] = corr * 100 / 26;
            player.Check(disciplines[0], out automate);

            Console.Clear();
            if (!automate)
            {
                Console.WriteLine("Увы, ты проиграл, слишком плохо ты знаешь алфавит");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("История");
            int choice = rand.Next(0, 3);
            Dictionary<string, int> histEvents = new Dictionary<string, int>()
            {
                {"В каком году началась вторая мировая война?",  1939},
                {"В каком году произошла отмена крепостного права?", 1861},
                {"Год крещения Руси", 988}
            };
            Console.WriteLine(histEvents.Keys.ElementAt(choice));
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.Clear();
                Console.WriteLine("Вводи нормально, а пока ты проиграл!");
                Console.ReadKey();
                return;
            }
            else if(Math.Abs(year - histEvents.Values.ElementAt(choice)) > 40)
            {
                player.FinalControll[disciplines[1]] = 0;
                player.Practice[disciplines[1]] = 0;
            }
            else if(Math.Abs(year - histEvents.Values.ElementAt(choice)) > 20)
            {
                player.FinalControll[disciplines[1]] = 10;
                player.Practice[disciplines[1]] = 5;
            }
            else if (Math.Abs(year - histEvents.Values.ElementAt(choice)) > 0)
            {
                player.FinalControll[disciplines[1]] = 70;
                player.Practice[disciplines[1]] = 7;
            }
            else
            {
                player.FinalControll[disciplines[1]] = 100;
                player.Practice[disciplines[1]] = 10;
            }

            Console.Clear();
            player.Check(disciplines[1], out automate);

            if (!automate)
            {
                Console.WriteLine("Увы, ты проиграл, слишком плохо ты знаешь историю!");
                Console.ReadKey();
                return;
            }

            bool game = true;
            int temp, step = 0;
            string s = "00000";
            List<int> steps = new List<int>();
            while(steps.Count < 5)
            {
                temp = rand.Next(0, 5);
                if (!steps.Contains(temp))
                {
                    steps.Add(temp);
                }
            }
            int mist = 0;
            while (game)
            {
                Console.Clear();
                Console.WriteLine("Матанализ");
                Console.WriteLine("Разгадайте последовательность, превращая нули в еденицы:");
                Console.WriteLine(s);
                if(s == "11111")
                {
                    break;
                }
                Console.WriteLine("Какой смивол поменяем?");
                if(!int.TryParse(Console.ReadLine(), out int change) || change > 5 || change < 1 || steps[step] != change - 1)
                {
                    s = "00000";
                    step = 0;
                    mist++;
                }
                else
                {
                    char[] arr = s.ToCharArray();
                    arr[change - 1] = Convert.ToChar("1");
                    s = new string(arr);
                    step++;
                }

            }
            Console.ReadKey();

            if(mist > 20)
            {
                player.FinalControll[disciplines[2]] = 0;
            }
            else if(mist > 10)
            {
                player.FinalControll[disciplines[2]] = 70;
            }
            else
            {
                player.FinalControll[disciplines[2]] = 100;
            }

            player.Check(disciplines[1], out automate);
            Console.Clear();
            if (!automate)
            {
                
                Console.WriteLine("Увы, ты проиграл, слишком плохо ты запоминаешь!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("АХАХАХАХАХАХАХ");
            Console.WriteLine("Хоть ты и всё прошёл, здесь нельзя победить, ведь за физру нельзя получить автомат)))");
            Console.WriteLine("Но всегда можно посмотреть свой результат:");
            Console.ReadKey();
            foreach(Discipline discipline in disciplines)
            {
                Console.WriteLine(player.Check(discipline, out automate));
            }


        }
    }
}
