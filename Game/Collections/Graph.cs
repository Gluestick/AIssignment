using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	internal class Graph
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
	}
}
