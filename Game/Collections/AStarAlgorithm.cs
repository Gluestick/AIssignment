using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	internal partial class AStarAlgorithm : IShortestPathAlgorithm
	{
		private Graph _graph;
		private ICollection<GraphNode> _visitedNodes;

		public AStarAlgorithm(Graph graph)
		{
			this._graph = graph;
		}

		public IEnumerable<GraphNode> GetShortestPath(GraphNode start, GraphNode destination)
		{
			Initialize();
			ICollection<GraphNode> path = new LinkedList<GraphNode>();
			path.Add(start);
			GraphNode current = start;
			while (current != destination)
			{
				foreach (GraphEdge edge in current.AdjecentEdges)
				{
				}
			}
			return null;
		}

		private void Initialize()
		{
			_visitedNodes = new LinkedList<GraphNode>();
		}
	}
}
