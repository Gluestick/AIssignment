using System;
using System.Collections;
using System.Collections.Generic;

namespace ISGPAI.Game.Collections
{
	/// <summary>
	/// IEnumerable type for depth first search through a graph.
	/// </summary>
	public class DepthFirstGraph : IEnumerable<GraphNode>
	{
		private Graph _graph;
		private GraphNode _startNode;

		public DepthFirstGraph(Graph graph, GraphNode startNode)
		{
			this._graph = graph;
			this._startNode = startNode;
		}

		public IEnumerator<GraphNode> GetEnumerator()
		{
			return new DepthFirstGraphEnumerator(_graph, _startNode);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Enumerator type for depth first search in a graph.
		/// </summary>
		public class DepthFirstGraphEnumerator : IEnumerator<GraphNode>
		{
			private Graph _graph;
			private ICollection<GraphNode> _visited;
			private GraphNode _current;
			private GraphNode _startNode;

			public DepthFirstGraphEnumerator(Graph graph, GraphNode startNode)
			{
				this._graph = graph;
				this._startNode = startNode;
				Initialize();
			}

			private void Initialize()
			{
				this._current = this._startNode;
				this._visited = new LinkedList<GraphNode>();
			}

			public GraphNode Current
			{
				get { return _current; }
			}

			public void Dispose()
			{
				throw new NotImplementedException();
			}

			object IEnumerator.Current
			{
				get { throw new NotImplementedException(); }
			}

			public bool MoveNext()
			{
				throw new NotImplementedException();
			}

			public void Reset()
			{
				Initialize();
			}
		}
	}
}
