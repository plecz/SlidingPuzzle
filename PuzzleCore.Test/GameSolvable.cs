using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class GameSolvable
    {
        [Theory]
        [ClassData(typeof(TD_GameSolvable))]
        public void CreateGame_SolvableStartState_DefaultFinalState_NotNull(BoardState startState)
        {
            var sut = new Game(startState);

            Assert.NotNull(sut);
        }

        [Theory]
        [ClassData(typeof(TD_GameUnsolvable))]
        public void CreateGame_UnsolvableStartState_DefaultFinalState_Throw(BoardState startState)
        {
            Assert.Throws<ArgumentException>(() => new Game(startState));
        }
    }
}
