using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class MotivateGoal : Goal<Helper>
	{
		private const double MotivateRange = 15;

		private Explorer _target;
		private World _world;

		public MotivateGoal(Helper owner, World world)
		{
			this._owner = owner;
			this._world = world;
		}

		public override void Activate()
		{
			_status = Status.Active;

			// Find the closest target to motivate.
			double closestTargetDistance = MotivateRange;
			double currentDistance;
			foreach (Entity entity in _world.Entities)
			{
				currentDistance = (_target.Position - entity.Position).Length;
				if (entity is Explorer && currentDistance < closestTargetDistance)
				{
					// Closer target found. Update closest target and distance.
					closestTargetDistance = currentDistance;
					_target = (Explorer)entity;
				}
			}
		}

		public override Status Process()
		{
			Activate();
			if (_target == null)
			{
				// There is no target within range. Cannot complete goal.
				_status = Status.Failed;
				return _status;
			}
			// Motivate target and mark goal as completed.
			_target.SpeedBoost();
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
	}
}