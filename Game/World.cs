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
		private ICollection<Entity> _entities;

		/// <summary>
		/// Get an enumerable with all the entities in this world.
		/// </summary>
		public IEnumerable<Entity> Entities
		{
			get { return _entities; }
		}

		public World()
		{
			// We don't need to access individual elements of this collection,
			// so a linked list makes sense here.
			_entities = new LinkedList<Entity>();
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
			foreach (Entity entity in _entities)
			{
				entity.Update(elapsed);
			}
		}

		public void Paint(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			foreach (Entity entity in _entities)
			{
				entity.Paint(g);
			}
		}
	}
}
