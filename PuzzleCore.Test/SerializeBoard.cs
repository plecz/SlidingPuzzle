using System;
using System.Linq;
using Xunit;

namespace PuzzleCore.Test
{
    public class SerializeBoard
    {
        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_NotEmpty(int width, int height)
        {
            var sut = new Board(width, height);

            Assert.False(string.IsNullOrWhiteSpace(sut.ToString()));
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectNumberOfElements(int width, int height)
        {
            var sut = new Board(width, height);

            var elements = SplitData(sut.ToString());

            Assert.Equal(width * height + 2, elements.Length);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_AllElementsParseableToInt(int width, int height)
        {
            var sut = new Board(width, height);

            var integers = Array.ConvertAll(SplitData(sut.ToString()), int.Parse);

            Assert.True(true);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void SerializedBoard_HasCorrectWidth(int width)
        {
            var sut = new Board(width, 5);
            var expected = width.ToString();

            var elements = SplitData(sut.ToString());
            var strWidth = elements[0];

            Assert.Equal(expected, strWidth);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void SerializedBoard_HasCorrectHeight(int height)
        {
            var sut = new Board(5, height);
            var expected = height.ToString();

            var elements = SplitData(sut.ToString());
            var strHeight = elements[1];

            Assert.Equal(expected, strHeight);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectInitialStateData(int width, int height)
        {
            var sut = new Board(width, height);

            var integers = Array.ConvertAll(SplitData(sut.ToString()), int.Parse);

            Assert.Equal(sut.State, integers.Skip(2));

        }

        private string[] SplitData(string data)
        {
            var elements = data.Split(',');
            return Array.ConvertAll(elements, s => s.Trim());
        }
    }
}
