using System;
using Xunit;
using PuzzleCore;

public class TD_Move_Up : TheoryData<BoardState, BoardState>
{
    public TD_Move_Up()
    {
        BoardState before;
        BoardState after;

        before = BoardState.FromString(@"2, 2,
                                    2, 1,
                                    0, 3");
        after = BoardState.FromString(@"2, 2,
                                   0, 1,
                                   2, 3");
        Add(before, after);

        before = BoardState.FromString(@"2, 2,
                                    2, 1,
                                    3, 0");
        after = BoardState.FromString(@"2, 2,
                                   2, 0,
                                   3, 1");
        Add(before, after);


        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    0, 4, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   0, 2, 3,
                                   1, 4, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 0, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 0, 3,
                                   4, 2, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 5, 0,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 0,
                                   4, 5, 3,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    6, 4, 5,
                                    0, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   0, 4, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 7, 5,
                                    6, 0, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   4, 0, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 5, 8,
                                    6, 7, 0");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   4, 5, 0,
                                   6, 7, 8");
        Add(before, after);
    }
}

public class TD_Move_Down : TheoryData<BoardState, BoardState>
{
    public TD_Move_Down()
    {
        BoardState before;
        BoardState after;

        before = BoardState.FromString(@"2, 2,
                                    0, 1,
                                    2, 3");
        after = BoardState.FromString(@"2, 2,
                                   2, 1,
                                   0, 3");
        Add(before, after);

        before = BoardState.FromString(@"2, 2,
                                    1, 0,
                                    2, 3");
        after = BoardState.FromString(@"2, 2,
                                   1, 3,
                                   2, 0");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    0, 1, 3,
                                    4, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   4, 1, 3,
                                   0, 2, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 0, 3,
                                    4, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   4, 0, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 3, 0,
                                    4, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 3, 5,
                                   4, 2, 0,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    0, 7, 5,
                                    6, 4, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   6, 7, 5,
                                   0, 4, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    7, 0, 5,
                                    6, 4, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   7, 4, 5,
                                   6, 0, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    7, 5, 0,
                                    6, 4, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   7, 5, 8,
                                   6, 4, 0");
        Add(before, after);
    }
}

public class TD_Move_Left : TheoryData<BoardState, BoardState>
{
    public TD_Move_Left()
    {
        BoardState before;
        BoardState after;

        before = BoardState.FromString(@"2, 2,
                                    1, 0,
                                    2, 3");
        after = BoardState.FromString(@"2, 2,
                                   0, 1,
                                   2, 3");
        Add(before, after);

        before = BoardState.FromString(@"2, 2,
                                    1, 3,
                                    2, 0");
        after = BoardState.FromString(@"2, 2,
                                   1, 3,
                                   0, 2");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 0,
                                    4, 7, 3,
                                    6, 8, 5");
        after = BoardState.FromString(@"3, 3,
                                   1, 0, 2,
                                   4, 7, 3,
                                   6, 8, 5");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 7, 0,
                                    6, 8, 5");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   4, 0, 7,
                                   6, 8, 5");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 5,
                                    4, 7, 3,
                                    6, 8, 0");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 5,
                                   4, 7, 3,
                                   6, 0, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 0, 2,
                                    4, 7, 3,
                                    6, 8, 5");
        after = BoardState.FromString(@"3, 3,
                                   0, 1, 2,
                                   4, 7, 3,
                                   6, 8, 5");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 0, 7,
                                    6, 8, 5");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   0, 4, 7,
                                   6, 8, 5");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 5,
                                    4, 7, 3,
                                    6, 0, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 5,
                                   4, 7, 3,
                                   0, 6, 8");
        Add(before, after);
    }
}

public class TD_Move_Right : TheoryData<BoardState, BoardState>
{
    public TD_Move_Right()
    {
        BoardState before;
        BoardState after;

        before = BoardState.FromString(@"2, 2,
                                    0, 1,
                                    2, 3");
        after = BoardState.FromString(@"2, 2,
                                   1, 0,
                                   2, 3");
        Add(before, after);

        before = BoardState.FromString(@"2, 2,
                                    2, 1,
                                    0, 3");
        after = BoardState.FromString(@"2, 2,
                                   2, 1,
                                   3, 0");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    0, 1, 3,
                                    4, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 0, 3,
                                   4, 2, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    4, 1, 3,
                                    0, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   4, 1, 3,
                                   2, 0, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    6, 1, 3,
                                    4, 2, 5,
                                    0, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   6, 1, 3,
                                   4, 2, 5,
                                   7, 0, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 0, 3,
                                    4, 2, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 3, 0,
                                   4, 2, 5,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    1, 2, 3,
                                    4, 0, 5,
                                    6, 7, 8");
        after = BoardState.FromString(@"3, 3,
                                   1, 2, 3,
                                   4, 5, 0,
                                   6, 7, 8");
        Add(before, after);

        before = BoardState.FromString(@"3, 3,
                                    4, 1, 3,
                                    2, 7, 5,
                                    6, 0, 8");
        after = BoardState.FromString(@"3, 3,
                                   4, 1, 3,
                                   2, 7, 5,
                                   6, 8, 0");
        Add(before, after);
    }
}
