using System;
using System.Collections.Generic;

namespace SmartPhone8
{
    internal static class GameHepler
    {
        public static string info = "Приветствую игрок! Если ты хочешь подготовиться к свойе первой работе и одновременно с этим подучить математику, ЭТА ИГРА ДЛЯ ТЕБЯ!\n\n" +
            "Твоя задача - продать всем покупателям магазина девайсы, причем без разницы, что и кому ты продашь, важно чтобы никто не ушёл без техники!\n" +
            "Проблема заключается в том, что для поставщика техники очень важен ум продавца, поэтому количество техники, которое у тебя будет, \n" +
            "напрямую зависит от твоего интеллека!\n\n" +
            "Теперь конкретно, тебе нужно продать технику четырём волнам покупателей, каждая из которых будет больше предыдущей, и для этого тебе нужно будет \n" +
            "выполнять математические задачки, за что тебе будут давать очки, за которые ты сможешь покупать технику, но учти - с каждой волной задачки будет всё сложнее.\n\n" +
            "Покупать ты можешь Трансформаторы, Телефоны, и Планшеты за 2, 10 и 30 очков.\n" +
            "Сложность в том, что пальцы у всех людей разные. Примерно 50% людей подойдет и просто телефон, но остальные не смогут нормально пользоваться \n" +
            "сенсером и им в добавок к телефону нужен трансформатор который регулирует чувствительность сенсора. Кстати у трансформатора есть два режима, \n" +
            "один повышает, второй понижает чувствительность, но не бойся, за 2 бала ты покупаешь сразу оба типа. Связки Телефон + Трансформатор хватит 80% людей.\n" +
            "Планшет же подходит кому угодно, но и стоит он дорого, и даже решив все задачи волны правильно, ты всё равно не сможешь закупить плашеты на всех\n" +
            "Поэтому распределяй средства с умом =)\n\n" +
            "УДАЧИ!";
        private static Random rnd = new Random();
        public static int score = 0, mylvl = 1;
        public static int[] tsp = { 0, 0, 0 };
        public static bool game = true;

        public static List<Customer> cs1 = new List<Customer>(), cs2 = new List<Customer>(), cs3 = new List<Customer>(), cs4 = new List<Customer>();
        private static string[]
            c1 = { "Биба", "Боба", "Пупа", "Лупа", "Шрек" },
            c2 = { "Питер", "Тони", "Стив", "Брюс", "Лога", "Тор", "Чалла" },
            c3 = { "Эратосфен", "Евклид", "Чева", "Пифагор", "Минелай", "Брахмагупта", "Вандеварден", "Дезарг", "Гаус", "Лейбниц" },
            c4 = { "Сплинтер", "Путин", "Крепыш", "Майк-Вазовский", "Костя", "Волк из ну погоди", "Псай", "Дубострел",
            "Иуда", "Бомж Хобо", "Тирекс", "БР БР Патапим", "Каркарыч", "Бабка ёжка", "Снорк" };
        public static Dictionary<int, List<Customer>> nameToLvl = new Dictionary<int, List<Customer>>
        {
            { 1, cs1 },
            { 2, cs2 },
            { 3, cs3 },
            { 4, cs4 },
        };
        public static Dictionary<int, string[]> questsToLvl = new Dictionary<int, string[]>
        {
            { 1, new string[] {"1 - Задачка на сложение", "2 - Задачка на вычетание", "3 - Задачка на умножение", "4 - Задачка на деление"} },
            { 2, new string[] {"1 - Задачка на углы треугольника", "2 - Задачка на стороны параллелепипеда", "3 - Задачка на площадь" } },
            { 3, new string[] {"1 - Задачка на дискременант", "2 - Задачка на корень квадратного уравнения"} },
            { 4, new string[] {"1 - Задачка на векторы", "2 - Задачка на производные", "3 - Задачка на детерменант"} },
        };
        public static Dictionary<string, int[]> countMoneyTryes = new Dictionary<string, int[]>
        {
            {"11",  new int[] {10, 2}},
            {"12",  new int[] {10, 2}},
            {"13",  new int[] {10, 2}},
            {"14",  new int[] {10, 2}},
            {"21",  new int[] {15, 3}},
            {"22",  new int[] {20, 3}},
            {"23",  new int[] {25, 3}},
            {"31",  new int[] {25, 3}},
            {"32",  new int[] {45, 3}},
            {"41",  new int[] {30, 3}},
            {"42",  new int[] {45, 3}},
            {"43",  new int[] {50, 3}},
        };
        /// <summary>
        /// Метод для статического конструктор, считывает из списка имён именя покупателей
        /// и заполняет список покупателей, создавая их
        /// </summary>
        /// <param name="listToFlow">Список покупателей, который нужно заполнить</param>
        /// <param name="listWithNames">Список имён для покупателей</param>
        private static void FlowList(List<Customer> listToFlow, string[] listWithNames)
        {
            foreach(string s in listWithNames)
            {
                listToFlow.Add(new Customer(s));
            }
        }

