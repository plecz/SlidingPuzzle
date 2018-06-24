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
            int rndCount = 100;
            if (args.Length >= 3)
            {
                width = int.Parse(args[1]);
                height = int.Parse(args[2]);
            }
            if (args.Length >= 4)
            {
                rndCount = int.Parse(args[3]);
            }

            Game game = new Game(Game.GetRandomState(width, height, rndCount));

            var config = DisplayConfig.Default;

            BoardDisplay display = new BoardDisplay(width * height, config);

            bool running = true;
            while (running)
            {
                Console.Clear();
                display.DumpBoard(game.CurrentBoardState);

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
                    case ConsoleKey.S:
                        //autosolve
                        break;
                    case ConsoleKey.R:
                        //randomize
                        break;
                    default:
                        break;
                }

                if (d != Directions.None)
                {
                    game.Move(d);
                }
            }
        }
    }
}
