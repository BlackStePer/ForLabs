using BadMarketVuz;
using BadMarketVuZ.Work.Entities;

namespace BadMarketVuZ.Work.Scenes
{
    /// <summary>
    /// Игровая сцена
    /// </summary>
    internal class GameScene : Scene
    {
        private readonly List<Entity> entities;
        private readonly Player player;
        private readonly int currentLevel;
        private int steps;
        public GameScene(int level)
        {
            currentLevel = level;
            steps = 0;
            entities = [];
            if (level == 0)
            {
                entities.Add(new Wall(new Rectangle(2, 0, 3, 1)));
                entities.Add(new Wall(new Rectangle(2, 1, 1, 3)));
                entities.Add(new Wall(new Rectangle(0, 3, 2, 1)));
                entities.Add(new Wall(new Rectangle(0, 4, 1, 2)));
                entities.Add(new Wall(new Rectangle(1, 5, 2, 1)));
                entities.Add(new Wall(new Rectangle(3, 5, 1, 3)));
                entities.Add(new Wall(new Rectangle(3, 7, 2, 1)));
                entities.Add(new Wall(new Rectangle(5, 4, 1, 4)));
                entities.Add(new Wall(new Rectangle(4, 1, 1, 1)));
                entities.Add(new Wall(new Rectangle(4, 2, 4, 1)));
                entities.Add(new Wall(new Rectangle(7, 3, 1, 1)));
                entities.Add(new Wall(new Rectangle(6, 4, 2, 1)));
                entities.Add(new Button(new Point(3, 1)));
                entities.Add(new Button(new Point(1, 4)));
                entities.Add(new Button(new Point(4, 6)));
                entities.Add(new Button(new Point(6, 3)));
                entities.Add(new Box(new Point(3, 3)));
                entities.Add(new Box(new Point(3, 4)));
                entities.Add(new Box(new Point(4, 5)));
                entities.Add(new Box(new Point(5, 3)));
                player = new Player(new Point(4, 4));
                salary = 1000;
            }
            else if (level == 1)
            {
                entities.Add(new Wall(new Rectangle(0, 0, 4, 1)));
                entities.Add(new Wall(new Rectangle(0, 1, 1, 4)));
                entities.Add(new Wall(new Rectangle(4, 0, 1, 5)));
                entities.Add(new Wall(new Rectangle(1, 4, 2, 2)));
                entities.Add(new Wall(new Rectangle(1, 6, 1, 2)));
                entities.Add(new Wall(new Rectangle(1, 8, 4, 1)));
                entities.Add(new Wall(new Rectangle(5, 4, 2, 1)));
                entities.Add(new Wall(new Rectangle(6, 2, 1, 3)));
                entities.Add(new Wall(new Rectangle(7, 2, 2, 1)));
                entities.Add(new Wall(new Rectangle(8, 2, 1, 6)));
                entities.Add(new Wall(new Rectangle(5, 7, 3, 1)));
                entities.Add(new Wall(new Rectangle(5, 6, 1, 3)));
                entities.Add(new Button(new Point(7, 3)));
                entities.Add(new Button(new Point(7, 4)));
                entities.Add(new Button(new Point(7, 5)));
                entities.Add(new Box(new Point(2, 2)));
                entities.Add(new Box(new Point(2, 3)));
                entities.Add(new Box(new Point(3, 2)));
                player = new Player(new Point(1, 1));
                salary = 3000;
            }
            entities.Add(player);
            foreach (Entity entity in entities)
                entity.rectangle.Y += 3;
        }
        public override void OnInput(char command)
        {
            Rectangle newRectangle = player.rectangle.Clone();
            switch (command)
            {
                case 'w':
                    newRectangle.Y -= 1;
                    break;
                case 'a':
                    newRectangle.X -= 1;
                    break;
                case 's':
                    newRectangle.Y += 1;
                    break;
                case 'd':
                    newRectangle.X += 1;
                    break;
                case 'r':
                    Program.RunScene(new GameScene(currentLevel));
                    return;
                case 'm':
                    Program.RunScene(new MenuScene());
                    return;
                default:
                    return;
            }
            bool possible = true;
            foreach (Entity entity in entities)
            {
                if (entity is Wall && newRectangle.Intersects(entity.rectangle))
                {
                    possible = false;
                    break;
                }
                else if (entity is Box && newRectangle.Intersects(entity.rectangle))
                {
                    Rectangle test = newRectangle.Clone();
                    switch (command)
                    {
                        case 'w':
                            test.Y -= 1;
                            break;
                        case 'a':
                            test.X -= 1;
                            break;
                        case 's':
                            test.Y += 1;
                            break;
                        case 'd':
                            test.X += 1;
                            break;
                    }
                    foreach (Entity subEntity in entities)
                        if ((subEntity is Wall || subEntity is Box) && test.Intersects(subEntity.rectangle))
                        {
                            possible = false;
                            break;
                        }
                    if (possible)
                        entity.rectangle = test;
                    break;
                }
            }
            if (possible)
            {
                player.rectangle = newRectangle;
                steps += 1;
            }
        }
        public override void Update(ref char[,] screen)
        {
            foreach (Entity entity in entities)
                entity.Draw(ref screen);
            string tempStr = "ПРИВЕТ СКЛАД";
            for (int i = 0; i < Math.Min(tempStr.Length, screen.GetLength(1)); i++)
                screen[0, i] = tempStr[i];
            tempStr = "КОЛ-ВО ШАГОВ: " + steps;
            for (int i = 0; i < Math.Min(tempStr.Length, screen.GetLength(1)); i++)
                screen[1, i] = tempStr[i];
            tempStr = "ОСТАЛОСЬ: " + GetRemaining();
            for (int i = 0; i < Math.Min(tempStr.Length, screen.GetLength(1)); i++)
                screen[2, i] = tempStr[i];
            if (GetRemaining() == 0)
            {
                Program.RunScene(new MenuScene() { workIsOver = true });
            }
        }
        /// <summary>
        /// Дает информацию о том, сколько коробок не на кнопках
        /// </summary>
        /// <returns>сколько коробок не на кнопках</returns>
        public int GetRemaining()
        {
            int count = 0;
            foreach (Entity entity1 in entities)
                if (entity1 is Box box)
                {
                    foreach (Entity entity2 in entities)
                        if (entity2 is Button && entity1.rectangle.Intersects(entity2.rectangle))
                            box.onButton = true;
                }
            foreach (Entity entity in entities)
                if (entity is Box && ((Box)entity).onButton == false)
                    ++count;
            return count;
        }
    }
}
