using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	internal interface IShortestPathAlgorithm
	{
		IEnumerable<GraphNode> GetShortestPath(GraphNode start, GraphNode destination);
	}
}
