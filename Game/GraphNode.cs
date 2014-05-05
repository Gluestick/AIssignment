using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	internal class GraphNode
	{
		private Vector2 _position;

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
