using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	public interface IShortestPathAlgorithm
	{
		IEnumerable<GraphNode> GetShortestPath(GraphNode start, GraphNode destination);
	}
}
