using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class RestGoal : Goal<Helper>
	{
		private const int MaxRestIterations = 2500;

		private int _restIterations = 0;

		public RestGoal(Helper owner)
		{
			this._owner = owner;
		}

		public override void Activate()
		{
			this._status = Status.Active;
		}

		public override Status Process()
		{
			Activate();
			_restIterations++;
			if (_restIterations > MaxRestIterations)
			{
				_status = Status.Completed;
				return _status;
			}
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
