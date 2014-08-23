using System;

namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public class EnterHouseGoal : Goal<Helper>
	{
		public EnterHouseGoal(Helper owner)
		{
			this._owner = owner;
		}

		public override void Activate()
		{
			_status = Status.Active;
		}

		public override Status Process()
		{
			Activate();
			_owner.StopMovement();
			_owner.IsVisible = false;
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
			get { return "Enter house"; }
		}
	}
}
