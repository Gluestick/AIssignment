using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ISGPAI.Game.Collections;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game
{
	/// <summary>
	/// Represents the game world with all entities.
	/// </summary>
	internal class World : IPaintable
	{
		private const int GraphEdgeSize = 32;
		private const int GraphWidth = 80;
		private const int GraphHeight = 60;

		private Pen _graphPen = new Pen(Color.FromArgb(230, 230, 230), 1);
		private Bitmap _graphCache;
		private ICollection<Entity> _entities;
		private Graph _graph;

		public Graph Graph
		{
			get { return _graph; }
		}

		public bool DrawGraph
		{
			get;
			set;
		}

		/// <summary>
		/// Get an enumerable with all the entities in this world.
		/// </summary>
		public IEnumerable<Entity> Entities
		{
			get { return _entities; }
		}

		public double Elapsed { get; set; }

		public World()
		{
			// We don't need to access individual elements of this collection,
			// so a linked list makes sense here.
			_entities = new LinkedList<Entity>();
			_graph = WorldGraphFactory.CreateGraph(
				GraphWidth / -2, GraphHeight / -2,
				GraphWidth, GraphHeight,
				GraphEdgeSize);
		}

		/// <summary>
		/// Add a new entity to keep track of.
		/// </summary>
		public void AddEntity(Entity newEntity)
		{
			_entities.Add(newEntity);
		}

		public void Update(double elapsed)
		{
			this.Elapsed = elapsed;
			foreach (Entity entity in _entities)
			{
				entity.Update(elapsed);
			}
		}

		public void Paint(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;

			if (DrawGraph)
			{
				PaintGraph(g);
			}

			foreach (Entity entity in _entities)
			{
				entity.Paint(g);
			}
		}

		private void PaintGraph(Graphics g)
		{
			if (_graphCache == null)
			{
				_graphCache = new Bitmap(GraphEdgeSize * GraphWidth, GraphEdgeSize * GraphHeight);
				Graphics cache = Graphics.FromImage(_graphCache);
				foreach (GraphEdge edge in _graph.Edges)
				{
					cache.DrawLine(
						_graphPen,
						(int)edge.Source.Position.X, (int)edge.Source.Position.Y,
						(int)edge.Destination.Position.X, (int)edge.Destination.Position.Y
					);
				}
			}
			g.DrawImage(_graphCache,
				new Point(_graphCache.Width / -2, _graphCache.Height / -2));
		}
	}
}
