using System.Diagnostics;
using ISGPAI.Game.SteeringBehaviors;
namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when there is no adventurer nearby.
	/// </summary>
	internal class CreeperWandering : State<Creeper>
	{
		private World _world;
		private ISteeringBehavior _steeringBehavior;

		public CreeperWandering(Creeper agent, World world)
			: base(agent)
		{
			this._world = world;
			this._steeringBehavior = new WanderSteering();
		}

		public override void Enter()
		{
			Debug.WriteLine("Creeper {0} starts wandering.", _agent.Id);
		}

		public override void Update(double elapsed)
		{
			// Change to seeking state if an adventurer is nearby.
			foreach (Entity entity in _world.Entities)
			{
				if (entity is Adventurer)
				{
					if ((_agent.Position - entity.Position).Length <= CreeperSeeking.Sight)
					{
						_agent.ChangeState(new CreeperSeeking(_agent, entity, _world));
						return;
					}
				}
			}
			Vector2 steeringForce = _steeringBehavior.Steer(_agent, elapsed) * 8;
			Vector2 acceleration = steeringForce / _agent.Mass;
			_agent.Velocity += acceleration * elapsed;
			_agent.Velocity = _agent.Velocity.Truncate(_agent.MaxSpeed);
			_agent.Position += _agent.Velocity * elapsed;
		}

		public override void Exit()
		{
			Debug.WriteLine("Creeper {0} found target {1}. Start seeking.",
				_agent.Id, "TODO");
		}
	}
}
