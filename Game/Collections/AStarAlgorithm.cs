using System;
using System.Linq;
using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	internal partial class AStarAlgorithm : IShortestPathAlgorithm
	{
		private Graph _graph;
		private ICollection<GraphNode> _openList;
		private ICollection<GraphNode> _closedList;
		private GraphNode _destination;
		private IAStarHeuristic _heuristic;

		public AStarAlgorithm(Graph graph)
		{
			this._graph = graph;
		}

		public IEnumerable<GraphNode> GetShortestPath(GraphNode start, GraphNode destination)
		{
			Initialize(destination);
			start.BestDistance = 0f;
			if (GetShortestPathRecursive(start, destination))
			{
				var path = new LinkedList<GraphNode>();
				GraphNode current = destination;
				path.AddFirst(current);
				while (current != start)
				{
					current = current.Parent;
					path.AddFirst(current);
				}
				return path.ToList();
			}
			throw new ArgumentException("Startnode is not connected to destination node.");
		}

		/// <summary>
		/// Recursive call for calculating the shortest path.
		/// </summary>
		/// <returns>Whether the current node is connected to the destination.</returns>
		private bool GetShortestPathRecursive(GraphNode current, GraphNode destination)
		{
			foreach (GraphEdge edge in current.AdjecentEdges)
			{
				// If our current node is in the open list...
				if (_openList.Any(n => n == edge.Destination))
				{
					// Update best distance if we have a better distance.
					if (current.BestDistance + edge.Cost <
						edge.Destination.BestDistance)
					{
						edge.Destination.BestDistance =
							current.BestDistance + edge.Cost;
					}
				}
				else // Update best distance and add node to open list.
				{
					edge.Destination.BestDistance =
						current.BestDistance + edge.Cost;
					edge.Destination.EstimatedDistance =
						_heuristic.Calculate(edge.Destination);
					_openList.Add(edge.Destination);
				}
			}
			_openList.Remove(current);
			_closedList.Add(current);
			GraphNode next = _openList.FirstOrDefault(n =>
				n.Score == _openList.Min(ni => ni.Score)
			);
			if (next == null)
			{
				// Can't find a path, go back.
				return false;
			}
			return GetShortestPathRecursive(next, destination);
		}

		private void Initialize(GraphNode destination)
		{
			this._openList = new LinkedList<GraphNode>();
			this._closedList = new LinkedList<GraphNode>();
			this._destination = destination;
			this._heuristic = new EuclideanDistanceHeuristic(destination);
		}
	}
}
