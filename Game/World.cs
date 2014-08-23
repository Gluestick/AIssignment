using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ISGPAI.Game.Collections;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game
{
	/// <summary>
	/// Represents the game world with all entities.
	/// </summary>
	public class World : IPaintable
	{
		private const int GraphEdgeSize = 32;
		private const int GraphWidth = 48;
		private const int GraphHeight = 24;

		private bool _drawGraph;
		private Pen _graphPen = new Pen(Color.FromArgb(5, 60, 5), 1);
		private Bitmap _graphCache;
		private bool _entitiesReadOnly;
		private ICollection<Entity> _entities;
		private ICollection<Entity> _removable;
		private ICollection<Entity> _addable;
		private Graph _graph;

		public Graph Graph
		{
			get { return _graph; }
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
			_addable = new LinkedList<Entity>();
			_removable = new LinkedList<Entity>();
			_graph = WorldGraphFactory.CreateGraph(
				GraphWidth / -2, GraphHeight / -2,
				GraphWidth, GraphHeight,
				GraphEdgeSize);
		}

		public void RemoveEntity(Entity entity)
		{
			if (!_entitiesReadOnly)
			{
				_entities.Remove(entity);
			}
			else
			{
				_removable.Add(entity);
			}
		}

		/// <summary>
		/// Add a new entity to keep track of.
		/// </summary>
		public void AddEntity(Entity newEntity)
		{
			if (!_entitiesReadOnly)
			{
				_entities.Add(newEntity);
			}
			else
			{
				_addable.Add(newEntity);
			}
		}

		/// <summary>
		/// Adds a new entity and removes any nodes from the graph that collide
		/// with this entity
		/// </summary>
		public void AddCollidingEntity(Entity newEntity)
		{
			if (!_entitiesReadOnly)
			{
				_entities.Add(newEntity);
			}
			else
			{
				_addable.Add(newEntity);
			}
			_graph.RemoveEdgesFor(newEntity);
		}

		private bool _gPressed = false;
		public void Update(double elapsed)
		{
			this.Elapsed = elapsed;

			foreach (Entity entity in _addable)
			{
				_entities.Add(entity);
			}
			_addable.Clear();
			foreach (Entity entity in _removable)
			{
				_entities.Remove(entity);
			}
			_removable.Clear();

			_entitiesReadOnly = true;
			foreach (Entity entity in _entities)
			{
				entity.Update(elapsed);
			}
			_entitiesReadOnly = false;
			if (!_gPressed && Keyboard.IsKeyDown(Keys.G))
			{
				_gPressed = true;
				_drawGraph = !_drawGraph;
			}
			else if (!Keyboard.IsKeyDown(Keys.G))
			{
				_gPressed = false;
			}
		}

		public void Paint(Graphics g)
		{
			if (_drawGraph)
			{
				PaintGraph(g);
			}

			foreach (Entity entity in _entities.OrderBy(e => e.DrawOrder))
			{
				entity.Paint(g);
			}
		}

		public void PaintGraph(Graphics g)
		{
			if (_graphCache == null)
			{
				_graphCache = new Bitmap(GraphEdgeSize * GraphWidth, GraphEdgeSize * GraphHeight);
				Graphics cache = Graphics.FromImage(_graphCache);
				double xOffset = GraphWidth * GraphEdgeSize / 2;
				double yOffset = GraphHeight * GraphEdgeSize / 2;
				foreach (GraphEdge edge in _graph.Edges)
				{
					cache.DrawLine(
						_graphPen,
						(int)(xOffset + edge.Source.Position.X),
						(int)(yOffset + edge.Source.Position.Y),
						(int)(xOffset + edge.Destination.Position.X),
						(int)(yOffset + edge.Destination.Position.Y)
					);
				}
			}
			g.DrawImage(_graphCache,
				new Point(_graphCache.Width / -2, _graphCache.Height / -2));
		}
	}
}
