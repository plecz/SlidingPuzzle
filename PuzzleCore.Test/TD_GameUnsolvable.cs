using System;
using Xunit;

using PuzzleCore;

public class TD_GameUnsolvable : TheoryData<BoardState>
{
    public TD_GameUnsolvable()
    {
        Add(new BoardState(2, 2, new int[] { 1, 3, 2, 0 }));
        Add(new BoardState(3, 2, new int[] { 4, 5, 0, 1, 3, 2 }));
    }
}
