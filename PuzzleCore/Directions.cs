using System;

namespace PuzzleCore
{
    [Flags]
    public enum Directions
    {
        None = 0,
        Left = 1,
        Up = 2,
        Right = 4,
        Down = 8
    }
}