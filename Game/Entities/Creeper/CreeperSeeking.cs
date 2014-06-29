using System.Diagnostics;
using FuzzyLogic;
using FuzzyLogic.Operators;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;
using ISGPAI.Game.Entities;

namespace ISGPAI.Game.Entities
{
	/// <summary>
	/// Creeper state when the creeper is nearby the adventurer.
	/// </summary>
	public class CreeperSeeking : State<Creeper>
	{
		private FuzzyModule _fuzzy;
		private Entity _target;
		private World _world;
		private ISteeringBehavior _steeringBehavior;

		public CreeperSeeking(Creeper agent, Entity target, World world)
			: base(agent)
		{
			this._target = target;
			this._world = world;
			_steeringBehavior = new SeekSteering(target);
			FuzzyInit();
		}

		private void FuzzyInit()
		{
			_fuzzy = new FuzzyModule();

			// Two antecedents
			FuzzyVariable distance = _fuzzy.CreateFLV("distance");
			IFuzzySet dClose = distance.AddLeftShoulderSet("close", 0, 10, 20);
			IFuzzySet dNominal = distance.AddTriangularSet("nominal", 10, 20, 100);
			IFuzzySet dFar = distance.AddRightShoulderSet("far", 20, 100, 250);

			FuzzyVariable health = _fuzzy.CreateFLV("health");
			IFuzzySet hLow = health.AddLeftShoulderSet("low", 0, 25, 35);
			IFuzzySet hNominal = health.AddTriangularSet("nominal", 25, 35, 75);
			IFuzzySet hPlenty = health.AddRightShoulderSet("far", 35, 75, 100);

			// One consequent (how desirable it is to commit suicide by detonating).
			FuzzyVariable detonate = _fuzzy.CreateFLV("detonate");
			IFuzzySet dtUndesirable = detonate.AddLeftShoulderSet("undesirable", 0, 40, 60);
			IFuzzySet dtDesirable = detonate.AddTriangularSet("desirable", 40, 60, 80);
			IFuzzySet dtVerydesirable = detonate.AddRightShoulderSet("verydesirable", 60, 80, 100);

			_fuzzy.AddRule(dClose, dtVerydesirable);
			_fuzzy.AddRule(dFar, dtUndesirable);
			_fuzzy.AddRule(hPlenty, dtUndesirable);
			_fuzzy.AddRule(new FuzzyAnd(dNominal, hLow), dtVerydesirable);
			_fuzzy.AddRule(new FuzzyAnd(dNominal, hNominal), dtDesirable);
		}

		public override void Enter()
		{
			_agent.MaxSpeed = 200;
			Debug.WriteLine("Creeper {0} starts seeking {1}.",
				_agent.Id, _target.Id);
		}

		public override void Update(double elapsed)
		{
			double distance = (_target.Position - _agent.Position).Length;
			_fuzzy.Fuzzify("distance", distance);
			_fuzzy.Fuzzify("health", _agent.Health);

			double detonate = _fuzzy.DeFuzzify("detonate", DefuzzifyType.MaxAv);
			if (detonate > 60)
			{
				_world.AddEntity(new CreeperExplosion(_world, _agent.Position));
				_world.RemoveEntity(_agent);
				return;
			}

			// Go back to wandering if our target is out of sight.
			if ((_agent.Position - _target.Position).Length > Creeper.Sight)
			{
				_agent.ChangeState(new CreeperWandering(_agent, _world));
				return;
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
