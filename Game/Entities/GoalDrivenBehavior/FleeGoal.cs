using System;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	/// <summary>
	/// Atomic goal for a Helper that seeks to the location specified
	/// during construction.
	/// </summary>
	public class FleeGoal : Goal<Helper>
	{
		// Owner must be this far away from the target to complete the goal.
		private const double FleeRange = 200;

		private Entity _target;

		public FleeGoal(Helper owner, Entity target)
		{
			this._owner = owner;
			this._target = target;
		}

		public override void Activate()
		{
			this._status = Status.Active;
			_owner.SetSteering(new FleeSteering(_target));
		}

		public override Status Process()
		{
			if (IsInactive())
			{
				// If we're already near our target, there's nothing to do.
				if (IsOutOfRange())
				{
					_status = Status.Completed;
					return _status;
				}
				Activate();
			}
			if (IsOutOfRange())
			{
				Terminate();
				_status = Status.Completed;
				return _status;
			}
			return _status;
		}

		public override void Terminate()
		{
			_owner.StopSteering();
		}

		public override void AddSubGoal(Goal<Helper> goal)
		{
			throw new InvalidOperationException(
				"Cannot add subgoals to an atomic goal");
		}

		private bool IsOutOfRange()
		{
			return (_owner.Position - _target.Position).Length < FleeRange;
		}

		public override string Name
		{
			get { return "Flee from target."; }
		}
	}
}