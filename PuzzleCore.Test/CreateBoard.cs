using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class CreateBoard
    {
        [Theory]
        [ClassData(typeof(StandardBoardSizes))]
        public void CreatedBoard_NotNull(int width, int height)
        {
            var sut = new Board(width, height);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateBoard_SmallWidth_Throw(int width)
        {
            Assert.Throws<ArgumentException>(() => new Board(width, 5));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateBoard_SmallHeight_Throw(int height)
        {
            Assert.Throws<ArgumentException>(() => new Board(5, height));
        }


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CreatedBoard_StoreWidth(int width)
        {
            var sut = new Board(width, 5);

            Assert.Equal(width, sut.Width);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void CreatedBoard_StoreHeight(int height)
        {
            var sut = new Board(5, height);

            Assert.Equal(height, sut.Height);
        }

        [Theory]
        [ClassData(typeof(StandardBoardSizes))]
        public void CreateBoard_InitialState(int width, int height)
        {
            var length = width * height;
            var state = new int[length];
            for (int i = 0; i < length- 1; ++i)
            {
                state[i] = i + 1;
            }
            state[length - 1] = 0;

            var sut = new Board(width, height);

            Assert.Equal(state, sut.State);
        }
    }
}
