namespace ISGPAI.Game.Collections
{
	partial class AStarAlgorithm
	{
		private class AStarGraphNode
		{
			public GraphNode GraphNode { get; set; }

			public AStarGraphNode(GraphNode node)
			{
				this.GraphNode = node;
			}
		}
	}
}
