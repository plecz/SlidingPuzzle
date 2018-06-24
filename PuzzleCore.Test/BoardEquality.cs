﻿using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class BoardEquality
    {
        [Theory]
        [ClassData(typeof(TD_BoardEquality))]
        public void EqualityTest_GivesCorrectResults(string boardData, string otherData, bool expected)
        {
            var sut = Board.FromString(boardData);
            var other = Board.FromString(otherData);

            Assert.Equal(sut.Equals(other), expected);
        }
    }
}
