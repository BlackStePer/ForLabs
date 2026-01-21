using System.Reflection;
using System.Text;

namespace StrangeRequestVuZ
{
    /// <summary>
    /// Класс, делает всё, что требует лаба
    /// </summary>
    internal class ObjectConverter
    {
        private readonly List<object> firstlList;
        public ObjectConverter(List<object> firstlList) => this.firstlList = firstlList ?? [];
        /// <summary>
        /// Сравнивает исходный и сравниваемый с ним списки
        /// </summary>
        /// <param name="secondList">Сравниваемый список</param>
        /// <returns>Сообщение о процессе срвнения</returns>
        public StringBuilder Compare(List<object> secondList)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("ТЕСТ 1: Проверка длины");
            if (firstlList.Count != secondList.Count)
                stringBuilder.AppendLine($"Списки не равны по длине!!!. Ожидалось: {firstlList.Count}, получено: {secondList.Count}");
            int minCount = Math.Min(firstlList.Count, secondList.Count);
            stringBuilder.AppendLine("\n\n\nТЕСТ 2: Проверка на читаемость");
            for (int i = 0; i < minCount; i++)
            {
                if (IsUnreadable(firstlList[i]))
                    stringBuilder.AppendLine($"В позиции {i} (исходный) найден нечитаемый объект типа {firstlList[i].GetType().Name}");
                if (IsUnreadable(secondList[i]))
                    stringBuilder.AppendLine($"В позиции {i} (сравниваемый) найден нечитаемый объект типа {secondList[i].GetType().Name}");
            }
            stringBuilder.AppendLine("\n\n\nТЕСТ 3: Сравнение типов");
            for (int i = 0; i < minCount; i++)
            {
                Type type1 = firstlList[i].GetType();
                Type type2 = secondList[i].GetType();
                if (type1 != type2)
                    stringBuilder.AppendLine($"Позиция {i}: Расхождение в типе. Ожидался {type1.Name}, получен {type2.Name}");
            }
            stringBuilder.AppendLine("\n\n\nТЕСТ 4: Сравнение значений полей (глубокое)");
            for (int i = 0; i < minCount; i++)
            {
                object obj1 = firstlList[i];
                object obj2 = secondList[i];
                if (obj1.GetType() == obj2.GetType() && !IsUnreadable(obj1) && !IsUnreadable(obj2))
                    CompareFields(obj1, obj2, i.ToString(), stringBuilder);
            }
            return stringBuilder;
        }
        /// <summary>
        /// Читаемый ли объект
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Читаемый или нет</returns>
        private bool IsUnreadable(object obj)
        {
            if (obj == null) return false;
            Type type = obj.GetType();
            return type.GetCustomAttribute<NotComparableAttribute>() != null || type.GetCustomAttribute<UnreadableAttribute>() != null;
        }
        /// <summary>
        /// Сравнивает два объекта
        /// </summary>
        /// <param name="obj1">Первый объект</param>
        /// <param name="obj2">Второй объект</param>
        /// <param name="path">Позиция + вложенности</param>
        /// <param name="stringBuilder">Нужно для вывода сообщений</param>
        private void CompareFields(object obj1, object obj2, string path, StringBuilder stringBuilder)
        {
            if (obj1 == null || obj2 == null)
            {
                if (!Equals(obj1, obj2))
                    stringBuilder.AppendLine($"Позиция {path}: Один из объектов null.");
                return;
            }
            Type type = obj1.GetType();
            if (type.IsPrimitive || obj1 is string || type.IsValueType)
            {
                if (!Equals(obj1, obj2))
                    stringBuilder.AppendLine($"Позиция {path}: Расхождение значения. Ожидалось '{obj1}', получено '{obj2}'");
                return;
            }
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                if (field.GetCustomAttribute<UnreadableAttribute>() != null) continue;
                object val1 = field.GetValue(obj1);
                object val2 = field.GetValue(obj2);
                CompareFields(val1, val2, $"{path}.{field.Name}", stringBuilder);
            }
        }
    }
}
