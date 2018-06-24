using System;
using System.Linq;
using Xunit;

namespace PuzzleCore.Test
{
    public class SerializeBoard
    {
        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_NotEmpty(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            Assert.False(string.IsNullOrWhiteSpace(sut.ToString()));
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectNumberOfElements(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            var elements = SplitData(sut.ToString());

            Assert.Equal(width * height + 2, elements.Length);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_AllElementsParseableToInt(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            var integers = Array.ConvertAll(SplitData(sut.ToString()), int.Parse);

            Assert.True(true);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectWidth(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);
            var expected = width.ToString();

            var elements = SplitData(sut.ToString());
            var strWidth = elements[0];

            Assert.Equal(expected, strWidth);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectHeight(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);
            var expected = height.ToString();

            var elements = SplitData(sut.ToString());
            var strHeight = elements[1];

            Assert.Equal(expected, strHeight);
        }

        [Theory]
        [ClassData(typeof(TD_StandardBoardSizes))]
        public void SerializedBoard_HasCorrectTileData(int width, int height, int[] tiles)
        {
            var sut = new BoardState(width, height, tiles);

            Assert.Equal(tiles, sut.Tiles);

        }

        private string[] SplitData(string data)
        {
            var elements = data.Split(',');
            return Array.ConvertAll(elements, s => s.Trim());
        }
    }
}
