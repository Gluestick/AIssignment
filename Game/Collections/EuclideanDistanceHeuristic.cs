using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Collections
{
	/// <summary>
	/// AStar heuristic that calculates the euclidean distance between the
	/// node specified in Calculate(0 and the destination specified in the constructor.
	/// </summary>
	internal class EuclideanDistanceHeuristic : IAStarHeuristic
	{
		private GraphNode _destination;

		public EuclideanDistanceHeuristic(GraphNode destination)
		{
			this._destination = destination;
		}

		public int Calculate(GraphNode node)
		{
			Vector2 distance = node.Position - _destination.Position;
			return (int)distance.Length;
		}
	}
}
