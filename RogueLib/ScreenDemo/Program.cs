using RogueLib.Entities;

namespace ScreenDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen(100, 30);
            GameMap map = new GameMap();
            Player player = new Player(33, 11);

            bool isRunning = true;

            while (isRunning)
            {
                DrawGame(screen, map, player);

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    isRunning = false;
                    continue;
                }

                Vector2 newPos = GetNewPosition(player.Pos, key);

                if (map.IsWalkable(newPos))
                {
                    player.MoveTo(newPos);
                }
            }

            Console.ResetColor();
            Console.Clear();
            Console.CursorVisible = true;
        }

        static void DrawGame(Screen screen, GameMap map, Player player)
        {
            string hud =
                $"""

                Position: {player.Pos}
                Controls: WASD / Arrow Keys
                Press Q to quit
                """;

            string fullScreen = map.MapText + hud;

            screen.Draw(fullScreen);
            screen.Draw(player.Glyph, player.Pos, ConsoleColor.Yellow);
            screen.Display();
        }

        static Vector2 GetNewPosition(Vector2 currentPos, ConsoleKeyInfo key)
        {
            Vector2 newPos = currentPos;

            switch (key.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    newPos.Y--;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    newPos.Y++;
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    newPos.X--;
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    newPos.X++;
                    break;
            }

            return newPos;
        }
    }
}