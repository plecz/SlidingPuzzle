using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardMove
    {
        [Theory]
        [ClassData(typeof(TD_Move_Up))]
        public void MoveUp_SwapsTilesCorrectly(BoardState before, BoardState after)
        {
            var sut = before.Move(Directions.Up);

            Assert.Equal(after.Tiles, sut.Tiles);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Down))]
        public void MoveDown_SwapsTilesCorrectly(BoardState before, BoardState after)
        {
            var sut = before.Move(Directions.Down);

            Assert.Equal(after.Tiles, sut.Tiles);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Left))]
        public void MoveLeft_SwapsTilesCorrectly(BoardState before, BoardState after)
        {
            var sut = before.Move(Directions.Left);

            Assert.Equal(after.Tiles, sut.Tiles);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Right))]
        public void MoveRight_SwapsTilesCorrectly(BoardState before, BoardState after)
        {
            var sut = before.Move(Directions.Right);

            Assert.Equal(after.Tiles, sut.Tiles);
        }
    }
}
