﻿using System;
using Xunit;

namespace PuzzleCore.Test
{
    public class DeserializeBoard
    {
        #pragma warning disable xUnit1026 // Warning about unused test parameters
        [Theory]
        [ClassData(typeof(TD_SerializedBoards))]
        public void DeserializedBoard_NotNull(string data, int width, int height, int[] state)
        {
            var sut = BoardState.FromString(data);

            Assert.NotNull(sut);
        }

        [Theory]
        [ClassData(typeof(TD_SerializedBoards))]
        public void DeserializedBoard_HasCorrectWidth(string data, int width, int height, int[] state)
        { 
            var sut = BoardState.FromString(data);

            Assert.Equal(width, sut.Width);
        }

        [Theory]
        [ClassData(typeof(TD_SerializedBoards))]
        public void DeserializedBoard_HasCorrectHeight(string data, int width, int height, int[] state)
        {
            var sut = BoardState.FromString(data);

            Assert.Equal(height, sut.Height);
        }

        [Theory]
        [ClassData(typeof(TD_SerializedBoards))]
        public void DeserializedBoard_HasCorrectStateData(string data, int width, int height, int[] state)
        {
            var sut = BoardState.FromString(data);

            Assert.Equal(state, sut.Tiles);
        }
        #pragma warning restore xUnit1026

        [Theory]
        [ClassData(typeof(TD_SerializedBoards_InvalidData))]
        public void DeserializeBoard_InvalidData_Throws(string data)
        {
            Assert.Throws<ArgumentException>(() => BoardState.FromString(data));
        }

        [Theory]
        [ClassData(typeof(TD_SerializedBoards_InvalidData))]
        public void DeserializeBoard_InvalidSize_Throws(string data)
        {
            Assert.Throws<ArgumentException>(() => BoardState.FromString(data));
        }
    }
}