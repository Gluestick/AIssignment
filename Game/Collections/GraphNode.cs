using System.Collections.Generic;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Collections
{
	internal class GraphNode
	{
		private Vector2 _position;
		private ICollection<GraphEdge> _adjecentEdges;

		public Vector2 Position
		{
			get { return _position; }
		}

		public ICollection<GraphEdge> AdjecentEdges
		{
			get { return _adjecentEdges; }
		}

		public GraphNode(Vector2 position)
		{
			this._position = position;
		}

		public GraphNode(float positionX, float positionY)
			: this(new Vector2(positionX, positionY))
		{
			this._adjecentEdges = new LinkedList<GraphEdge>();
		}

		#region AStar
		/// <summary>
		/// Parent in the path calculated by A*.
		/// </summary>
		public GraphNode Parent { get; set; }

		/// <summary>
		/// Sum of the best distance and estimated distance.
		/// </summary>
		public float Score { get { return BestDistance + EstimatedDistance; } }

		/// <summary>
		/// The best distance that has been calculated for this node so far.
		/// </summary>
		public float BestDistance { get; set; }

		/// <summary>
		/// Estimated distance to the destination.
		/// </summary>
		public float EstimatedDistance { get; set; }
		#endregion
	}
}
