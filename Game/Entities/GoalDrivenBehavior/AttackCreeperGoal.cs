using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class AttackCreeperGoal : CompositeGoal<Helper>
	{
		private const double AttackRange = 20;

		private World _world;
		private Creeper _target;

		public AttackCreeperGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;
			RemoveAllSubgoals();

			if (_target == null || _target.Health <= 0)
			{
				FindNearestTarget();
				if (_target == null)
				{
					// No creepers to attack.
					_status = Status.Failed;
					return;
				}
			}
			AddSubGoal(new FleeGoal(_owner, _target));
			AddSubGoal(new AttackGoal(_owner, _world));

			if (!IsTargetInRange())
			{
				AddSubGoal(new SeekGoal(_owner, _target));
			}
		}

		public override Status Process()
		{
			ActivateIfInactive();
			if (_status == Status.Failed)
			{
				return _status;
			}
			_status = ProcessSubGoals();
			ReactivateIfFailed();
			return _status;
		}

		public override void Terminate()
		{
		}

		private void FindNearestTarget()
		{
			double closestCreeperDistance = double.MaxValue;
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

		private bool IsTargetInRange()
		{
			return (_owner.Position - _target.Position).Length <= AttackRange;
		}

		public override string Name
		{
			get { return "Attack nearby creeper"; }
		}
	}
}
