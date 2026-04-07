//using RogueLib.Entities;

//namespace RogueLib
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Screen screen = new Screen(78, 25);

//            string map =
//                """
//                ┌──────────────────────────────┐
//                │.................@............│
//                │..............................│
//                │..............................│
//                │..............................│
//                └──────────────────────────────┘
//                """;

//            screen.Draw(map);
//            screen.Draw('@', new Vector2(18, 1), ConsoleColor.Yellow);
//            screen.Display();

//            Console.SetCursorPosition(0, 7);
//            Console.ReadKey(true);
//        }
//    }
//}