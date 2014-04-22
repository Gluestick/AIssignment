using System.Drawing;
using System.Linq;

namespace ISGPAI.Game.Entities
{
	internal class Creeper : MovingEntity, IStateChangeable<Creeper>
	{
		private World _world;
		private StateMachine<Creeper> _stateMachine;

		public Creeper(World world)
		{
			Mass = 1;
			MaxSpeed = 20000;
			// Wandering is the default state.
			this._world = world;
			this._stateMachine = new StateMachine<Creeper>(
				this, new CreeperSeeking(this, _world.Entities.First(), _world));
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
			const int Size = 20;
			g.FillRectangle(Brushes.Green,
				(int)Position.X - Size / 2,
				(int)Position.Y - Size / 2,
				Size, Size
			);
		}
	}
}
