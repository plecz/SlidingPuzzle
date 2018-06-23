using System;
using Xunit;
using PuzzleCore;

public class TD_ValidMoves : TheoryData<string, Directions>
{
    public TD_ValidMoves()
    {
        Add(@"2, 2,
              0, 1,
              2, 3",
            Directions.Right | Directions.Down);

        Add(@"2, 2,
              1, 0,
              2, 3",
            Directions.Left | Directions.Down);

        Add(@"2, 2,
              2, 1,
              0, 3",
            Directions.Right | Directions.Up);

        Add(@"2, 2,
              2, 1,
              3, 0",
            Directions.Left | Directions.Up);

        Add(@"3, 3,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8",
            Directions.Left | Directions.Right | Directions.Up | Directions.Down);

        Add(@"3, 3,
              1, 0, 3,
              4, 2, 5,
              6, 7, 8",
            Directions.Left | Directions.Right | Directions.Down);

        Add(@"3, 3,
              1, 2, 3,
              4, 7, 5,
              6, 0, 8",
            Directions.Left | Directions.Right | Directions.Up);

        Add(@"3, 3,
              1, 2, 3,
              0, 7, 5,
              6, 4, 8",
            Directions.Right | Directions.Up | Directions.Down);

        Add(@"3, 3,
              1, 2, 3,
              4, 7, 0,
              6, 8, 5",
            Directions.Left | Directions.Up | Directions.Down);
    }
}
