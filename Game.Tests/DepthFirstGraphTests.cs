using ISGPAI.Game.Collections;
using ISGPAI.Game.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
	[TestClass]
	public class DepthFirstGraphTests
	{
		[TestMethod]
		public void ConnectedGraph_GetDepthFirstEnumerable_StartsWithStartNode()
		{
			Graph graph = new Graph();
			GraphNode start = new GraphNode(new Vector2(0, 0));
			GraphNode finish = new GraphNode(new Vector2(1, 1));
			graph.AddEdge(new GraphEdge(start, finish));
			var enumerator = graph.GetDepthFirstEnumerable(start).GetEnumerator();
			Assert.IsTrue(enumerator.Current == start,
				"Enumerator did not start with the correct node");
		}

		[TestMethod]
		public void ConnectedGraph_GetDepthFirstEnumerable_TraversesCorrectAmountOfNodes()
		{
			const int EdgeCount = 4;
			const int NodeCount = EdgeCount + 1;
			Graph graph = new Graph();
			GraphNode start = new GraphNode(new Vector2());
			GraphNode currentSource = start;
			GraphNode currentDestination;
			for (int i = 0; i < EdgeCount; i++)
			{
				currentDestination = new GraphNode(new Vector2());
				graph.AddEdge(new GraphEdge(currentSource, currentDestination));
				currentSource = currentDestination;
			}
			var enumerator = graph.GetDepthFirstEnumerable(start).GetEnumerator();
			int actualCount = 1;
			while (enumerator.MoveNext())
			{
				actualCount++;
			}
			Assert.AreEqual(NodeCount, actualCount,
				"DeothFirstEnumerator did not traverse the correct amount of nodes.");
		}
	}
}
