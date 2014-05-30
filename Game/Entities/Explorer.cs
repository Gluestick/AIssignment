using System;
using System.Drawing;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Moving entity that explorers the world graph. When the explorer is
	/// done exploring, it will start over, beginning at his current position.
	/// </summary>
	internal class Explorer : MovingEntity
	{
		private World _world;

		public Explorer(World world)
		{
			this._world = world;
		}

		public override void Update(double elapsed)
		{
			throw new NotImplementedException();
		}

		public override void Paint(Graphics g)
		{
			throw new NotImplementedException();
		}
	}
}
