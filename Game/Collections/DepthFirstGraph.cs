using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	/// <summary>
	/// IEnumerable type for depth first search through a graph.
	/// </summary>
	public class DepthFirstGraph : IEnumerable<GraphNode>
	{
		private Graph _graph;

		public DepthFirstGraph(Graph graph)
		{
			this._graph = graph;
		}

		public IEnumerator<GraphNode> GetEnumerator()
		{
			return new DepthFirstGraphEnumerator(_graph);
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// Enumerator type for depth first search in a graph.
		/// </summary>
		public class DepthFirstGraphEnumerator : IEnumerator<GraphNode>
		{
			private Graph _graph;

			public DepthFirstGraphEnumerator(Graph graph)
			{
				this._graph = graph;
			}

			public GraphNode Current
			{
				get { throw new System.NotImplementedException(); }
			}

			public void Dispose()
			{
				throw new System.NotImplementedException();
			}

			object System.Collections.IEnumerator.Current
			{
				get { throw new System.NotImplementedException(); }
			}

			public bool MoveNext()
			{
				throw new System.NotImplementedException();
			}

			public void Reset()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}
