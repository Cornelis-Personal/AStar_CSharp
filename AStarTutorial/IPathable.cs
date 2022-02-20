using System.Collections.Generic;

namespace AStarTutorial
{
    public interface IPathable
    {
        /// <summary>
        /// List of connected Tiles.
        ///
        /// This needs to be setup by you.
        /// Think of it as all the reachable tiles from a specific one.
        /// For a simple square based board it might be more efficient to use Vectors,
        /// however, if you want to create Multi-Dimential boards/Teleports/etc
        ///
        /// then this is the way to go.
        /// </summary>
        public List<IPathable> Connected { get; set; }
    }
}