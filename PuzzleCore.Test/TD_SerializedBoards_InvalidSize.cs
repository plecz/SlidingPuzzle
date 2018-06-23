using System;
using System.Collections;
using Xunit;

public class TD_SerializedBoards_InvalidSize : TheoryData<string>
{
    public TD_SerializedBoards_InvalidSize()
    {
        // Wrong width
        Add(@"4, 2,
              0, 1,
              2, 3");
        Add(@"2, 3,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8");

        // Wrong height
        Add(@"2, 4,
              0, 1,
              2, 3");
        Add(@"3, 2,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8");

        // Wrong width and height
        Add(@"3, 3,
              0, 1,
              2, 3");
        Add(@"4, 5,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8");

        // Invalid height
        Add(@"2, 1,
              0, 1");

        // Invalid width
        Add(@"1, 2,
              0,
              1");

        // Invalid/wrong width
        Add(@"0, 3,
              0, 1,
              2, 3");
        Add(@"-1, 3,
              0, 1,
              2, 3");

        // Invalid/wrong height
        Add(@"2, 0,
              0, 1,
              2, 3");
        Add(@"2, -3,
              0, 1,
              2, 3");
    }
}
