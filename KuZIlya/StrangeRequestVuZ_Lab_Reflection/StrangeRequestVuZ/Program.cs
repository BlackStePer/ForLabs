
using System.Text;

namespace StrangeRequestVuZ
{
    /// <summary>
    /// Беспаолезный класс
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Бесполезная функция
        /// </summary>
        /// <param name="args">хз что это</param>
        private static void Main(string[] args)
        {
            List<object> initialList =
            [
                new Car("Tesla", 500),      // Обычный объект
                new SecretData(),         // Нечитаемый объект
                "Это строка",                // Тип String
                new Car("BMW", 300),         // Объект для глубокой проверки
                new LegacyData()             // [NotComparable]
            ];
            List<object> controlList =
            [
                new Car("Tesla", 500),      // ТЕСТ 4: Совпадение
                new SecretData(),         // ТЕСТ 2: Будет помечен как нечитаемый
                12345,                       // ТЕСТ 3: Ошибка типа (int вместо string)
                new Car("BMW", 301),         // ТЕСТ 4: Глубокая ошибка в CarEngine.HorsePower
                new LegacyData(),            // ТЕСТ 2 и 4: [NotComparable] — поля не сравниваются
                "ЛИШНЯЯ ХРЕНЬ"             // ТЕСТ 1: Ошибка длины списка
            ];
            ObjectConverter converter = new(initialList);
            StringBuilder report = converter.Compare(controlList);
            Console.WriteLine(report.ToString());
        }
    }
}