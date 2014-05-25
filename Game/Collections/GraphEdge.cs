namespace ISGPAI.Game.Collections
{
	public class GraphEdge
	{
		private GraphNode _source;
		private GraphNode _destination;

		public GraphNode Source
		{
			get
			{
				return _source;
			}
		}

		public GraphNode Destination
		{
			get
			{
				return _destination;
			}
		}

		public float Cost
		{
			get
			{
				return 0f;
			}
		}

		public GraphEdge(GraphNode source, GraphNode destination)
		{
			this._source = source;
			this._destination = destination;

			source.AdjecentEdges.Add(this);
		}
	}
}
