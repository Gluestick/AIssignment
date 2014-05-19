using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Collections
{
	/// <summary>
	/// AStar heuristic that calculates the euclidean distance between the
	/// destination node of the given edge in Calculate() and the destination
	/// specified in the constructor.
	/// </summary>
	internal class EuclideanDistanceHeuristic : IAStarHeuristic
	{
		private GraphNode _destination;

		public EuclideanDistanceHeuristic(GraphNode destination)
		{
			this._destination = destination;
		}

		public int Calculate(GraphEdge edge)
		{
			Vector2 distance = edge.Destination.Position - _destination.Position;
			return (int)distance.Length;
		}
	}
}
