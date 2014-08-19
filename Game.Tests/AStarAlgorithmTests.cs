using System;
using System.Collections.Generic;
using System.Linq;
using ISGPAI.Game;
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

		[TestMethod]
		public void ConnectedGraph_GetShortestPath_ReturnsCorrectPath()
		{
			// Create a graph with four nodes, connected in a straight line.
			Graph graph = new Graph();

			const int NodeCount = 4;
			GraphNode start = new GraphNode(new Vector2(0f, 0f));
			GraphNode midFirst = new GraphNode(new Vector2(1f, 1f));
			GraphNode midSecond = new GraphNode(new Vector2(2f, 2f));
			GraphNode destination = new GraphNode(new Vector2(3f, 3f));

			graph.AddEdge(new GraphEdge(start, midFirst));
			graph.AddEdge(new GraphEdge(midFirst, midSecond));
			graph.AddEdge(new GraphEdge(midSecond, destination));

			AStarAlgorithm astar = new AStarAlgorithm(graph);
			IEnumerable<GraphNode> path =
				astar.GetShortestPath(start, destination).Path;
			Assert.IsTrue(path.Count() == NodeCount,
				"Path has an invalid amount of nodes");
		}

		[TestMethod]
		[Timeout(1500)]
		public void BigConnectedGraph_GetShortestPath_NoInfiniteLoop()
		{
			Graph graph = WorldGraphFactory.CreateGraph(-9, -20, 18, 40, 10);
			GraphNode startNode = graph.NearestNode(new Vector2(-50, -50));
			GraphNode endNode = graph.NearestNode(new Vector2(50, 50));

			// Should not take forever.
			new AStarAlgorithm(graph).GetShortestPath(startNode, endNode);
		}
	}
}
