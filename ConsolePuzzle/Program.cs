using System;
using System.Collections.Generic;
using System.Threading;

using PuzzleCore;
using PuzzleSolver;

namespace ConsolePuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 4;
            int height = 4;
            if (args.Length >= 3)
            {
                width = int.Parse(args[1]);
                height = int.Parse(args[2]);
            }

            Game game = new Game(Game.GetRandomState(width, height));

            var config = DisplayConfig.Default;
            _display = new Display(width * height, config);

            bool running = true;
            while (running)
            {
                _display.Dump(game);

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
                    case ConsoleKey.A:
                        Solve(game);
                        break;
                    case ConsoleKey.S:
                        game.Shuffle();
                        break;
                    case ConsoleKey.R:
                        Replay(game);
                        break;
                    case ConsoleKey.Q:
                        game.Reset();
                        break;
                    default:
                        break;
                }

                d = d & game.CurrentBoardState.ValidMoves;
                if (d != Directions.None)
                {
                    game.Move(d);
                }
            }
        }

        static void Solve(Game game)
        {
            game.Reset();
            var moves = Solver.Solve(game.CurrentBoardState, game.FinalState);

            Replay(game, moves);
        }

        static void Replay(Game game, IEnumerable<Directions> moves = null)
        {
            if (moves == null)
            {
                moves = new List<Directions>(game.Moves);
            }

            game.Reset();
            foreach (var m in moves)
            {
                _display.Dump(game);
                game.Move(m);
                Thread.Sleep(500);
            }
        }

        private static Display _display;
    }
}
