using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PuzzleCore;

namespace PuzzleSolver
{
    public class GraphNode //: IComparable<GraphNode>
    {
        public GraphNode(BoardState board)
            :this(board, null, Directions.None)
        {

        }

        public GraphNode(BoardState board, GraphNode parent, Directions move)
        {
            Board = board;
            Parent = parent;
            Move = move;
            Depth = (Parent == null ? 0 : parent.Depth + 1);
        }
        
        public List<GraphNode> ExpandNode()
        {
            var nodes = new List<GraphNode>();
            Directions[] directions = (Directions[])Enum.GetValues(typeof(Directions));
            foreach (var d in directions)
            {
                if ((d & Board.ValidMoves) != Directions.None)
                {
                    var nextBoardState = Board.Move(d);
                    if (this.Parent == null || !Equals(nextBoardState, this.Parent.Board))
                    {
                        nodes.Add(new GraphNode(nextBoardState, this, d));
                    }
                }
            }

            return nodes;
        }

        //public int CompareTo(GraphNode other)
        //{
        //    if (this.Cost < other.Cost)
        //    {
        //        return -1;
        //    }
        //    if  (this.Cost > other.Cost)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}

        public List<Directions> GetPathFromRoot()
        {
            var path = new List<Directions>();
            var currentNode = this;
            while(currentNode.Parent != null)
            {
                path.Add(currentNode.Move);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        public override int GetHashCode()
        {
            return Board.GetHashCode();
        }

        public BoardState Board { get; private set; }
        public GraphNode Parent { get; private set; }
        public Directions Move { get; private set; }
        public int Depth { get; private set; }
    }
}
