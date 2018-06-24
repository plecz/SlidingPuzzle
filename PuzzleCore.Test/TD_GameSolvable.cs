using System;
using Xunit;

using PuzzleCore;

public class TD_GameSolvable : TheoryData<BoardState>
{
    public TD_GameSolvable()
    {
        Add(new BoardState(2, 2, new int[] { 1, 2, 0, 3 }));
        Add(new BoardState(2, 2, new int[] { 1, 2, 3, 0 }));
        Add(new BoardState(3, 2, new int[] { 1, 2, 0, 4, 5, 3 }));
        Add(new BoardState(3, 2, new int[] { 4, 5, 0, 1, 2, 3 }));
        Add(new BoardState(2, 3, new int[] { 1, 2, 3, 0, 5, 4 }));
        Add(new BoardState(3, 3, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }));
        Add(new BoardState(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }));
    }
}
