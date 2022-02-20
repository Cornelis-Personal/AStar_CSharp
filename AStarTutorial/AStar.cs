using System.Collections.Generic;
using System.Linq;

namespace AStarTutorial
{
    public static class AStar
    {
        /// <summary>
        /// Get a path towards a single value.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<IPathable> GetPath(IPathable start, IPathable end)
        {
            var frontier = new Queue<Node<IPathable>>();
            var explored = new List<IPathable>();

            var initialNode = new Node<IPathable>(start);

            frontier.Enqueue(initialNode);

            while (frontier.Count > 0)
            {
                var node = frontier.Dequeue();
                explored.Add(node.Pathable);

                // If no more moves left then go to next node
                if (node.Moves == 0) continue;

                foreach (var pathable in node.Pathable.Connected.Where(x => !explored.Contains(x)))
                {
                    var otherNode = new Node<IPathable>(pathable);

                    // Check if there are
                    // Update the path
                    otherNode.Path = new List<IPathable>(node.Path);
                    otherNode.Path.Add(node.Pathable);

                    // Update the cost
                    // <CREATE OWN CUSTOM COST FUNCTION BELOW, THIS IS JUST AN EXAMPLE>
                    otherNode.Cost = node.Cost + 1;

                    // Increase the move range example
                    //      if (pathable.IsMoveIncrease())
                    //          node.Moves += 2; // range increase of 2

                    // Now check if it is the destination
                    if (otherNode.Pathable == end)
                    {
                        return node.Path;
                    }

                    // Queue the node to be explored next
                    frontier.Enqueue(node);
                }
            }

            // Null means --> No Path Found
            return null;
        }

        /// <summary>
        /// Get all reachable places given a start position
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<IPathable> GetReachable(IPathable start)
        {
            var frontier = new Queue<Node<IPathable>>();
            var explored = new List<IPathable>();

            var initialNode = new Node<IPathable>(start);

            frontier.Enqueue(initialNode);

            while (frontier.Count > 0)
            {
                var node = frontier.Dequeue();
                explored.Add(node.Pathable);

                // If no more moves left then go to next node
                if (node.Moves == 0) continue;

                foreach (var pathable in node.Pathable.Connected.Where(x => !explored.Contains(x)))
                {
                    var otherNode = new Node<IPathable>(pathable);

                    // Check if there are
                    // Update the path
                    otherNode.Path = new List<IPathable>(node.Path);
                    otherNode.Path.Add(node.Pathable);

                    // Update the cost
                    // <CREATE OWN CUSTOM COST FUNCTION BELOW, THIS IS JUST AN EXAMPLE>
                    otherNode.Cost = node.Cost + 1;

                    // Increase the move range example
                    //      if (pathable.IsMoveIncrease())
                    //          node.Moves += 2; // range increase of 2

                    // Queue the node to be explored next
                    frontier.Enqueue(node);
                }
            }

            // Null means --> No Path Found
            return explored;
        }
    }
}