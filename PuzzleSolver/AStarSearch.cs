using System;
using System.Collections.Generic;

using PuzzleCore;
using Priority_Queue;

namespace PuzzleSolver
{
    public class AStarSearch
    {
        public static List<Directions> Search(BoardState startState, BoardState finalState, DistanceFunction distance)
        {
            var openNodes = new SimplePriorityQueue<GraphNode>();
            var root = new GraphNode(startState);
            var closedNodes = new HashSet<GraphNode>();

            openNodes.Enqueue(root, distance.Measure(root.Board));

            while(openNodes.Count != 0)
            {
                var currentNode = openNodes.Dequeue();
                closedNodes.Add(currentNode);

                if (currentNode.Board.Equals(finalState))
                {
                    return currentNode.GetPathFromRoot();
                }

                var children = currentNode.ExpandNode();
                foreach (var child in children)
                {
                    if (!closedNodes.Contains(child))
                    {
                        openNodes.Enqueue(child, distance.Measure(child.Board) + child.Depth);
                    }
                }

                while (closedNodes.Contains(openNodes.First))
                {
                    openNodes.Dequeue();
                }
            }

            return null;
        }
    }
}
