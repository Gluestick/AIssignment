namespace ISGPAI.Game.Entities.GoalDrivenBehavior
{
	public abstract class Goal<T>
		where T : Entity
	{
		protected T _owner;
		protected Status _status;

		public abstract void Activate();
		public abstract Status Process();
		public abstract void Terminate();
		public abstract void AddSubGoal(Goal<T> goal);

		public bool IsActive()
		{
			return _status == Status.Active;
		}

		public bool IsInactive()
		{
			return _status == Status.Inactive;
		}

		public bool IsCompleted()
		{
			return _status == Status.Completed;
		}

		public bool HasFailed()
		{
			return _status == Status.Failed;
		}
	}
}