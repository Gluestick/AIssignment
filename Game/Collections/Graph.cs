using System;
using System.Collections.Generic;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Collections
{
	public class Graph
	{
		private ICollection<GraphEdge> _edges;

		public IEnumerable<GraphEdge> Edges
		{
			get { return _edges; }
		}

		public Graph()
		{
			_edges = new LinkedList<GraphEdge>();
		}

		public void AddEdge(GraphEdge edge)
		{
			_edges.Add(edge);
		}

		public GraphNode NearestNode(Vector2 position)
		{
			if (_edges.Count == 0)
			{
				throw new InvalidOperationException(
					"Cannot get a node in an empty graph."
				);
			}
			GraphNode nearest = null;
			double shortestLength = float.PositiveInfinity;
			foreach (GraphEdge current in _edges)
			{
				double currentLength = (current.Source.Position - position).Length;
				if (currentLength < shortestLength)
				{
					shortestLength = currentLength;
					nearest = current.Source;
				}
			}
			return nearest;
		}

		/// <summary>
		/// Returns an enumerator that uses the depth first algorithm to traverse
		/// this tree, starting at the specified start node.
		/// </summary>
		public IEnumerable<GraphNode> GetDepthFirstEnumerable(GraphNode startNode)
		{
			return new DepthFirstGraph(this, startNode);
		}
	}
}
