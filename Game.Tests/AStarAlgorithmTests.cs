using System;
using ISGPAI.Game.Collections;
using ISGPAI.Game.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	[TestClass]
	public class AStarAlgorithmTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GraphWithDisconnectedNodes_GetShortestPath_ThrowsArgumentException()
		{
			GraphNode source = new GraphNode(new Vector2(0f, 0f));
			GraphNode destination = new GraphNode(new Vector2(10f, 10f));
			Graph disconnectedGraph = new Graph();
			disconnectedGraph.AddEdge(
				new GraphEdge(source, new GraphNode(new Vector2(1f, 1f)))
			);
			disconnectedGraph.AddEdge(
				new GraphEdge(new GraphNode(new Vector2(5f, 5f)), destination)
			);
			AStarAlgorithm astar = new AStarAlgorithm(disconnectedGraph);

			// Should throw an argument exception, because it cannot
			// calculate the shortest path between disconnected nodes.
			astar.GetShortestPath(source, destination);
		}
	}
}
