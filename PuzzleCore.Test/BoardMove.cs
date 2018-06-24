using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardMove
    {
        [Theory]
        [ClassData(typeof(TD_Move_Up))]
        public void MoveUp_SwapsTilesCorrectly(Board before, Board after)
        {
            var sut = before.Move(Directions.Up);

            Assert.Equal(after.State, sut.State);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Down))]
        public void MoveDown_SwapsTilesCorrectly(Board before, Board after)
        {
            var sut = before.Move(Directions.Down);

            Assert.Equal(after.State, sut.State);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Left))]
        public void MoveLeft_SwapsTilesCorrectly(Board before, Board after)
        {
            var sut = before.Move(Directions.Left);

            Assert.Equal(after.State, sut.State);
        }

        [Theory]
        [ClassData(typeof(TD_Move_Right))]
        public void MoveRight_SwapsTilesCorrectly(Board before, Board after)
        {
            var sut = before.Move(Directions.Right);

            Assert.Equal(after.State, sut.State);
        }
    }
}
