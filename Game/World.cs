using System.Collections.Generic;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game
{
	/// <summary>
	/// Represents the game world with all entities.
	/// </summary>
	internal class World : IPaintable
	{
		ICollection<Entity> _entities;

		public World()
		{
			// We don't need to access individual elements of this collection,
			// so a linked list makes sense here.
			_entities = new LinkedList<Entity>();
		}

		public void Update()
		{
		}

		public void Paint(System.Drawing.Graphics g)
		{
			throw new System.NotImplementedException();
		}
	}
}
