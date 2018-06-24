using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PuzzleCore
{
    public class Game
    {
        public Game(BoardState startState, BoardState finalState = null)
        {
            if (finalState == null)
            {
                finalState = DefaultFinalState(startState.Width, startState.Height);
            }

            ValidateBoardSizes(startState, finalState);
            ValidateSolvability(startState);

            CurrentBoardState = startState;
            _startState = startState;
            _finalState = finalState;
            _moves = new List<Directions>();

        }

        private void ValidateBoardSizes(BoardState startState, BoardState finalState)
        {
            if (startState.Width != finalState.Width ||
                startState.Height != finalState.Height)
            {
                throw new ArgumentException("Start and final boards cannot have different sizes");
            }
        }

        private void ValidateSolvability(BoardState state)
        {
            int inversions = CountInversions(state.Tiles);
            if (!CheckSolvability(state, inversions))
            {
                throw new ArgumentException("The given board state is unsolvable");
            }
        }

        private int CountInversions(ReadOnlyCollection<int> state)
        {
            int inversions = 0;

            for (int i = 0; i < state.Count - 1; ++i)
            {
                for (int j = i + 1; j < state.Count; ++j)
                {
                    if (state[j] != 0 && state[j] < state[i])
                    {
                        ++inversions;
                    }
                }
            }

            return inversions;
        }

        private bool CheckSolvability(BoardState state, int inversions)
        {
            if (state.Width % 2 != 0)
            {
                return (inversions % 2 == 0);
            }
            else
            {
                int esRowFromBottom = state.Height - state.ESPosition.Item2;
                if (esRowFromBottom % 2 == 0)
                {
                    return (inversions % 2 == 1);
                }
                else
                {
                    return (inversions % 2 == 0);
                }
            }
        }

        public bool IsSolved
        {
            get
            {
                return Enumerable.SequenceEqual(CurrentBoardState.Tiles, _finalState.Tiles);
            }
        }

        public void Move(Directions direction)
        {
            CurrentBoardState = CurrentBoardState.Move(direction);
            _moves.Add(direction);
        }

        public IReadOnlyCollection<Directions> Moves
        {
            get
            {
                return _moves.AsReadOnly();
            }
        }

        public void Reset()
        {
            _moves.Clear();
            CurrentBoardState = _startState;
        }

        public void Shuffle()
        {
            _moves.Clear();
            CurrentBoardState = GetRandomState(_startState.Width, _startState.Height);
        }

        private static BoardState DefaultFinalState(int width, int height)
        {
            var len = width * height;
            var tiles = (from n in Enumerable.Range(1, len) select n % len).ToArray();

            return new BoardState(width, height, tiles);
        }

        public static BoardState GetRandomState(int width, int height, int rndCount = 100)
        {
            var finalState = DefaultFinalState(width, height);
            return Randomize(finalState, rndCount);
        }

        private static BoardState Randomize(BoardState board, int rndCount)
        {
            Directions[] values = (Directions[])Enum.GetValues(typeof(Directions));
            var rnd = new Random();
            for (int i = 0; i < rndCount; ++i)
            {
                Directions move = Directions.None;
                while (move == Directions.None)
                {
                    var r = rnd.Next(1, 5);
                    var d = values[r];
                    move = board.ValidMoves & d;
                    if (move != Directions.None)
                    {
                        board = board.Move(move);
                    }
                }
            }

            return board;
        }

        public BoardState CurrentBoardState { get; private set; }
        public BoardState StartState { get { return _startState; } }

        public BoardState FinalState { get { return _finalState; } }

        private BoardState _startState;
        private BoardState _finalState;
        private List<Directions> _moves;
    }
}
