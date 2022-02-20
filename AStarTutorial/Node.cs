using System.Collections.Generic;

namespace AStarTutorial
{
    public class Node<T> where T : IPathable
    {
        public Node(T pathable)
        {
            Path = new List<T>();
            Pathable = pathable;
        }

        public float Cost { get; set; }
        public List<T> Path { get; set; }
        public T Pathable { get; set; }
        public int Moves { get; set; }
    }
}