namespace ISGPAI.Game.Collections
{
	partial class AStarAlgorithm
	{
		private class AStarGraphNode
		{
			public GraphNode GraphNode { get; set; }

			/// <summary>
			/// Sum of the best distance and estimated distance.
			/// </summary>
			public float Score
			{
				get
				{
					return BestDistance + EstimatedDistance;
				}
			}

			/// <summary>
			/// The best distance that has been calculated for this node so far.
			/// </summary>
			public float BestDistance { get; set; }

			/// <summary>
			/// Estimated distance to the destination.
			/// </summary>
			public float EstimatedDistance { get; set; }

			public AStarGraphNode(GraphNode node)
			{
				this.GraphNode = node;
			}
		}
	}
}
