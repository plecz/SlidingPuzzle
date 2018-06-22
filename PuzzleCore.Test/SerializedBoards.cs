using System;
using System.Collections;
using Xunit;

public class SerializedBoards : TheoryData<string, int, int, int[]>
{
    public SerializedBoards()
    {
        Add(@"2, 2,
              0, 1,
              2, 3",
            2, 2,
            new int[] { 0, 1,
                        2, 3});
        Add(@"3, 3,
              1, 2, 3,
              4, 0, 5,
              6, 7, 8",
            3, 3,
            new int[] {1, 2, 3,
                       4, 0, 5,
                       6, 7, 8});
    }
}
