using System.Diagnostics;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when the creeper is nearby the adventurer.
	/// </summary>
	internal class CreeperSeeking : State<Creeper>
	{
		private Entity _target;
		private ISteeringBehavior _steeringBehavior;

		public CreeperSeeking(Creeper agent, Entity target)
			: base(agent)
		{
			this._target = target;
			_steeringBehavior = new SeekSteering(target);
		}

		public override void Enter()
		{
			Debug.WriteLine("Creeper {0} starts seeking {1}.",
				_agent.Id, _target.Id);
		}

		public override void Update(double elapsed)
		{
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
