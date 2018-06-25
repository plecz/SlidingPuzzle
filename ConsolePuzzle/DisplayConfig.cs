using PuzzleCore;
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
        public Dictionary<Directions, char> Move { get; set; }
        public int ReplayDelay { get; set; }

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
                            [Directions.Up] = 'U',   //'↑',
                            [Directions.Down] = 'D', //'↓',
                            [Directions.Left] = 'L', //'←',
                            [Directions.Right] = 'R' //'→'
                        },
                    };
                }
                return _default;
            }
        }

        private static DisplayConfig _default;
    }
}
