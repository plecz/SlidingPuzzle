using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleCore
{
    public class Game
    {
        public Game(BoardState startState, BoardState finalState = null)
        {
            CurrentBoardState = startState;
            _startState = startState;
            if (finalState == null)
            {
                finalState = DefaultFinalState(startState.Width, startState.Height);
            }
            _finalState = finalState;
            _moves = new List<Directions>();
            ValidateSolvability();
        }

        public bool IsSolved
        {
            get
            {
                return Enumerable.SequenceEqual(CurrentBoardState.Tiles, _finalState.Tiles);
            }
        }

        private void ValidateSolvability()
        {
            int inversions = CountInversions(CurrentBoardState.Tiles);
            if (!CheckSolvability(inversions))
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

        private bool CheckSolvability(int inversions)
        {
            if (CurrentBoardState.Width % 2 == 0)
            {
                return (inversions % 2 == 0);
            }
            else
            {
                int esRowFromBottom = CurrentBoardState.Height - CurrentBoardState.ESPosition.Item2;
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

        private BoardState DefaultFinalState(int width, int height)
        {
            var len = width * height;
            var tiles = (from n in Enumerable.Range(1, len) select n % len).ToArray();

            return new BoardState(width, height, tiles);
        }

        public BoardState CurrentBoardState { get; private set; }

        private BoardState _startState;
        private BoardState _finalState;
        private List<Directions> _moves;
    }
}
