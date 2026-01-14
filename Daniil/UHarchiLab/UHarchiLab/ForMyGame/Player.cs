using System;
using System.Collections.Generic;
namespace UHarchiLab.ForMyGame
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    internal class Player
    {
        static Dictionary<int, string> StatsByIndex = new Dictionary<int, string>() 
        {
            {1, "Белки"},
            {2, "Жиры"},
            {3, "Углеводы"},
        };

        private int myHeal, myDamage, hp = 5;
        private string nickname;

        public Cart<IFood> Abilities { get; set; } = new Cart<IFood>();

        public Player(int heal, int damage, string name)
        {
            myHeal = heal;
            myDamage = damage;
            nickname = name;
        }

        /// <summary>
        /// Возврат сообщения о состоянии игрока
        /// </summary>
        /// <returns>Статистика игрока</returns>
        public string GetStat()
        {
            string stat = $"Статистика: {nickname}\n\n" +
                          $"Хил: {Player.StatsByIndex[myHeal]}    |    Уязвимость: {Player.StatsByIndex[myDamage]}\n" +
                          $"HP: {hp}\n" +
                          $"Способности:\n" +
                          Abilities.GetGoodsList() +
                          $"4 - Сменить свои способности\n" +
                          $"5 - Сменить способности врага\n" +
                          $"==================================================================================\n\n";
            return stat;
        }

        /// <summary>
        /// Использование способности на этого героя
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="endgame"></param>
        /// <returns></returns>
        public string UseAbility(IFood ability, out bool endgame)
        {
            endgame = false;

            int temp;
            if (ability.Proteins)
                temp = 1;
            else if (ability.Fats)
                temp = 2;
            else
                temp = 3;

            if (temp == myHeal)
            {
                if(hp == 5)
                {
                    return $"Способность {ability.Name} давала {Player.StatsByIndex[temp]} и подхилила {nickname}, но увы он итак фуловый";
                }
                hp++;
                return $"Способность {ability.Name} давала {Player.StatsByIndex[temp]} и подхилила {nickname}";
            }
            else if (temp == myDamage)
            {
                if (hp == 1)
                {
                    endgame = true;
                    return $"Способность {ability.Name} давала {Player.StatsByIndex[temp]} и убила {nickname}";
                }
                hp--;
                return $"Способность {ability.Name} давала {Player.StatsByIndex[temp]} и ранила {nickname}";
            }
            else
            {
                return $"Способность {ability.Name} давала {Player.StatsByIndex[temp]}, а {nickname} на них плевал";
            }
        }
        /// <summary>
        /// Перевод в строку
        /// </summary>
        /// <returns>Имя персонажа</returns>
        public override string ToString()
        {
            return nickname;
        }

    }
}
