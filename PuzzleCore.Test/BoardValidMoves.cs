using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardValidMoves
    {
        [Theory]
        [ClassData(typeof(TD_ValidMoves))]
        public void ValidMoves_AreCorrect(string boardData, Directions moves)
        {
            var sut = BoardState.FromString(boardData);

            Assert.Equal(moves, sut.ValidMoves);
        }
    }
}
