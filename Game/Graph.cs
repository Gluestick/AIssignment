using System.Collections.Generic;

namespace ISGPAI.Game
{
	internal class Graph
	{
		private ICollection<GraphEdge> _edges;

		public Graph()
		{
			_edges = new LinkedList<GraphEdge>();
		}
	}
}
