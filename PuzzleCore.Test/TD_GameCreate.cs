using System;
using Xunit;

public class TD_CreateGame : TheoryData<string>
{
    public TD_CreateGame()
    {
        Add(@"2, 2,
              0, 1,
              2, 3");

        Add(@"3, 3,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8");

        Add(@"4, 4,
               1,  2,  3,  4,
               5,  6,  0,  7,
               8,  9, 10, 11,
              12, 13, 14, 15");
    }
}
