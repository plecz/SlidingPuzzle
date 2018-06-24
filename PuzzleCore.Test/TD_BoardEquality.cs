﻿using System;
using Xunit;

namespace PuzzleCore.Test
{
    class TD_BoardEquality : TheoryData<string, string, bool>
    {
        public TD_BoardEquality()
        {
            Add(@"2, 2,
                  0, 1,
                  2, 3",
                @"2, 2,
                  0, 1,
                  2, 3",
                true);

            Add(@"2, 2,
                  0, 1,
                  2, 3",
                @"2, 2,
                  0, 1,
                  3, 2",
                false);

            Add(@"3, 2,
                  1, 2, 3,
                  4, 5, 0",
                @"3, 2,
                  1, 2, 3,
                  4, 5, 0",
                true);

            Add(@"3, 2,
                  1, 2, 3,
                  4, 5, 0",
                @"3, 2,
                  1, 4, 3,
                  2, 5, 0",
                false);

            Add(@"2, 3,
                  1, 4,
                  2, 3,
                  0, 5",
                @"2, 3,
                  1, 4,
                  2, 3,
                  0, 5",
                true);

            Add(@"2, 3,
                  1, 4,
                  2, 3,
                  0, 5",
                @"2, 3,
                  1, 0,
                  2, 3,
                  4, 5",
                false);

            Add(@"3, 3,
                  1, 2, 3,
                  4, 5, 6,
                  7, 8, 0",
                @"3, 3,
                  1, 2, 3,
                  4, 5, 6,
                  7, 8, 0",
                true);

            Add(@"3, 3,
                  1, 2, 3,
                  7, 5, 6,
                  4, 8, 0",
                @"3, 3,
                  1, 2, 3,
                  4, 5, 6,
                  7, 8, 0",
                false);

            Add(@"2, 3,
                  1, 2,
                  3, 4,
                  5, 0",
                @"3, 2,
                  1, 2, 3,
                  4, 5, 0",
                false);
        }
    }
}
