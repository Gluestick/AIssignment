using System;
using System.Collections.Generic;
using ISGPAI.Game.Entities;
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

		public void RemoveEdgesFor(Entity entity)
		{
			var removableEdges = new LinkedList<GraphEdge>();

			// Check what edges to remove.
			foreach (GraphEdge edge in _edges)
			{
				if (entity.IsInside(edge.Source.Position) ||
					entity.IsInside(edge.Destination.Position))
				{
					removableEdges.AddLast(edge);
				}
			}

			// Remove the edges. Seperate loop required, becuase you can't
			// remove anything in the collection you're iterating through.
			foreach (GraphEdge removable in removableEdges)
			{
				_edges.Remove(removable);
			}
		}
	}
}
