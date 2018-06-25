using PuzzleCore;

namespace PuzzleSolver
{
    public abstract class DistanceFunction
    {
        public DistanceFunction(BoardState finalState)
        {
            _finalState = finalState;
        }

        public abstract int Measure(BoardState currentState);

        protected BoardState _finalState;

    }
}