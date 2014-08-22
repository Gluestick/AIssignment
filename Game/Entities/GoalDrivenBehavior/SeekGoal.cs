using System;
using ISGPAI.Game.Maths;
using ISGPAI.Game.SteeringBehaviors;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	/// <summary>
	/// Atomic goal for a Helper that seeks to the location/entity specified
	/// during construction.
	/// </summary>
	public class SeekGoal : Goal<Helper>
	{
		// Owner must be this close to the target to complete this goal.
		private const double TargetDistance = 10;

		private Vector2 _target;
		private Entity _targetEntity;

		private Vector2 TargetLocation
		{
			get
			{
				if (_targetEntity != null)
				{
					return _targetEntity.Position;
				}
				return _target;
			}
		}

		public SeekGoal(Helper owner, Vector2 target)
		{
			this._owner = owner;
			this._target = target;
		}

		public SeekGoal(Helper owner, Entity target)
		{
			this._owner = owner;
			this._targetEntity = target;
		}

		public override void Activate()
		{
			this._status = Status.Active;
			if (_targetEntity != null)
			{
				_owner.SetSteering(new SeekSteering(_targetEntity));
			}
			else
			{
				_owner.SetSteering(new SeekAtSteering()
					{
						Location = _target
					});
			}
		}

		public override Status Process()
		{
			if (IsInactive())
			{
				// If we're already near our target, there's nothing to do.
				if (IsNearTarget())
				{
					_status = Status.Completed;
					return _status;
				}
				Activate();
			}
			if (IsNearTarget())
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

		private bool IsNearTarget()
		{
			return (_owner.Position - _target).Length < TargetDistance;
		}
	}
}
