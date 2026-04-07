using RogueLib.Entities;

namespace ScreenDemo
{
    public class Player
    {
        public Vector2 Pos { get; set; }
        public char Glyph => '@';

        public Player(int x, int y)
        {
            Pos = new Vector2(x, y);
        }

        public void MoveTo(Vector2 newPos)
        {
            Pos = newPos;
        }
    }
}