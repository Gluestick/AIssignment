using System.Drawing;

namespace ISGPAI.Game.Entities
{
	internal class Creeper : MovingEntity
	{
		private World _world;
		private StateMachine<Creeper> _stateMachine;

		public Creeper(World world)
		{
			this._stateMachine = new StateMachine<Creeper>(this);
			this._world = world;
		}

		public override void Update(double elapsed)
		{
			_stateMachine.Update(elapsed);
		}

		public override void Paint(Graphics g)
		{
			throw new System.NotImplementedException();
		}
	}
}
