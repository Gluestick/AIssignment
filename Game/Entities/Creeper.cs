using System.Drawing;

namespace ISGPAI.Game.Entities
{
	internal class Creeper : MovingEntity
	{
		private World _world;

		public Creeper(World world)
		{
			this._world = world;
		}

		public override void Update(double elapsed)
		{
			throw new System.NotImplementedException();
		}

		public override void Paint(Graphics g)
		{
			throw new System.NotImplementedException();
		}
	}
}
