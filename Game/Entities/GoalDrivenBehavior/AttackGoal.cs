using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class AttackGoal : Goal<Helper>
	{
		private const double AttackRange = 15;
		private const int Damage = 100;

		private Creeper _target;
		private World _world;

		public AttackGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;

			// Find the closest creeper to attack.
			double closestCreeperDistance = AttackRange;
			double currentDistance;
			foreach (Entity entity in _world.Entities)
			{
				currentDistance = (_owner.Position - entity.Position).Length;
				if (entity is Creeper && currentDistance < closestCreeperDistance)
				{
					// Closer target found. Update closest target and distance.
					closestCreeperDistance = currentDistance;
					_target = (Creeper)entity;
				}
			}
		}

		public override Status Process()
		{
			Activate();
			if (_target == null)
			{
				// There is no target within attack range. Cannot complete goal.
				_status = Status.Failed;
				return _status;
			}
			// Attack target and mark goal as completed.
			_target.Attack(Damage);
			_status = Status.Completed;
			return _status;
		}

		public override void Terminate()
		{
		}

		public override void AddSubGoal(Goal<Helper> goal)
		{
			throw new InvalidOperationException(
				"Cannot add subgoals to an atomic goal");
		}

		public override string Name
		{
			get { return "Attack target"; }
		}
	}
}
