using PuzzleCore;
using System;

namespace ConsolePuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 4;
            int height = 4;

            Board board = new Board(width, height);


            BoardDisplay display = new BoardDisplay(width * height);

            bool running = true;
            while (running)
            {
                Console.Clear();
                display.DumpBoard(board);

                var d = Directions.None;
                var c = Console.ReadKey(true).Key;
                switch (c)
                {
                    case ConsoleKey.UpArrow:
                        d = Directions.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        d = Directions.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        d = Directions.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        d = Directions.Right;
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    default:
                        break;
                }

                if (d != Directions.None)
                {
                    board = board.Move(d);
                }
            }
        }
    }
}
