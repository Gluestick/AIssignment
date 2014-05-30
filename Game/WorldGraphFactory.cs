using ISGPAI.Game.Collections;
using ISGPAI.Game.Maths;

namespace ISGPAI.Game
{
	internal static class WorldGraphFactory
	{
		public static Graph CreateGraph(
			int x, int y,
			int columns, int rows,
			float sizePerEdge)
		{
			Graph graph = new Graph();
			GraphNode[,] nodes = new GraphNode[columns, rows];

			// Create all GraphNodes.
			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					double xPos = x * sizePerEdge + i * sizePerEdge;
					double yPos = y * sizePerEdge + j * sizePerEdge;
					nodes[i, j] = new GraphNode(new Vector2(xPos, yPos));
				}
			}

			// Create all GraphEdges and add them to the graph.
			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					CreateEdges(graph, nodes, i, j, columns, rows);
				}
			}
			return graph;
		}

		private static void CreateEdges(Graph graph, GraphNode[,] nodes, int x, int y,
			int columns, int rows)
		{
			for (int i = x - 1; i < x + 2; i++)
			{
				for (int j = y - 1; j < y + 2; j++)
				{
					if (i > 0 && i < columns && j > 0 && j < rows &&
						!(i == x && j == y))
					{
						graph.AddEdge(new GraphEdge(nodes[x, y], nodes[i, j]));
					}
				}
			}
		}
	}
}
