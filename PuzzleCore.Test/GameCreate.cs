using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class GameCreate
    {
        [Fact]
        public void CreatedGame_NotNull()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });

            var sut = new Game(startState);

            Assert.NotNull(sut);
        }

        [Fact]
        public void CreatedGame_WithFinalState_NotNull()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });
            var finalState = new BoardState(2, 2, new int[] { 1, 2, 3, 0 });

            var sut = new Game(startState, finalState);

            Assert.NotNull(sut);
        }

        [Fact]
        public void CreatedGame_StoresStartState()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });

            var sut = new Game(startState);

            Assert.Equal(startState, sut.StartState);
        }

        [Fact]
        public void CreatedGame_WithFinalState_StoresStartState()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });
            var finalState = new BoardState(2, 2, new int[] { 1, 2, 3, 0 });

            var sut = new Game(startState, finalState);

            Assert.Equal(startState, sut.StartState);
        }

        [Fact]
        public void CreatedGame_WithFinalState_StoresFinalState()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });
            var finalState = new BoardState(2, 2, new int[] { 1, 0, 3, 2 });

            var sut = new Game(startState, finalState);

            Assert.Equal(finalState, sut.FinalState);
        }

        [Fact]
        public void CreatedGame_WithoutFinalState_StoresDefaultFinalState()
        {
            var startState = new BoardState(2, 2, new int[] { 0, 1, 2, 3 });
            var finalState = new BoardState(2, 2, new int[] { 1, 2, 3, 0 });

            var sut = new Game(startState, finalState);

            Assert.Equal(finalState, sut.FinalState);
        }

        [Fact]
        public void CreateGame_DifferentBoardSizes_Throw()
        {
            var startState = new BoardState(2, 3, new int[] { 0, 1, 2, 3, 4, 5 });
            var finalState = new BoardState(2, 2, new int[] { 1, 2, 3, 0 });

            Assert.Throws<ArgumentException>(() => new Game(startState, finalState));
        }
    }
}
