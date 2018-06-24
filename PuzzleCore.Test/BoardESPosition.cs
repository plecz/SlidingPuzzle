using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardESPosition
    {
        #pragma warning disable xUnit1026 // Warning about unused test parameters
        [Theory]
        [ClassData(typeof(TD_ESPosition))]
        public void ESPosition_ColumnCorrect(string data, int column, int row)
        {
            var sut = Board.FromString(data);

            Assert.Equal(sut.ESPosition.Item1, column);
        }

        [Theory]
        [ClassData(typeof(TD_ESPosition))]
        public void ESPosition_RowCorrect(string data, int column, int row)
        {
            var sut = Board.FromString(data);

            Assert.Equal(sut.ESPosition.Item2, row);
        }
        #pragma warning restore xUnit1026
    }
}
