using System;
using Xunit;

public class TD_StandardBoardSizes : TheoryData<int, int>
{
    public TD_StandardBoardSizes()
    {
        Add(2, 2);
        Add(2, 3);
        Add(2, 4);
        Add(3, 2);
        Add(3, 3);
        Add(3, 4);
        Add(4, 2);
        Add(4, 3);
        Add(4, 4);
    }
}
