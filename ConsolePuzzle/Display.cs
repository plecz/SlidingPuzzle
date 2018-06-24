using PuzzleCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePuzzle
{
    public class Display
    {
        public Display(int boardsize, DisplayConfig config)
        {
            _tileFormat = new String('0', boardsize.ToString().Length);
            _config = config;
        }

        public void Dump(Game game)
        {
            Console.Clear();
            DumpBoard(game.CurrentBoardState);
            Console.WriteLine();
            HR();
            DumpGameInfo(game);
            HR();
            DumpControls();
            HR();
            DumpLastMoves(game);
        }

        private void DumpBoard(BoardState board)
        {
            for (int i = 0; i < board.Height; ++i)
            {
                for (int j = 0; j < board.Width; ++j)
                {
                    var tile = board.Tiles[j + i * board.Width];
                    Console.Write($"{_config.LeftTileDelimiter}{FormatTile(tile)}{_config.RightTileDelimiter} ");
                }
                Console.WriteLine();
            }
        }

        private void DumpGameInfo(Game game)
        {
            Console.WriteLine($"Moves: {game.Moves.Count}");
            Console.WriteLine($"Puzzle solved: {game.IsSolved}");
        }

        private void DumpLastMoves(Game game, int moveCount = 100)
        {
            var lastMoves = game.Moves.Skip(game.Moves.Count - moveCount);
            foreach (var m in lastMoves)
            {
                Console.Write($"{_config.Move[m]} ");
            }
        }

        private void DumpControls()
        {
            Console.Write("Move tiles: arrow keys");
            Console.Write(" | ");
            Console.Write("Shuffle board: S");
            Console.Write(" | ");
            Console.Write("Autosolve: A");
            Console.Write(" | ");
            Console.Write("Replay moves: R");
            Console.Write(" | ");
            Console.Write("Reset puzzle: Q");
            Console.Write(" | ");
            Console.Write("Quit: ESC");
            Console.WriteLine();
        }

        private void HR(char c = '-', int n = 70)
        {
            Console.WriteLine(new string('-', n));
        }

        private string FormatTile(int t)
        {
            if (t == 0)
            {
                return new String('_', _tileFormat.Length);
            }
            else
            {
                return t.ToString(_tileFormat);
            }
        }

        private string _tileFormat;
        private DisplayConfig _config;
    }
}
