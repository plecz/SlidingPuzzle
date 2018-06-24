using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class GameSolved
    {
        [Theory]
        [ClassData(typeof(TD_GameSolved))]
        public void GameStartState_SolvedCheck_Correct(BoardState startState, bool expected)
        {
            var sut = new Game(startState);

            Assert.Equal(expected, sut.IsSolved);
        }
    }
}
