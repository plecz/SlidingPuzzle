using System;
using Xunit;

using PuzzleCore;

namespace PuzzleCore.Test
{
    class TD_GameSolved : TheoryData<BoardState, bool>
    {
        public TD_GameSolved()
        {

            Add(new BoardState(2, 2, new int[] { 1, 2, 0, 3 }), false);
            Add(new BoardState(2, 2, new int[] { 1, 2, 3, 0 }), true);
            Add(new BoardState(3, 2, new int[] { 1, 2, 0, 4, 5, 3 }), false);
            Add(new BoardState(3, 2, new int[] { 4, 5, 0, 1, 2, 3 }), false);
            Add(new BoardState(3, 2, new int[] { 1, 2, 3, 4, 5, 0 }), true);
            Add(new BoardState(2, 3, new int[] { 1, 2, 3, 0, 5, 4 }), false);
            Add(new BoardState(2, 3, new int[] { 1, 2, 3, 4, 5, 0 }), true);
            Add(new BoardState(3, 3, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }), false);
            Add(new BoardState(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }), true);
        }
    }
}
