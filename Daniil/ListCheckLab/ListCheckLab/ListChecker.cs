using ListCheckLab.Attributes;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace ListCheckLab
{
    /// <summary>
    /// Объект, сравнивающий два списка
    /// </summary>
    internal class ListChecker
    {
        public List<object> oldlist { get; set; }

        /// <summary>
        /// Сравнение двух списков
        /// </summary>
        /// <param name="newlist">Список для сравнения</param>
        /// <returns>Результат сравнения</returns>
        public string СompareLists(List<object> newlist)
        {
            string message = "Коллекции равны";

            if (oldlist.Count != newlist.Count)
            {
                return $"Длины списков не совпадают!\n" +
                       $"Длинна полученого списка: {newlist.Count}\n" +
                       $"Ожидалось: {oldlist.Count}";
            }

            for(int i = 0; i < newlist.Count; i++)
            {
                Type oldType = oldlist[i].GetType(),
                     newType = newlist[i].GetType();

                if(Attribute.IsDefined(newType, typeof(NotComparable)) ||
                    Attribute.IsDefined(newType, typeof(Unreadable)))
                {
                    return $"Найден нечитаемый тип {newType.Name}!\n" +
                           $"В позиции: {i}";
                }
                else if(oldType != newType)
                {
                    return $"Найдено расхождение в типах!\n" +
                           $"В позиции: {i}\n" +
                           $"Получено: {newType.Name}\n" +
                           $"Ожидалось: {oldType.Name}";
                }

                FieldInfo[] fields = oldType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.Static);

                for (int j = 0; j < fields.Length; j++)
                {
                    if (!fields[j].GetValue(oldlist[i]).Equals(fields[j].GetValue(newlist[i])))
                    {
                        return $"Найдено расхождение в значениях!\n" +
                               $"В позиции {i} | В поле: {fields[j].Name}\n" +
                               $"Получено {fields[j].GetValue(newlist[i])}\n" +
                               $"Ожидалось {fields[j].GetValue(oldlist[i])}";
                    }
                }

            }
            return message;
        }

        public ListChecker(List<object> oldlist)
        {
            this.oldlist = oldlist; 
        }
    }
}
