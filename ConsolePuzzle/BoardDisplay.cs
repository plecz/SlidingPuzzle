﻿using PuzzleCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePuzzle
{
    public class BoardDisplay
    {
        public BoardDisplay(int boardsize)
        {
            _tileFormat = new String('0', boardsize.ToString().Length);
        }

        public void DumpBoard(Board board)
        {
            for (int i = 0; i < board.Height; ++i)
            {
                for (int j = 0; j < board.Width; ++j)
                {
                    var tile = board.State[j + i * board.Width];
                    Console.Write($"[{FormatTile(tile)}] ");
                }
                Console.WriteLine();
            }
        }

        public string FormatTile(int t)
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
    }
}