        static GameHepler()
        {
            FlowList(cs1, c1);
            FlowList(cs2, c2);
            FlowList(cs3, c3);
            FlowList(cs4, c4);
        }
        /// <summary>
        /// Генерирует задачку и ответ на неё, опираясь на уровень игрока и тип задачи,
        /// который игрок выбрал
        /// </summary>
        /// <param name="lvl">Уровень игрока</param>
        /// <param name="type">Тип задачи, выбранный игроком</param>
        /// <param name="ans">Ответ на задачу</param>
        /// <param name="Eq">Условие задачи</param>
        public static void lvl(string lvl, string type, out int ans, out string Eq)
        {
            int answer = -52;
            string equation = "-52";
            if (lvl == "1")
            {
                int b, y;
                switch (type)
                {
                    case "1":
                        b = rnd.Next(1, 101);
                        y = rnd.Next(1, 101);
                        equation = $"x + {b} = {y}";
                        answer = y - b;
                        break;
                    case "2":
                        b = rnd.Next(1, 101);
                        y = rnd.Next(1, 101);
                        equation = $"x - {b} = {y}";
                        answer = y + b;
                        break;
                    case "3":
                        b = rnd.Next(1, 101);
                        y = b * rnd.Next(1, 11);
                        equation = $"x * {b} = {y}";
                        answer = y / b;
                        break;
                    case "4":
                        b = rnd.Next(1, 11);
                        y = b * rnd.Next(1, 11);
                        equation = $"x / {b} = {y}";
                        answer = y * b;
                        break;
                }
            }
            else if (lvl == "2") 
            {
                switch (type)
                {
                    case "1":
                        int angle1 = rnd.Next(1, 179), angle2 = rnd.Next(1, 180 - angle1);
                        answer = 180 - angle1 - angle2;
                        equation = $"Чему равен 3-ий угол треугольника, если остальные два равны {angle1} и {angle2}?";
                        break;
                    case "2":
                        int a = rnd.Next(1, 11), b = rnd.Next(1, 11), v = a * b * rnd.Next(1, 6);
                        answer = v / a / b;
                        equation = $"Объём параллелепипеда равен {v}, две его перпендикулярные грани равны {a} и {b}. Чему равна третья грань, прпендикулярная им двоим?";
                        break;
                    case "3":
                        int s1 = rnd.Next(1, 11), s2 = rnd.Next(1, 11), s3 = 2 * rnd.Next(1, 6), s4 = rnd.Next(1, 11), p = (s1 + s2 + s3 + s4) / 2;
                        answer = (p - s1) * (p - s2) * (p - s3) * (p - s4);
                        equation = $"Найдите квдрат площади вписанного четырёхугольника, если его стороны равны - {s1}, {s2}, {s3}, {s4}";
                        break;
                }
            }
            else if (lvl == "3")
            {
                int a, b, c;
                switch (type)
                {
                    case "1":
                        a = rnd.Next(1, 11);
                        b = rnd.Next(1, 11);
                        c = rnd.Next(1, 11);
                        answer = b * b - 4 * a * c;
                        equation = $"Вычислите дискрименант уравнения: {a}X^2 + {b}X + {c} = 0";
                        break;
                    case "2":
                        a = rnd.Next(1, 4);
                        b = rnd.Next(1, 11) * a * 2;
                        c = b * b / a / 4;
                        answer = -b;
                        equation = $"Вычислите корень квадратного уравнения: {a}X^2 + {b}X + {c} = 0";
                        break;
                }
            }
            else if (lvl == "4")
            {
                switch (type)
                {
                    case "1":
                        int x1 = rnd.Next(1, 10), x2 = rnd.Next(1, 10), y1 = rnd.Next(1, 10), y2 = rnd.Next(1, 10);
                        answer = x1 * x2 + y1 * y2;
                        equation = $"Посчитайте скалярное произведение векторов a({x1}, {y1} и b({x2}, {y2})";
                        break;
                    case "2":
                        int k1 = rnd.Next(1, 11), k2 = rnd.Next(1, 11), k3 = rnd.Next(1, 11), k4 = rnd.Next(1, 11), x0 = rnd.Next(1, 11);
                        answer = 3 * k1 * x0 * x0 + k2 * 2 * x0 - k3;
                        equation = $"Вычислите значение производной функции f(x) = {k1}X^3 + {k2}X^2 - {k3}X - {k4} в точке Xo = {x0}";
                        break;
                    case "3":
                        int a1 = rnd.Next(1, 10), a2 = rnd.Next(1, 10), a3 = rnd.Next(1, 10), b1 = rnd.Next(1, 10), b2 = rnd.Next(1, 10);
                        int b3 = rnd.Next(1, 10), c1 = rnd.Next(1, 10), c2 = rnd.Next(1, 10), c3 = rnd.Next(1, 10);
                        answer = a1 * b2 * c3 + b1 * c2 * a3 + c1 * a2 * b3 - a3 * b2 * c1 - a2 * b1 * c3 - a1 * c2 * b3;
                        equation = $"Посчитайте детерминант матрицы:\n" +
                            $"|{a1} {a2} {a3}|\n" +
                            $"|{b1} {b2} {b3}|\n" +
                            $"|{c1} {c2} {c3}|\n";
                        break;
                }
            }
            ans = answer;
            Eq = equation;
        }
    }
}
