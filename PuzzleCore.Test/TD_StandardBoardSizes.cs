using System;
using Xunit;

public class TD_StandardBoardSizes : TheoryData<int, int, int[]>
{
    public TD_StandardBoardSizes()
    {
        Add(2, 2, new int[] { 1, 2, 3, 0 } );
        Add(2, 3, new int[] { 1, 2, 3, 4, 5, 0 });
        Add(2, 4, new int[] { 1, 2, 3, 4, 5, 6, 7, 0 });
        Add(3, 2, new int[] { 1, 2, 3, 4, 5, 0 });
        Add(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 });
        Add(3, 4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0 });
        Add(4, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 0 });
        Add(4, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0 });
        Add(4, 4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 });
    }
}
