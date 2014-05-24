namespace ISGPAI.Game.Collections
{
	partial class AStarAlgorithm
	{
		private class AStarNode
		{
			public GraphNode GraphNode { get; set; }

			public AStarNode(GraphNode node)
			{
				this.GraphNode = node;
			}
		}
	}
}
