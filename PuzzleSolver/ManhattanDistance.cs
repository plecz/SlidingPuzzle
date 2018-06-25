using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PuzzleCore;

namespace PuzzleSolver
{
    public class ManhattanDistance : DistanceFunction
    {
        public ManhattanDistance(BoardState finalState)
            : base(finalState)
        {
            int tileCount = finalState.Width * finalState.Height;
            _indexToColRow = new Tuple<int, int>[tileCount];
            for (int i = 0; i < tileCount; ++i)
            {
                int col = i % finalState.Width;
                int row = i / finalState.Width;
                _indexToColRow[i] = new Tuple<int, int>(col, row);
            }
        }

        public override int Measure(BoardState currentState)
        {
            int sum = 0;

            for (int i = 0; i < currentState.Tiles.Count; ++i)
            {
                int tile = currentState.Tiles[i];
                var currentTilePos = _indexToColRow[i];
                int finalTileIndex = _finalState.Tiles.IndexOf(tile);
                var finalTilePos = _indexToColRow[finalTileIndex];

                sum += Distance(currentTilePos, finalTilePos);
            }

            return sum;
        }

        private int Distance(Tuple<int, int> currentTilePos, Tuple<int, int> finalTilePos)
        {
            return Math.Abs(currentTilePos.Item1 - finalTilePos.Item1) +
                Math.Abs(currentTilePos.Item2 - finalTilePos.Item2);
        }

        private Tuple<int, int>[] _indexToColRow;
    }
}
