using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardCreate
    {
        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void CreatedBoard_NotNull(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateBoard_SmallWidth_Throw(int width)
        {
            Assert.Throws<ArgumentException>(() => new BoardState(width, 5, new int[] { }));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateBoard_SmallHeight_Throw(int height)
        {
            Assert.Throws<ArgumentException>(() => new BoardState(5, height, new int[] { }));
        }


        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void CreatedBoard_StoreWidth(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            Assert.Equal(width, sut.Width);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]

        public void CreatedBoard_StoreHeight(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            Assert.Equal(height, sut.Height);
        }
    }
}
