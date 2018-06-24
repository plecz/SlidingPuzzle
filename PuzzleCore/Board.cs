using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PuzzleCore
{
    public class BoardState : IEquatable<BoardState>
    {
        public BoardState(int width, int height) //, int[] tiles)
        {
            _width = width;
            _height = height;
            ValidateSize();

            _tiles = new int[width * height];
            _validMoves = GetValidMoves();
            
            //***
            SetFinalState();
        }

        //TODO: make use of other ctor
        private BoardState(int[] data)
        {
            if (data.Length < 6)
            {
                throw new ArgumentException("There is not enough data to construct the board state");
            }
            _width = data[0];
            _height = data[1];
            ValidateSize();

            var length = _width * _height;
            if (data.Length != length + 2)
            {
                throw new ArgumentException("Board size does not match tile data length");
            }
            var tiles = data.Skip(2).ToArray();
            _tiles = tiles;
            ValidateTiles();

            _validMoves = GetValidMoves();
        }

        private void ValidateSize()
        {
            if (_width < 2)
            {
                throw new ArgumentException("Board width cannot be less than 2");
            }
            if (_height < 2)
            {
                throw new ArgumentException("Board height cannot be less than 2");
            }
        }

        private void ValidateTiles()
        {
            if (!Enumerable.SequenceEqual(_tiles.OrderBy(d => d), Enumerable.Range(0, _tiles.Length)))
            {
                throw new ArgumentException("Board state is invalid (duplicate/missing/invalid tiles)");
            }
        }

        public static BoardState FromString(string boardData)
        {
            var data = Array.ConvertAll(boardData.Split(','), int.Parse);
            return new BoardState(data);
        }

        public override string ToString()
        {
            var s = string.Join(",", _tiles);
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
                return _validMoves;
            }
        }

        private Directions GetValidMoves()
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

        public BoardState Move(Directions direction)
        {
            if (direction != Directions.Up && direction != Directions.Down && direction != Directions.Left && direction != Directions.Right)
            {
                throw new ArgumentException("direction ***");
            }
            if ((ValidMoves & direction) == Directions.None)
            {
                throw new ArgumentException("direction ***");
            }

            var nextBoard = new BoardState(Width, Height);
            nextBoard._tiles = NextState(direction);
            return nextBoard;
        }

        public ReadOnlyCollection<int> Tiles
        {
            get { return Array.AsReadOnly(_tiles); }
        }

        private int GetESIndex()
        {
            return Array.IndexOf(_tiles, 0);
        }

        private void SetFinalState()
        {
            var len = Width * Height;
            _tiles = (from n in Enumerable.Range(1, len) select n % len).ToArray();
        }

        private int[] NextState(Directions direction)
        {
            var esIndex = GetESIndex();
            int[] nextState = (int[])_tiles.Clone();
            switch (direction)
            {
                case Directions.Up:
                    nextState[esIndex] = _tiles[esIndex - Width];
                    nextState[esIndex - Width] = 0;
                    break;
                case Directions.Down:
                    nextState[esIndex] = _tiles[esIndex + Width];
                    nextState[esIndex + Width] = 0;
                    break;
                case Directions.Left:
                    nextState[esIndex] = _tiles[esIndex - 1];
                    nextState[esIndex - 1] = 0;
                    break;
                case Directions.Right:
                    nextState[esIndex] = _tiles[esIndex + 1];
                    nextState[esIndex + 1] = 0;
                    break;
                default:
                    throw new ArgumentException("direction ***");
            }

            return nextState;
        }

        public bool Equals(BoardState other)
        {
            if (other != null)
            {
                if (Width == other.Width &&
                    Height == other.Height &&
                    Enumerable.SequenceEqual(Tiles, other.Tiles))
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

            return Equals(obj as BoardState);
        }

        private readonly int _width;
        private readonly int _height;
        private int[] _tiles;
        private Directions _validMoves;
    }
}
