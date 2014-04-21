using System.Drawing;

namespace ISGPAI.Game.Entities
{
	internal class Creeper : MovingEntity, IStateChangeable<Creeper>
	{
		private World _world;
		private StateMachine<Creeper> _stateMachine;

		public Creeper(World world)
		{
			// Wandering is the default state.
			this._stateMachine = new StateMachine<Creeper>(
				this, new CreeperWandering(this, _world));
			this._world = world;
		}

		public void ChangeState(State<Creeper> newState)
		{
			_stateMachine.ChangeState(newState);
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
