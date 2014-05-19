using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	internal interface IShortestPathAlgorithm
	{
		IEnumerable<GraphNode> GetShortestPath(Graph graph);
	}
}
