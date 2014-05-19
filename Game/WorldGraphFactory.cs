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
			for (int i = x; i < columns; i++)
			{
				for (int j = y; j < rows; j++)
				{
					AddEdgesToGraphAt(graph, i, j, sizePerEdge);
				}
			}
			return graph;
		}

		/// <summary>
		/// Adds edges to all horizontal, vertical and diagonal
		/// nodes in both directions.
		/// </summary>
		private static void AddEdgesToGraphAt(Graph graph, int i, int j, float sizePerEdge)
		{
			Vector2 source = new Vector2(i * sizePerEdge, j * sizePerEdge);

			// Horizontal
			graph.AddEdge(CreateEdge(source, source + new Vector2(sizePerEdge, 0)));
			graph.AddEdge(CreateEdge(source + new Vector2(sizePerEdge, 0), source));
			graph.AddEdge(CreateEdge(source, source + new Vector2(-sizePerEdge, 0)));
			graph.AddEdge(CreateEdge(source + new Vector2(-sizePerEdge, 0), source));

			// Vertical
			graph.AddEdge(CreateEdge(source, source + new Vector2(0, sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(0, sizePerEdge), source));
			graph.AddEdge(CreateEdge(source, source + new Vector2(0, -sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(0, -sizePerEdge), source));

			// Diagonal top
			graph.AddEdge(CreateEdge(source, source + new Vector2(-sizePerEdge, sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(-sizePerEdge, sizePerEdge), source));
			graph.AddEdge(CreateEdge(source, source + new Vector2(sizePerEdge, sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(sizePerEdge, sizePerEdge), source));

			// Diagonal bottom
			graph.AddEdge(CreateEdge(source, source + new Vector2(-sizePerEdge, -sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(-sizePerEdge, -sizePerEdge), source));
			graph.AddEdge(CreateEdge(source, source + new Vector2(sizePerEdge, -sizePerEdge)));
			graph.AddEdge(CreateEdge(source + new Vector2(sizePerEdge, -sizePerEdge), source));
		}

		/// <summary>
		/// Creates an edge with the specified source and destination node.
		/// </summary>
		private static GraphEdge CreateEdge(Vector2 source, Vector2 destination)
		{
			return new GraphEdge(
				new GraphNode(source), new GraphNode(destination)
			);
		}
	}
}
