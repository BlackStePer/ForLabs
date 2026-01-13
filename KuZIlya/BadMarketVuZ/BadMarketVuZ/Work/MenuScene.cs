using BadMarketVuz;

namespace BadMarketVuZ.Work
{
    internal class MenuScene : Scene
    {
        public MenuScene() { }
        public override void Update(ref char[,] screen)
        {
            if (workIsOver)
                return;
            string text = "ВРЕМЯ РАБОТАТЬ\n";
            text += "ВЫБОР СКЛАДА:\n";
            text += "1) СКЛАД 1\n";
            text += "2) СКЛАД 2\n";
            int i = 0;
            int j = 0;
            foreach (char c in text)
            {
                if (c == '\n')
                {
                    i = 0;
                    ++j;
                    continue;
                }
                screen[j, i] = c;
                ++i;
            }
        }
        public override void OnInput(char command)
        {
            switch (command)
            {
                case '1':
                    Program.RunScene(new GameScene(0));
                    return;
                case '2':
                    Program.RunScene(new GameScene(1));
                    return;
            }
        }

    }
}
