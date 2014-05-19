using ISGPAI.Game.Maths;

namespace ISGPAI.Game.Collections
{
	internal class GraphNode
	{
		private Vector2 _position;

		public Vector2 Position
		{
			get { return _position; }
		}

		public GraphNode(Vector2 position)
		{
			this._position = position;
		}

		public GraphNode(float positionX, float positionY)
			: this(new Vector2(positionX, positionY))
		{
		}
	}
}
