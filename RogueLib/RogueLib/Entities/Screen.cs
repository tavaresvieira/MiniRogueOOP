using System.Text;

namespace RogueLib.Entities
{
    public class Screen
    {
        private const ConsoleColor NotAColor = (ConsoleColor)(-1);

        private readonly int _width;
        private readonly int _height;

        private readonly char[,] _back;
        private readonly char[,] _front;
        private readonly ConsoleColor[,] _backColor;
        private readonly ConsoleColor[,] _frontColor;

        public Screen(int width = 78, int height = 25)
        {
            _width = width;
            _height = height;

            _back = new char[_width, _height];
            _front = new char[_width, _height];
            _backColor = new ConsoleColor[_width, _height];
            _frontColor = new ConsoleColor[_width, _height];

            Init();
        }

        public void Init()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            ResetFront();
            ClearBack();
        }

        public void Draw(string s)
        {
            ClearBack();
            BuildFrame(s);
        }

        public void Draw(char c, Vector2 pos, ConsoleColor foregroundColor = NotAColor)
        {
            if (pos.X < 0 || pos.X >= _width || pos.Y < 0 || pos.Y >= _height)
                return;

            ConsoleColor fgColor = Console.ForegroundColor;
            if (foregroundColor != NotAColor)
                fgColor = foregroundColor;

            _back[pos.X, pos.Y] = c;
            _backColor[pos.X, pos.Y] = fgColor;
        }

        public void Display()
        {
            FlushToScreen();
        }

        private void ResetFront()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _front[x, y] = '\0';
                    _frontColor[x, y] = NotAColor;
                }
            }
        }

        private void ClearBack()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _back[x, y] = ' ';
                    _backColor[x, y] = ConsoleColor.White;
                }
            }
        }

        private void BuildFrame(string s)
        {
            string[] lines = s.Replace("\r", "").Split('\n');

            for (int y = 0; y < _height && y < lines.Length; y++)
            {
                for (int x = 0; x < _width && x < lines[y].Length; x++)
                {
                    _back[x, y] = lines[y][x];
                    _backColor[x, y] = ConsoleColor.White;
                }
            }
        }

        private void FlushToScreen()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_back[x, y] == _front[x, y] &&
                        _backColor[x, y] == _frontColor[x, y])
                    {
                        continue;
                    }

                    Console.SetCursorPosition(x, y);

                    ConsoleColor savedColor = Console.ForegroundColor;
                    Console.ForegroundColor = _backColor[x, y];
                    Console.Write(_back[x, y]);
                    Console.ForegroundColor = savedColor;

                    _front[x, y] = _back[x, y];
                    _frontColor[x, y] = _backColor[x, y];
                }
            }

            Console.ResetColor();
        }
    }
}