using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	public class ShortestPath
	{
		public IEnumerable<GraphNode> Path { get; set; }
		public IEnumerable<GraphEdge> ConsideredEdges { get; set; }

		public ShortestPath(IEnumerable<GraphNode> path,
			IEnumerable<GraphEdge> consideredEdges)
		{
			this.Path = path;
			this.ConsideredEdges = consideredEdges;
		}
	}
}
