using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game
{
	/// <summary>
	/// Represents the game world with all entities.
	/// </summary>
	internal class World : IPaintable
	{
		private Pen _graphPen = new Pen(Color.FromArgb(230, 230, 230), 1);

		private ICollection<Entity> _entities;
		private Graph _graph;

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
			_graph = WorldGraphFactory.CreateGraph(0, 0, 10, 10, 32);
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

			foreach (GraphEdge edge in _graph.Edges)
			{
				g.DrawLine(
					_graphPen,
					(int)edge.Source.Position.X, (int)edge.Source.Position.Y,
					(int)edge.Destination.Position.X, (int)edge.Destination.Position.Y
				);
			}

			foreach (Entity entity in _entities)
			{
				entity.Paint(g);
			}
		}
	}
}
