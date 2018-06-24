using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PuzzleCore
{
    public class Board : IEquatable<Board>
    {
        public Board(int width, int height)
        {
            _width = width;
            _height = height;
            ValidateSize();

            _state = new int[width * height];
            //***
            SetFinalState();
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

        public Tuple<int, int> ESPosition
        {
            get
            {
                var i = GetESIndex();
                return new Tuple<int, int>(i % Width, i / Width);
            }
        }

        public Directions ValidMoves
        {
            get
            {
                var column = ESPosition.Item1;
                var row = ESPosition.Item2;
                var d = Directions.None;
                if (row > 0)
                {
                    d |= Directions.Up;
                }
                if (row < Height - 1)
                {
                    d |= Directions.Down;
                }
                if (column > 0)
                {
                    d |= Directions.Left;
                }
                if (column < Width - 1)
                {
                    d |= Directions.Right;
                }

                return d;
            }
        }

        public Board Move(Directions direction)
        {
            if (direction != Directions.Up && direction != Directions.Down && direction != Directions.Left && direction != Directions.Right)
            {
                throw new ArgumentException("direction ***");
            }
            if ((ValidMoves & direction) == Directions.None)
            {
                throw new ArgumentException("direction ***");
            }

            var nextBoard = new Board(Width, Height);
            nextBoard._state = NextState(direction);
            return nextBoard;
        }

        public ReadOnlyCollection<int> State
        {
            get { return Array.AsReadOnly(_state); }
        }

        private int GetESIndex()
        {
            return Array.IndexOf(_state, 0);
        }

        private void SetFinalState()
        {
            var len = Width * Height;
            _state = (from n in Enumerable.Range(1, len) select n % len).ToArray();
        }

        private int[] NextState(Directions direction)
        {
            var esIndex = GetESIndex();
            int[] nextState = (int[])_state.Clone();
            switch (direction)
            {
                case Directions.Up:
                    nextState[esIndex] = _state[esIndex - Width];
                    nextState[esIndex - Width] = 0;
                    break;
                case Directions.Down:
                    nextState[esIndex] = _state[esIndex + Width];
                    nextState[esIndex + Width] = 0;
                    break;
                case Directions.Left:
                    nextState[esIndex] = _state[esIndex - 1];
                    nextState[esIndex - 1] = 0;
                    break;
                case Directions.Right:
                    nextState[esIndex] = _state[esIndex + 1];
                    nextState[esIndex + 1] = 0;
                    break;
                default:
                    throw new ArgumentException("direction ***");
            }

            return nextState;
        }

        public bool Equals(Board other)
        {
            if (other != null)
            {
                if (Width == other.Width &&
                    Height == other.Height &&
                    Enumerable.SequenceEqual(State, other.State))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals(obj as Board);
        }

        private readonly int _width;
        private readonly int _height;
        private int[] _state;
    }
}
