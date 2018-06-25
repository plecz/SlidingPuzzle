using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PuzzleCore;

namespace PuzzleSolver
{
    public class Solver
    {
        public static List<Directions> Solve(BoardState startState, BoardState finalState)
        {
            return AStarSearch.Search(startState, finalState, new ManhattanDistance(finalState));
        }
    }
}
