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
        public Game(BoardState startBoard)
        {
            CurrentBoard = startBoard;
            _startState = startBoard;
            _finalState = new BoardState(startBoard.Width, startBoard.Height);
            _moves = new List<Directions>();
            ValidateSolvability();
        }

        public bool IsSolved
        {
            get
            {
                //TODO: make state/board naming consistent
                return Enumerable.SequenceEqual(CurrentBoard.Tiles, _finalState.Tiles);
            }
        }

        private void ValidateSolvability()
        {
            int inversions = CountInversions(CurrentBoard.Tiles);
            if (!CheckSolvability(inversions))
            {
                throw new ArgumentException("startBoard ***");
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
            if (CurrentBoard.Width % 2 == 0)
            {
                return (inversions % 2 == 0);
            }
            else
            {
                int esRowFromBottom = CurrentBoard.Height - CurrentBoard.ESPosition.Item2;
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
            CurrentBoard = CurrentBoard.Move(direction);
            _moves.Add(direction);
        }

        public IReadOnlyCollection<Directions> Moves
        {
            get
            {
                return _moves.AsReadOnly();
            }
        }
        public BoardState CurrentBoard { get; private set; }

        private BoardState _startState;
        private BoardState _finalState;
        private List<Directions> _moves;
    }
}
