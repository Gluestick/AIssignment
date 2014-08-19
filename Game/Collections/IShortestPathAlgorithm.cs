using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	public interface IShortestPathAlgorithm
	{
		ShortestPath GetShortestPath(GraphNode start, GraphNode destination);
	}
}
