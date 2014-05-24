using System;
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
			if (GetShortestPathRecursive(start, destination))
			{
				return null;
			}
			throw new InvalidOperationException("Startnode is not connected to destination node.");
		}

		/// <summary>
		/// Recursive call for calculating the shortest path.
		/// </summary>
		/// <returns>Whether the current node is connected to the destination.</returns>
		private bool GetShortestPathRecursive(GraphNode current, GraphNode destination)
		{
			return false;
		}

		private void Initialize()
		{
			_visitedNodes = new LinkedList<GraphNode>();
		}
	}
}
