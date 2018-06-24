﻿using PuzzleCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePuzzle
{
    public class DisplayConfig
    {
        public char LeftTileDelimiter { get; set; }
        public char RightTileDelimiter { get; set; }
        public char EmptySpace { get; set; }
        Dictionary<Directions, char> Move { get; set; }
        //public char MoveUp { get; set; }
        //public char MoveDown { get; set; }
        //public char MoveLeft { get; set; }
        //public char MoveRight { get; set; }

        public static DisplayConfig Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new DisplayConfig
                    {
                        LeftTileDelimiter = '[',
                        RightTileDelimiter = ']',
                        EmptySpace = '_',
                        Move = new Dictionary<Directions, char>
                        {
                            [Directions.Up] = '↑',
                            [Directions.Down] = '↓',
                            [Directions.Left] = '←',
                            [Directions.Right] = '→'
                        }
                    };
                }
                return _default;
            }
        }

        private static DisplayConfig _default;
    }
}