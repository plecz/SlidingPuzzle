using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCore
{
    public class Board
    {
        public Board(int width, int height)
        {
            _width = width;
            _height = height;
            ValidateSize();

            _state = new int[width * height];
            SetInitialState();
        }

        private Board(int[] data)
        {
            if (data.Length < 6)
            {
                throw new ArgumentException(nameof(data)); //***
            }
            _width = data[0];
            _height = data[1];
            ValidateSize();

            var length = _width * _height;
            if (data.Length != length + 2)
            {
                throw new ArgumentException(nameof(data)); //***
            }
            var state = data.Skip(2).ToArray();
            _state = state;
            ValidateState();
        }

        private void ValidateSize()
        {
            if (_width < 2)
            {
                throw new ArgumentException("*** width");
            }
            if (_height < 2)
            {
                throw new ArgumentException("*** height");
            }
        }

        private void ValidateState()
        {
            if (!Enumerable.SequenceEqual(_state.OrderBy(d => d), Enumerable.Range(0, _state.Length)))
            {
                throw new ArgumentException("*** state data");
            }
        }

        public static Board FromString(string boardData)
        {
            var data = Array.ConvertAll(boardData.Split(','), int.Parse);
            return new Board(data);
        }

        public override string ToString()
        {
            var s = string.Join(",", _state);
            return $"{Width},{Height},{s}";
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        
        public IReadOnlyCollection<int> State
        {
            get { return Array.AsReadOnly(_state); }
        }

        private void SetInitialState()
        {
            var len = Width * Height;
            _state = (from n in Enumerable.Range(1, len) select n % len).ToArray();
        }

        private readonly int _width;
        private readonly int _height;
        private int[] _state;
    }
}
