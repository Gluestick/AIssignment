using System.Diagnostics;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when the creeper is nearby the adventurer.
	/// </summary>
	internal class CreeperSeeking : State<Creeper>
	{
		private Entity _target;
		private World _world;
		private ISteeringBehavior _steeringBehavior;

		public CreeperSeeking(Creeper agent, Entity target, World world)
			: base(agent)
		{
			this._target = target;
			this._world = world;
			_steeringBehavior = new SeekSteering(target);
		}

		public override void Enter()
		{
			_agent.MaxSpeed = 200;
			Debug.WriteLine("Creeper {0} starts seeking {1}.",
				_agent.Id, _target.Id);
		}

		public override void Update(double elapsed)
		{
			// Go back to wandering if our target is out of sight.
			if ((_agent.Position - _target.Position).Length > Creeper.Sight)
			{
				_agent.ChangeState(new CreeperWandering(_agent, _world));
			}

			Vector2 steeringForce = _steeringBehavior.Steer(_agent, elapsed) * 8;
			Vector2 acceleration = steeringForce / _agent.Mass;
			_agent.Velocity += acceleration * elapsed;
			_agent.Velocity = _agent.Velocity.Truncate(_agent.MaxSpeed);
			_agent.Position += _agent.Velocity * elapsed;
		}

		public override void Exit()
		{
			Debug.WriteLine("Target {0} is out of sight. Creeper {1} goes back to wandering.",
				_target.Id, _agent.Id);
		}
	}
}
